using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000070 RID: 112
	public class WeatherEffectParameters : IEffectParameters
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00003B6D File Offset: 0x00001D6D
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00003B75 File Offset: 0x00001D75
		public WeatherGroup Weather { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00003B7E File Offset: 0x00001D7E
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00003B86 File Offset: 0x00001D86
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x06000281 RID: 641 RVA: 0x00003B8F File Offset: 0x00001D8F
		public static WeatherEffectParameters With(WeatherGroup weather, IEffect actualEffect)
		{
			return new WeatherEffectParameters
			{
				Weather = weather,
				Effect = actualEffect
			};
		}
	}
}
