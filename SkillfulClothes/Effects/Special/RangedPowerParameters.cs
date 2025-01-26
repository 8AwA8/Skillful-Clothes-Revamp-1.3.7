using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000083 RID: 131
	public class RangedPowerParameters : IEffectParameters
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000405E File Offset: 0x0000225E
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x00004066 File Offset: 0x00002266
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x060002E7 RID: 743 RVA: 0x0000406F File Offset: 0x0000226F
		public static RangedPowerParameters With(IEffect actualEffect)
		{
			return new RangedPowerParameters
			{
				Effect = actualEffect
			};
		}
	}
}
