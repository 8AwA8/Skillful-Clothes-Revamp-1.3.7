using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Audio;
using StardewValley.Menus;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004A RID: 74
	internal class IncreaseFishingTreasureChestChance : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000181 RID: 385 RVA: 0x0000318D File Offset: 0x0000138D
		public IncreaseFishingTreasureChestChance() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000A7D8 File Offset: 0x000089D8
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
			EffectHelper.ModHelper.Events.Display.MenuChanged += this.Display_MenuChanged;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000A828 File Offset: 0x00008A28
		private void Display_MenuChanged(object sender, MenuChangedEventArgs e)
		{
			BobberBar bobberBar = e.NewMenu as BobberBar;
			if (bobberBar != null && !Game1.isFestival())
			{
				IReflectedField<bool> field = EffectHelper.ModHelper.Reflection.GetField<bool>(bobberBar, "treasure", true);
				if (!field.GetValue() && Game1.random.Next(0, 6) <= (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1 : 2))
				{
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("discoverMineral", null, SoundContext.Default);
					}
					Logger.Debug("Added treasure");
					EffectHelper.ModHelper.Reflection.GetField<float>(bobberBar, "treasureAppearTimer", true).SetValue((float)Game1.random.Next(1000, 3000));
					field.SetValue(true);
				}
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000319A File Offset: 0x0000139A
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000031BC File Offset: 0x000013BC
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.TreasureChest, EffectHelper.ModHelper.Translation.Get("Spec-TreasChance"));
		}
	}
}
