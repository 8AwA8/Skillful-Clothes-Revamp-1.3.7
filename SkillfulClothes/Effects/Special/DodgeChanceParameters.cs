using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200007F RID: 127
	public class DodgeChanceParameters : IEffectParameters
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00003ED6 File Offset: 0x000020D6
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00003EDE File Offset: 0x000020DE
		public int Chance { get; set; }

		// Token: 0x060002D0 RID: 720 RVA: 0x00003EE7 File Offset: 0x000020E7
		public static DodgeChanceParameters With(int chance)
		{
			return new DodgeChanceParameters
			{
				Chance = chance
			};
		}
	}
}
