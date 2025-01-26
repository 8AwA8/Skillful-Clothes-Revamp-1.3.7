using System;
using SkillfulClothes.Effects.Skills;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace SkillfulClothes.Patches
{
	// Token: 0x020000B1 RID: 177
	internal class CritBalance
	{
		// Token: 0x0600040F RID: 1039 RVA: 0x00004F75 File Offset: 0x00003175
		public static void Apply(IModHelper modHelper)
		{
			modHelper.Events.GameLoop.DayStarted += CritBalance.DayStart;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00004F93 File Offset: 0x00003193
		private static void DayStart(object sender, DayStartedEventArgs e)
		{
			new IncreaseCritDamage(-25).Apply(null, EffectChangeReason.DayStart);
		}
	}
}
