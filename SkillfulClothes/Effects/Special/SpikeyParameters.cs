using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000085 RID: 133
	public class SpikeyParameters : IEffectParameters
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00004130 File Offset: 0x00002330
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00004138 File Offset: 0x00002338
		public int ExtraDamage { get; set; }

		// Token: 0x060002F4 RID: 756 RVA: 0x00004141 File Offset: 0x00002341
		public static SpikeyParameters With(int damage)
		{
			return new SpikeyParameters
			{
				ExtraDamage = damage
			};
		}
	}
}
