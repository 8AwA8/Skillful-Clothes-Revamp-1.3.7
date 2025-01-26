using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Effects;
using StardewValley.Objects;

namespace SkillfulClothes.Types
{
	// Token: 0x02000018 RID: 24
	internal class ClothingDrawWrapper : Clothing
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00002947 File Offset: 0x00000B47
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x0000294F File Offset: 0x00000B4F
		public IEffect Effect { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00002958 File Offset: 0x00000B58
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00002960 File Offset: 0x00000B60
		public Clothing WrappedItem { get; private set; }

		// Token: 0x060000CA RID: 202 RVA: 0x00002969 File Offset: 0x00000B69
		public void Assign(Clothing clothing, IEffect effect)
		{
			if (this.WrappedItem == clothing)
			{
				return;
			}
			this.Effect = effect;
			this.GetOneCopyFrom(clothing);
			this.clothesColor.Value = clothing.clothesColor.Value;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00002999 File Offset: 0x00000B99
		public override void drawTooltip(SpriteBatch spriteBatch, ref int x, ref int y, SpriteFont font, float alpha, StringBuilder overrideText)
		{
			base.drawTooltip(spriteBatch, ref x, ref y, font, alpha, overrideText);
			if (this.Effect != null)
			{
				EffectHelper.drawTooltip(this.Effect, spriteBatch, ref x, ref y, font, alpha, overrideText);
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00006F60 File Offset: 0x00005160
		public override Point getExtraSpaceNeededForTooltipSpecialIcons(SpriteFont font, int minWidth, int horizontalBuffer, int startingHeight, StringBuilder descriptionText, string boldTitleText, int moneyAmountToDisplayAtBottom)
		{
			Point p = base.getExtraSpaceNeededForTooltipSpecialIcons(font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
			if (this.Effect != null)
			{
				Point newP = EffectHelper.getExtraSpaceNeededForTooltipSpecialIcons(this.Effect, font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
				newP.X = Math.Max(p.X, newP.X);
				newP.Y = Math.Max(p.Y, newP.Y);
				return newP;
			}
			return p;
		}
	}
}
