using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Friend_of_Bill : T_ItemRestrictions
    {
        protected override List<string> Dialogue => new List<string>() { CNameDialogue.CantUseAlcohol1, CNameDialogue.CantUseAlcohol2, CNameDialogue.CantUseAlcohol3 };

        public override bool ItemUsable(InvItem invItem) =>
            !invItem.Categories.Contains(VItemCategory.Alcohol);

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Friend_of_Bill>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You are taking things one day at a time. But every day sucks when you can't get drunk anymore.",
                    [LanguageCode.Russian] = "Вы пьёте одну бутылку за другой, но каждый день без выпивки - это отстой!",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Friend_of_Bill)),
                    [LanguageCode.Russian] = "Бывший алкоголик",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(DAREdevil), nameof(Teetotaller), VanillaTraits.Addict },
                    CharacterCreationCost = -1,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = false,
                        cantSwap = false,
                        isUpgrade = true,
                        prerequisites = { VanillaTraits.Addict },
                        recommendations = { },
                        upgrade = null,
                    }
                });
        }

        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
