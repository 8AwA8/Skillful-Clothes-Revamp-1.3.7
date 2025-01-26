using System;
using StardewValley;

namespace SkillfulClothes.Types
{
	// Token: 0x02000029 RID: 41
	public static class SeasonExtensions
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00002C13 File Offset: 0x00000E13
		public static string GetEffectDescriptionSuffix(this Season season)
		{
			return EffectHelper.ModHelper.Translation.Get("Seas-" + season.ToString());
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00002C40 File Offset: 0x00000E40
		public static bool IsActive(this Season season)
		{
			return Game1.season.ToString().ToLower() == season.ToString().ToLower();
		}
	}
}
