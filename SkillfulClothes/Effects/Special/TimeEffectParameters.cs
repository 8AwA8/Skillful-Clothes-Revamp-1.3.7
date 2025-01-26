using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009E RID: 158
	public class TimeEffectParameters : IEffectParameters
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00004A82 File Offset: 0x00002C82
		// (set) Token: 0x0600038F RID: 911 RVA: 0x00004A8A File Offset: 0x00002C8A
		public int timeStart { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00004A93 File Offset: 0x00002C93
		// (set) Token: 0x06000391 RID: 913 RVA: 0x00004A9B File Offset: 0x00002C9B
		public int timeEnd { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00004AA4 File Offset: 0x00002CA4
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00004AAC File Offset: 0x00002CAC
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x06000394 RID: 916 RVA: 0x00004AB5 File Offset: 0x00002CB5
		public static TimeEffectParameters With(int timeStart, int timeEnd, IEffect actualEffect)
		{
			return new TimeEffectParameters
			{
				timeStart = timeStart,
				timeEnd = timeEnd,
				Effect = actualEffect
			};
		}
	}
}
