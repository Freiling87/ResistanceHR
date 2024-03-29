﻿using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Invisibility_Enjoyer : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.Invisible;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Invisibility_Enjoyer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Permanently Invisible. Enjoy.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Invisibility_Enjoyer))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { VanillaTraits.BlendsInNicely },
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