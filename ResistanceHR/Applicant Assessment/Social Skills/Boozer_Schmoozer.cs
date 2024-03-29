﻿using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RHR.Item_Restrictions;
using RHR.Reputation;
using RogueLibsCore;

namespace RHR.Interaction_
{
	public class Boozer_Schmoozer : T_Interaction
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public const string
			AcceptBooze = "AcceptBooze",
			OfferBooze = "OfferBooze",
			DrankBooze = "BoozeSmoked",

			z = "";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Boozer_Schmoozer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Gain XP for drinking booze. Give booze to make neutral NPCs Friendly.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Boozer_Schmoozer)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Friend_of_Bill),
						nameof(Teetotaller)
					},
					CharacterCreationCost = 5,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
					Unlock =
					{
						cancellations = {
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});

			RogueLibs.CreateCustomName(AcceptBooze, NameTypes.Dialogue, new CustomNameInfo
			{
				[LanguageCode.English] = "Thanks, buddy!",
			});
			RogueLibs.CreateCustomName(OfferBooze, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Offer a drink",
			});
			RogueLibs.CreateCustomName(DrankBooze, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Drank",
			});

			RogueInteractions.CreateProvider<Agent>(h =>
			{
				Agent recipient = h.Object;
				Agent giver = h.Agent;
				InvItem booze = 
					giver.inventory.FindItem(VanillaItems.Beer) ??
					giver.inventory.FindItem(VanillaItems.Whiskey) ??
					giver.inventory.FindItem(VanillaItems.Cocktail);

				if (booze is null
					|| !giver.HasTrait<Boozer_Schmoozer>()
					|| recipient.relationships.GetRel(giver) != VRelationship.Neutral) // Only employers can give to friendly (CCU Hires), otherwise wasted
					return;
				
				h.AddButton(OfferBooze, m =>
				{
					giver.agentInvDatabase.GiveItem(booze, recipient);
					InvItem boozeReceived = recipient.agentInvDatabase.FindItem(booze.invItemName);
					boozeReceived.itemFunctions.UseItem(booze, recipient);
					recipient.SayDialogue(AcceptBooze);
					recipient.oma.offeredOfficeDrone = true;
					RelationshipHelper.SetRelationshipTo(recipient, giver, VRelationship.Friendly, true);
					recipient.SetChangeElectionPoints(giver);
					m.StopInteraction();
				});
			});
		}
	}

	[HarmonyPatch(typeof(ItemFunctions))]
	public static class P_ItemFunctions_BoozerSchmoozer
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(nameof(ItemFunctions.UseItem))]
		private static bool UseItem(InvItem item, Agent agent)
		{
			if (item.invItemName == VanillaItems.Beer || item.invItemName == VanillaItems.Whiskey)
				if (agent.isPlayer > 0 && agent.HasTrait<Boozer_Schmoozer>())
					agent.skillPoints.AddPoints(Boozer_Schmoozer.DrankBooze);

			return true;
		}
	}
}