using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008E RID: 142
	public class SappingParameters : IEffectParameters
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00004460 File Offset: 0x00002660
		// (set) Token: 0x0600032A RID: 810 RVA: 0x00004468 File Offset: 0x00002668
		public int Chance { get; set; }

		// Token: 0x0600032B RID: 811 RVA: 0x00004471 File Offset: 0x00002671
		public static SappingParameters With(int chance)
		{
			return new SappingParameters
			{
				Chance = chance
			};
		}
	}
}
