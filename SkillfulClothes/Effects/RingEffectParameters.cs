using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000040 RID: 64
	public class RingEffectParameters : IEffectParameters
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00002F6B File Offset: 0x0000116B
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00002F73 File Offset: 0x00001173
		public RingType Ring { get; set; }

		// Token: 0x06000155 RID: 341 RVA: 0x00002F7C File Offset: 0x0000117C
		public static RingEffectParameters With(RingType ring)
		{
			return new RingEffectParameters
			{
				Ring = ring
			};
		}
	}
}
