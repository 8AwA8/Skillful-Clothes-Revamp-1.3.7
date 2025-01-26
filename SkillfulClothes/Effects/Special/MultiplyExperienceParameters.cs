using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004F RID: 79
	public class MultiplyExperienceParameters : IEffectParameters
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00003324 File Offset: 0x00001524
		// (set) Token: 0x0600019D RID: 413 RVA: 0x0000332C File Offset: 0x0000152C
		public Skill Skill { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00003335 File Offset: 0x00001535
		// (set) Token: 0x0600019F RID: 415 RVA: 0x0000333D File Offset: 0x0000153D
		public float Multiplier { get; set; } = 1.2f;

		// Token: 0x060001A0 RID: 416 RVA: 0x00003346 File Offset: 0x00001546
		public static MultiplyExperienceParameters With(Skill skill, float multiplier)
		{
			return new MultiplyExperienceParameters
			{
				Skill = skill,
				Multiplier = multiplier
			};
		}
	}
}
