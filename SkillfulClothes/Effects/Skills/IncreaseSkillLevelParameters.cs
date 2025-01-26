using System;
using SkillfulClothes.Effects.SharedParameters;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200005B RID: 91
	public class IncreaseSkillLevelParameters : AmountEffectParameters
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x000035F8 File Offset: 0x000017F8
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00003600 File Offset: 0x00001800
		public Skill Skill { get; set; }

		// Token: 0x060001E3 RID: 483 RVA: 0x00003609 File Offset: 0x00001809
		public static IncreaseSkillLevelParameters With(Skill skill, int amount)
		{
			return new IncreaseSkillLevelParameters
			{
				Skill = skill,
				Amount = amount
			};
		}
	}
}
