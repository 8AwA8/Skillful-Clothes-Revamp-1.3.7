using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008B RID: 139
	public class BaitProduceParameters : IEffectParameters
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000318 RID: 792 RVA: 0x00004348 File Offset: 0x00002548
		// (set) Token: 0x06000319 RID: 793 RVA: 0x00004350 File Offset: 0x00002550
		public int Steps { get; set; }

		// Token: 0x0600031A RID: 794 RVA: 0x00004359 File Offset: 0x00002559
		public static BaitProduceParameters With(int steps)
		{
			return new BaitProduceParameters
			{
				Steps = steps
			};
		}
	}
}
