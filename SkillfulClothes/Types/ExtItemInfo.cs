using System;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Types
{
	// Token: 0x0200001E RID: 30
	public class ExtItemInfo
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000029FF File Offset: 0x00000BFF
		public bool ShouldDescriptionBePatched
		{
			get
			{
				return !string.IsNullOrEmpty(this.NewItemDescription);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00002A0F File Offset: 0x00000C0F
		public string NewItemDescription { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00002A17 File Offset: 0x00000C17
		public bool IsCraftingDisabled { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00002A1F File Offset: 0x00000C1F
		public Shop SoldBy { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00002A27 File Offset: 0x00000C27
		public int Price { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00002A2F File Offset: 0x00000C2F
		public SellingCondition SellingCondition { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00002A37 File Offset: 0x00000C37
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00002A3F File Offset: 0x00000C3F
		public IEffect Effect { get; private set; }

		// Token: 0x060000DA RID: 218 RVA: 0x00002A48 File Offset: 0x00000C48
		internal ExtItemInfo(string newDescription, bool disableCrafting, IEffect effect, Shop soldBy, int price, SellingCondition sellingCondition)
		{
			this.NewItemDescription = newDescription;
			this.IsCraftingDisabled = disableCrafting;
			this.Effect = effect;
			this.SoldBy = soldBy;
			this.Price = price;
			this.SellingCondition = sellingCondition;
		}
	}
}
