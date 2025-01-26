using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000038 RID: 56
	internal static class EffectIconExtensions
	{
		// Token: 0x06000136 RID: 310 RVA: 0x00009380 File Offset: 0x00007580
		public static void Draw(this EffectIcon icon, SpriteBatch spriteBatch, Vector2 location)
		{
			if (icon == EffectIcon.None)
			{
				return;
			}
			Texture2D texture = Game1.mouseCursors;
			Rectangle? rectangle = null;
			switch (icon)
			{
			case EffectIcon.Popularity:
				Utility.drawWithShadow(spriteBatch, Game1.mouseCursors, new Vector2(location.X, location.Y + 2f), new Rectangle(157, 515, 13, 13), Color.White, 0f, Vector2.Zero, 2f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Health:
				rectangle = new Rectangle?(new Rectangle(0, 438, 10, 10));
				break;
			case EffectIcon.MaxHealth:
				texture = EffectHelper.Textures.LooseSprites;
				rectangle = new Rectangle?(new Rectangle(0, 0, 10, 10));
				break;
			case EffectIcon.Energy:
				rectangle = new Rectangle?(new Rectangle(0, 428, 10, 10));
				break;
			case EffectIcon.MaxEnergy:
				rectangle = new Rectangle?(new Rectangle(80, 428, 10, 10));
				break;
			case EffectIcon.Attack:
				rectangle = new Rectangle?(new Rectangle(120, 428, 10, 10));
				break;
			case EffectIcon.Defense:
				rectangle = new Rectangle?(new Rectangle(110, 428, 10, 10));
				break;
			case EffectIcon.CriticalHitRate:
				rectangle = new Rectangle?(new Rectangle(160, 428, 10, 10));
				break;
			case EffectIcon.Immunity:
				rectangle = new Rectangle?(new Rectangle(150, 428, 10, 10));
				break;
			case EffectIcon.Speed:
				rectangle = new Rectangle?(new Rectangle(130, 428, 10, 10));
				break;
			case EffectIcon.SaveFromDeath:
				rectangle = new Rectangle?(new Rectangle(140, 428, 10, 10));
				break;
			case EffectIcon.SkillFarming:
				rectangle = new Rectangle?(new Rectangle(10, 428, 10, 10));
				break;
			case EffectIcon.SkillFishing:
				rectangle = new Rectangle?(new Rectangle(20, 428, 10, 10));
				break;
			case EffectIcon.SkillForaging:
				rectangle = new Rectangle?(new Rectangle(60, 428, 10, 10));
				break;
			case EffectIcon.SkillMining:
				rectangle = new Rectangle?(new Rectangle(30, 428, 10, 10));
				break;
			case EffectIcon.SkillCombat:
				rectangle = new Rectangle?(new Rectangle(40, 428, 10, 10));
				break;
			case EffectIcon.SkillLuck:
				rectangle = new Rectangle?(new Rectangle(50, 428, 10, 10));
				break;
			case EffectIcon.Yoba:
				texture = EffectHelper.Textures.LooseSprites;
				rectangle = new Rectangle?(new Rectangle(10, 0, 10, 10));
				break;
			case EffectIcon.TreasureChest:
				rectangle = new Rectangle?(new Rectangle(137, 412, 10, 11));
				break;
			case EffectIcon.Animal_Chicken:
				Utility.drawWithShadow(spriteBatch, Game1.mouseCursors, new Vector2(location.X, location.Y + 5f), new Rectangle(0, 448, 32, 16), Color.White, 0f, Vector2.Zero, 1.2f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Animal_Cow:
				Utility.drawWithShadow(spriteBatch, Game1.mouseCursors, new Vector2(location.X, location.Y + 2f), new Rectangle(40, 449, 17, 14), Color.White, 0f, Vector2.Zero, 1.8f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Glow:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 63, 9, 9));
				break;
			case EffectIcon.Person_Lewis:
				Utility.drawWithShadow(spriteBatch, EffectHelper.Textures.LooseSprites, new Vector2(location.X, location.Y), new Rectangle(20, 0, 12, 13), Color.White, 0f, Vector2.Zero, 2f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Red:
				rectangle = new Rectangle?(new Rectangle(193, 373, 9, 9));
				break;
			case EffectIcon.Red2:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(0, 90, 9, 9));
				break;
			case EffectIcon.Blue:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 90, 9, 9));
				break;
			case EffectIcon.Yellow:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(18, 90, 9, 9));
				break;
			case EffectIcon.Fire:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(27, 90, 9, 9));
				break;
			case EffectIcon.Crown:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(108, 54, 9, 9));
				break;
			case EffectIcon.Iridium:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(99, 27, 9, 9));
				break;
			case EffectIcon.DustSprite:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 45, 9, 9));
				break;
			case EffectIcon.Stardrop:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(27, 54, 9, 9));
				break;
			case EffectIcon.Crab:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(72, 72, 9, 9));
				break;
			case EffectIcon.CandyCane:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(81, 54, 9, 9));
				break;
			case EffectIcon.Pumpkin:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(90, 54, 9, 9));
				break;
			case EffectIcon.Heart:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 27, 9, 9));
				break;
			case EffectIcon.Swirl:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(63, 27, 9, 9));
				break;
			case EffectIcon.Lightning:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(36, 63, 9, 9));
				break;
			case EffectIcon.Money:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(63, 36, 9, 9));
				break;
			case EffectIcon.Dwarf:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 117, 9, 9));
				break;
			case EffectIcon.Krobus:
				texture = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(0, 117, 9, 9));
				break;
			default:
				if (icon == EffectIcon.Clover)
				{
					texture = EffectHelper.Textures.Emojis;
					rectangle = new Rectangle?(new Rectangle(72, 81, 9, 9));
				}
				break;
			}
			if (rectangle != null)
			{
				Utility.drawWithShadow(spriteBatch, texture, location, rectangle.Value, Color.White, 0f, Vector2.Zero, 3f, false, 0.95f, -1, -1, 0.35f);
			}
		}
	}
}
