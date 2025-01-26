using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.SharedParameters
{
	// Token: 0x0200005D RID: 93
	public class AmountEffectParameters : IEffectParameters
	{
		// Token: 0x060001EB RID: 491 RVA: 0x00003654 File Offset: 0x00001854
		public static AmountEffectParameters With(int amount)
		{
			return new AmountEffectParameters
			{
				Amount = amount
			};
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00003662 File Offset: 0x00001862
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0000366A File Offset: 0x0000186A
		public int Amount { get; set; } = 1;
	}
}
