using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B4 RID: 180
	public class IncreasePopularityParameters : IEffectParameters
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00005007 File Offset: 0x00003207
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x0000500F File Offset: 0x0000320F
		public int Amount { get; set; }

		// Token: 0x06000422 RID: 1058 RVA: 0x00005018 File Offset: 0x00003218
		public static IncreasePopularityParameters With(int Amount)
		{
			return new IncreasePopularityParameters
			{
				Amount = Amount
			};
		}
	}
}
