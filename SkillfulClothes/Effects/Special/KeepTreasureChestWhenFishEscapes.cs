using System;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004B RID: 75
	internal class KeepTreasureChestWhenFishEscapes : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000186 RID: 390 RVA: 0x0000318D File Offset: 0x0000138D
		public KeepTreasureChestWhenFishEscapes() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000A904 File Offset: 0x00008B04
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
			EffectHelper.ModHelper.Events.Display.MenuChanged += this.Display_MenuChanged;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000A954 File Offset: 0x00008B54
		private void Display_MenuChanged(object sender, MenuChangedEventArgs e)
		{
			BobberBar bobberBar = e.OldMenu as BobberBar;
			if (bobberBar != null)
			{
				FishingRod fishingRod = Game1.player.CurrentTool as FishingRod;
				if (fishingRod != null)
				{
					IReflectedField<float> field = EffectHelper.ModHelper.Reflection.GetField<float>(bobberBar, "distanceFromCatching", true);
					IReflectedField<bool> field2 = EffectHelper.ModHelper.Reflection.GetField<bool>(bobberBar, "treasureCaught", true);
					if ((double)field.GetValue() < 0.1 && field2.GetValue())
					{
						fishingRod.treasureCaught = true;
						fishingRod.openTreasureMenuEndFunction(0);
					}
				}
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000031DE File Offset: 0x000013DE
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00003200 File Offset: 0x00001400
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.TreasureChest, EffectHelper.ModHelper.Translation.Get("Spec-TreasKeep"));
		}
	}
}
