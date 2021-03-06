using ResistanceHR.Traits.Combat_Ranged;
using RogueLibsCore;

namespace ResistanceHR.Traits.Vision_Range
{
    public class Myopic : T_VisionRange
    {
        protected override float ZoomLevel => 1.50f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Myopic>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You can't see too far. In fact, you can't even see regular-far, or even far enough!",
                    [LanguageCode.Russian] = "Вы не можете видеть слишком далеко.",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Myopic)),
                    [LanguageCode.Russian] = "Близорукость",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { 
                        nameof(Eagle_Eyes), 
                        nameof(Eagle_Eyes2), 
                        nameof(Myopic2) 
                    },
                    CharacterCreationCost = -6,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = false,
                        prerequisites = { },
                        recommendations = { "Glasses" },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
