using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000047 RID: 71
	public class ConstructDiscountParameters : IEffectParameters
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600016C RID: 364 RVA: 0x000030B3 File Offset: 0x000012B3
		// (set) Token: 0x0600016D RID: 365 RVA: 0x000030BB File Offset: 0x000012BB
		public double Discount { get; set; }

		// Token: 0x0600016E RID: 366 RVA: 0x000030C4 File Offset: 0x000012C4
		public static ConstructDiscountParameters With(double discount)
		{
			return new ConstructDiscountParameters
			{
				Discount = discount
			};
		}
	}
}
