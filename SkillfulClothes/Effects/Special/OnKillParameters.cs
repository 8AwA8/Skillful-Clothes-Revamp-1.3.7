using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000089 RID: 137
	public class OnKillParameters : IEffectParameters
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600030B RID: 779 RVA: 0x000042A9 File Offset: 0x000024A9
		// (set) Token: 0x0600030C RID: 780 RVA: 0x000042B1 File Offset: 0x000024B1
		public int UniqueEff { get; set; }

		// Token: 0x0600030D RID: 781 RVA: 0x000042BA File Offset: 0x000024BA
		public static OnKillParameters With(int effectCode, int amount)
		{
			return new OnKillParameters
			{
				UniqueEff = effectCode,
				Amount = amount
			};
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000042CF File Offset: 0x000024CF
		// (set) Token: 0x0600030F RID: 783 RVA: 0x000042D7 File Offset: 0x000024D7
		public int Amount { get; set; }
	}
}
