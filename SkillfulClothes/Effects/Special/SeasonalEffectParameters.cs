using System;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000051 RID: 81
	public class SeasonalEffectParameters : IEffectParameters
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00003450 File Offset: 0x00001650
		// (set) Token: 0x060001AE RID: 430 RVA: 0x00003458 File Offset: 0x00001658
		public Season Season { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00003461 File Offset: 0x00001661
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00003469 File Offset: 0x00001669
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x060001B1 RID: 433 RVA: 0x00003472 File Offset: 0x00001672
		public static SeasonalEffectParameters With(Season season, IEffect actualEffect)
		{
			return new SeasonalEffectParameters
			{
				Season = season,
				Effect = actualEffect
			};
		}
	}
}
