using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x0200005F RID: 95
	public class AttributeRegenParameters : IEffectParameters
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x000036A1 File Offset: 0x000018A1
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x000036A9 File Offset: 0x000018A9
		public int SecondsToStandStill { get; set; } = 1;

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001FA RID: 506 RVA: 0x000036B2 File Offset: 0x000018B2
		// (set) Token: 0x060001FB RID: 507 RVA: 0x000036BA File Offset: 0x000018BA
		public int RegenIntervalSeconds { get; set; } = 1;

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001FC RID: 508 RVA: 0x000036C3 File Offset: 0x000018C3
		// (set) Token: 0x060001FD RID: 509 RVA: 0x000036CB File Offset: 0x000018CB
		public int RegenAmount { get; set; } = 10;

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001FE RID: 510 RVA: 0x000036D4 File Offset: 0x000018D4
		// (set) Token: 0x060001FF RID: 511 RVA: 0x000036DC File Offset: 0x000018DC
		public Color GlowColor { get; set; } = Color.Green;

		// Token: 0x06000201 RID: 513 RVA: 0x0000370E File Offset: 0x0000190E
		public static AttributeRegenParameters With(Color glowColor, int secondsToStandStill, int regenIntervalSeconds = 1, int regenAmount = 1)
		{
			return new AttributeRegenParameters
			{
				GlowColor = glowColor,
				SecondsToStandStill = secondsToStandStill,
				RegenIntervalSeconds = regenIntervalSeconds,
				RegenAmount = regenAmount
			};
		}
	}
}
