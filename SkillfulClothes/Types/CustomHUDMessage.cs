using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Extensions;

namespace SkillfulClothes.Types
{
	// Token: 0x0200001A RID: 26
	internal class CustomHUDMessage : HUDMessage
	{
		// Token: 0x060000CE RID: 206 RVA: 0x000029CE File Offset: 0x00000BCE
		public CustomHUDMessage(string message, Item forItem, Color itemColor, TimeSpan displayDuration) : base(message)
		{
			this.drawForItem = forItem;
			this.itemColor = itemColor;
			this.timeLeft = (float)displayDuration.TotalMilliseconds;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00006FD4 File Offset: 0x000051D4
		public override void draw(SpriteBatch b, int i, ref int heightUsed)
		{
			base.draw(b, i, ref heightUsed);
			Rectangle tsarea = Game1.graphics.GraphicsDevice.Viewport.GetTitleSafeArea();
			Vector2 itemBoxPosition = new Vector2((float)(tsarea.Left + 16), (float)(tsarea.Bottom - (i + 1) * 64 * 7 / 4 - 64));
			if (Game1.isOutdoorMapSmallerThanViewport())
			{
				itemBoxPosition.X = (float)Math.Max(tsarea.Left + 16, -Game1.uiViewport.X + 16);
			}
			if (Game1.uiViewport.Width < 1400)
			{
				itemBoxPosition.Y -= 48f;
			}
			itemBoxPosition.X += 16f;
			itemBoxPosition.Y += 16f;
			Item item = this.drawForItem;
			if (item == null)
			{
				return;
			}
			item.drawInMenu(b, itemBoxPosition, 1f + Math.Max(0f, (this.timeLeft - 3000f) / 900f), this.transparency, 1f, StackDrawType.Hide, this.itemColor, true);
		}

		// Token: 0x0400003E RID: 62
		private Color itemColor;

		// Token: 0x0400003F RID: 63
		private Item drawForItem;
	}
}
