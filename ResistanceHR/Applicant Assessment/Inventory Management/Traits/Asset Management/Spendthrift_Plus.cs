﻿using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Spendthrift_Plus : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spendthrift_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You're still buying too much shit, but you're at least better at finding bargains.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spendthrift_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Light_Packer),
						nameof(Luggage_Loser),
					},
					CharacterCreationCost = 8,
					IsAvailable = false,
					IsAvailableInCC = false,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Trade },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "Works with Sucker & Shrewd Negotiator." },
						upgrade = null,
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			BuyRandomShit(agent, UnityEngine.Random.Range(2, 4), 0.8f);
		}
	}
}