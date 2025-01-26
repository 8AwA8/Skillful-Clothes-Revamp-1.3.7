using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Effects;
using StardewValley.Objects;

namespace SkillfulClothes.Types
{
	// Token: 0x020000C0 RID: 192
	internal class ShoesDrawWrapper : Boots
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0000537E File Offset: 0x0000357E
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x00005386 File Offset: 0x00003586
		public IEffect Effect { get; private set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x0000538F File Offset: 0x0000358F
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x00005397 File Offset: 0x00003597
		public Boots WrappedItem { get; private set; }

		// Token: 0x06000469 RID: 1129 RVA: 0x000053A0 File Offset: 0x000035A0
		public void Assign(Boots hat, IEffect effect)
		{
			if (this.WrappedItem == hat)
			{
				return;
			}
			this.Effect = effect;
			this.GetOneCopyFrom(hat);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x000053BA File Offset: 0x000035BA
		public override void drawTooltip(SpriteBatch spriteBatch, ref int x, ref int y, SpriteFont font, float alpha, StringBuilder overrideText)
		{
			base.drawTooltip(spriteBatch, ref x, ref y, font, alpha, overrideText);
			if (this.Effect != null)
			{
				EffectHelper.drawTooltip(this.Effect, spriteBatch, ref x, ref y, font, alpha, overrideText);
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0001635C File Offset: 0x0001455C
		public override Point getExtraSpaceNeededForTooltipSpecialIcons(SpriteFont font, int minWidth, int horizontalBuffer, int startingHeight, StringBuilder descriptionText, string boldTitleText, int moneyAmountToDisplayAtBottom)
		{
			Point extraSpaceNeededForTooltipSpecialIcons = base.getExtraSpaceNeededForTooltipSpecialIcons(font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
			if (this.Effect != null)
			{
				Point extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix = EffectHelper.getExtraSpaceNeededForTooltipSpecialIconsBootsOnlyFix(this.Effect, font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
				if (this.immunityBonus.Value == 0)
				{
					extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.Y -= Math.Max((int)font.MeasureString("TT").Y, 36);
				}
				extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.X = Math.Max(extraSpaceNeededForTooltipSpecialIcons.X, extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.X);
				extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.Y = Math.Max(extraSpaceNeededForTooltipSpecialIcons.Y, extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.Y);
				return extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix;
			}
			return extraSpaceNeededForTooltipSpecialIcons;
		}
	}
}
