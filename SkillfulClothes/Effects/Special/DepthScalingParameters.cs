using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000075 RID: 117
	public class DepthScalingParameters : IEffectParameters
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00003CEB File Offset: 0x00001EEB
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00003CF3 File Offset: 0x00001EF3
		public int recursiveFloors { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00003CFC File Offset: 0x00001EFC
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00003D04 File Offset: 0x00001F04
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x0600029C RID: 668 RVA: 0x00003D20 File Offset: 0x00001F20
		public static DepthScalingParameters With(int floors, IEffect actualEffect)
		{
			return new DepthScalingParameters
			{
				recursiveFloors = floors,
				Effect = actualEffect
			};
		}
	}
}
