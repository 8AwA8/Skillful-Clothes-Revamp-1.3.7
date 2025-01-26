using System;
using System.Collections.Generic;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000099 RID: 153
	internal class CrafterPower : SingleEffect<CrafterParameters>
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00004888 File Offset: 0x00002A88
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00004890 File Offset: 0x00002A90
		private Item SourceItem { get; set; }

		// Token: 0x0600036F RID: 879 RVA: 0x00004899 File Offset: 0x00002A99
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillCombat, EffectHelper.ModHelper.Translation.Get("Spec-Crafter"));
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000048BB File Offset: 0x00002ABB
		public CrafterPower(CrafterParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000371 RID: 881 RVA: 0x000048C4 File Offset: 0x00002AC4
		public CrafterPower(IEffect actualEffect) : base(CrafterParameters.With(actualEffect))
		{
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000048D2 File Offset: 0x00002AD2
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000048E3 File Offset: 0x00002AE3
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			this.SourceItem = null;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00010234 File Offset: 0x0000E434
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			Dictionary<string, string> dictionary = DataLoader.CraftingRecipes(Game1.content);
			float num = 0f;
			float num2 = EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f;
			foreach (string text in dictionary.Keys)
			{
				int num3;
				if (!(text == "Wedding Ring") && Game1.player.craftingRecipes.TryGetValue(text, out num3) && Game1.player.craftingRecipes[text] > 0)
				{
					num += num2;
				}
			}
			num = Math.Min(num / 200f, 80f);
			ShopDiscount shopDiscount = new ShopDiscount(Shop.Robin, (double)num);
			if (shopDiscount.Parameters.Discount > 80.0)
			{
				shopDiscount.Parameters.Discount = 80.0;
			}
			base.Parameters.Effect = shopDiscount;
			base.Parameters.Effect.Apply(sourceItem, reason);
		}
	}
}
