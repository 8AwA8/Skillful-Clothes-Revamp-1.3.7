using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000053 RID: 83
	public class ShopDiscountParameters : IEffectParameters
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x000034EA File Offset: 0x000016EA
		// (set) Token: 0x060001BA RID: 442 RVA: 0x000034F2 File Offset: 0x000016F2
		public Shop Shop { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000034FB File Offset: 0x000016FB
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00003503 File Offset: 0x00001703
		public double Discount { get; set; }

		// Token: 0x060001BD RID: 445 RVA: 0x0000350C File Offset: 0x0000170C
		public static ShopDiscountParameters With(Shop shop, double discount)
		{
			return new ShopDiscountParameters
			{
				Shop = shop,
				Discount = discount
			};
		}
	}
}
