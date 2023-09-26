﻿using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Quest_Modifiers
{
	internal class Smoke_Up_Johnny : T_QuestRewards
	{
		public override int? RewardItemBaseQty => 3;
		public override List<string> RewardItems => new List<string>() { VanillaItems.Cigarettes };
		public override float RewardMoneyMultiplier => 1f;
		public override float RewardXPMultiplier => 1f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Smoke_Up_Johnny>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You wanted to get paid in smokes. Wooooow, look at the cool guy here.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Smoke_Up_Johnny), "Smoke Up, Johnny!"),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Double_Ply_Rewards),
						nameof(Loadout_Rewards),
						nameof(Lump_Sum_Rewards),
						nameof(Monkey_Rewards),
						nameof(Unpaid_Internship),
					},
					CharacterCreationCost = 1,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 3,
					Unlock =
					{
						categories = { },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Matt Dabrowski says: <i>Smoking is fun, kids!</i>" },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}