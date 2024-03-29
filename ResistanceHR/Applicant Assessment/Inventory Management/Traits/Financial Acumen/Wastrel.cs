﻿using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Wastrel : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Wastrel>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You waste all, yes, all, of your money in between each level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Wastrel)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Liquidator),
						nameof(Spendthrift),
					},
					CharacterCreationCost = -16,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = false,
					UnlockCost = 30,
					Unlock =
					{
						cantLose = false,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Let your mom handle your finances." },
						upgrade = null,
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);
			money.invItemCount = 0;
		}

		

	}
}