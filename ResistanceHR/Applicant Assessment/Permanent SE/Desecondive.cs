﻿using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Desecondive : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.Shrunk;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Desecondive>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Permanently 1/60 the size of someone who's Diminutive.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Desecondive))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { VanillaTraits.Bulky, nameof(Gigantic) },
					CharacterCreationCost = -32,
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