using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004D RID: 77
	public class LocationalEffectParameters : IEffectParameters
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000328A File Offset: 0x0000148A
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00003292 File Offset: 0x00001492
		public LocationGroup Location { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000329B File Offset: 0x0000149B
		// (set) Token: 0x06000193 RID: 403 RVA: 0x000032A3 File Offset: 0x000014A3
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x06000194 RID: 404 RVA: 0x000032AC File Offset: 0x000014AC
		public static LocationalEffectParameters With(LocationGroup location, IEffect actualEffect)
		{
			return new LocationalEffectParameters
			{
				Location = location,
				Effect = actualEffect
			};
		}
	}
}
