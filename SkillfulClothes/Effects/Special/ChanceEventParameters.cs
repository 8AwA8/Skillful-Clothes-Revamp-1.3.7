using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000BA RID: 186
	public class ChanceEventParameters : IEffectParameters
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x000052A7 File Offset: 0x000034A7
		// (set) Token: 0x0600044D RID: 1101 RVA: 0x000052AF File Offset: 0x000034AF
		public int Chance { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x000052B8 File Offset: 0x000034B8
		// (set) Token: 0x0600044F RID: 1103 RVA: 0x000052C0 File Offset: 0x000034C0
		public int Code { get; set; }

		// Token: 0x06000450 RID: 1104 RVA: 0x000052C9 File Offset: 0x000034C9
		public static ChanceEventParameters With(int chance, int code)
		{
			return new ChanceEventParameters
			{
				Chance = chance,
				Code = code
			};
		}
	}
}
