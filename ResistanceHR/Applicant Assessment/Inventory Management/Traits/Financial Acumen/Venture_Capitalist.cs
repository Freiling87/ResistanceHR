﻿using BepInEx.Logging;
using RogueLibsCore;
using UnityEngine;

namespace RHR.Inventory
{
	public class Venture_Capitalist : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Venture_Capitalist>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You are a hound for hot tips. Your money is modified by anywhere from -100% to 100% each level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Venture_Capitalist)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = false,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Buy low, sell high. Now you're an investor!" },
						upgrade = nameof(Venture_Capitalist_Plus),
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);

			if (money is null)
				return;

			float mean = 1.0f;
			float stdDev = 0.5f;
			float u1 = Random.Range(0.0f, 1.0f);
			float u2 = Random.Range(0.0f, 1.0f);
			float z0 = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);
			float result = Mathf.Clamp(mean + stdDev * z0, 0.00f, 2.00f);
			money.invItemCount = (int)(money.invItemCount * result);
		}
	}
}