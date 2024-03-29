﻿using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Killer_Throwerer : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.KillerThrower;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Killer_Throwerer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You permanently killer thrower thingers.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Killer_Throwerer))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
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