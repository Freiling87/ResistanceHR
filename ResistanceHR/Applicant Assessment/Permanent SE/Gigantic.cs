﻿using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Gigantic : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.Giant;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Gigantic>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Permanently giant.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Gigantic))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { VanillaTraits.WallWalloper },
					CharacterCreationCost = 100,
					IsAvailable = false,
					IsAvailableInCC = true,
					
					UnlockCost = 0,
					Upgrade = null,
					Unlock =
					{
						
						categories = { }
					}
				});
		}
		
		
	}
}