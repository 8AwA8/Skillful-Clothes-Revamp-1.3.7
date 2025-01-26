using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000087 RID: 135
	public class NapalmParameters : IEffectParameters
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00004202 File Offset: 0x00002402
		// (set) Token: 0x060002FF RID: 767 RVA: 0x0000420A File Offset: 0x0000240A
		public int ExtraDamage { get; set; }

		// Token: 0x06000300 RID: 768 RVA: 0x00004213 File Offset: 0x00002413
		public static NapalmParameters With(int damage)
		{
			return new NapalmParameters
			{
				ExtraDamage = damage
			};
		}
	}
}
