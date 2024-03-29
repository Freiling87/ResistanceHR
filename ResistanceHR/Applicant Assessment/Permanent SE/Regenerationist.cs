﻿using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Regenerationist : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.RegenerateHealth;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Regenerationist>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Permanently regenerating.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Regenerationist))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { nameof(Dying), VanillaTraits.ModernWarfarer },
					CharacterCreationCost = 32,
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