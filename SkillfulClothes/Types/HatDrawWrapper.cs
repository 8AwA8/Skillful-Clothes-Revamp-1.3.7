using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Effects;
using StardewValley.Objects;

namespace SkillfulClothes.Types
{
	// Token: 0x02000023 RID: 35
	internal class HatDrawWrapper : Hat
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00002B5F File Offset: 0x00000D5F
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00002B67 File Offset: 0x00000D67
		public IEffect Effect { get; private set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00002B70 File Offset: 0x00000D70
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00002B78 File Offset: 0x00000D78
		public Hat WrappedItem { get; private set; }

		// Token: 0x060000EF RID: 239 RVA: 0x00002B81 File Offset: 0x00000D81
		public void Assign(Hat hat, IEffect effect)
		{
			if (this.WrappedItem == hat)
			{
				return;
			}
			this.Effect = effect;
			this.GetOneCopyFrom(hat);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00002B9B File Offset: 0x00000D9B
		public override void drawTooltip(SpriteBatch spriteBatch, ref int x, ref int y, SpriteFont font, float alpha, StringBuilder overrideText)
		{
			base.drawTooltip(spriteBatch, ref x, ref y, font, alpha, overrideText);
			if (this.Effect != null)
			{
				EffectHelper.drawTooltip(this.Effect, spriteBatch, ref x, ref y, font, alpha, overrideText);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00007640 File Offset: 0x00005840
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
