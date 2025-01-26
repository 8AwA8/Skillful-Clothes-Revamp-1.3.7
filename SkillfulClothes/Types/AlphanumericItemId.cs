using System;

namespace SkillfulClothes.Types
{
	// Token: 0x02000017 RID: 23
	public class AlphanumericItemId
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00002903 File Offset: 0x00000B03
		public ClothingItemType ItemType { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x0000290B File Offset: 0x00000B0B
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00002913 File Offset: 0x00000B13
		public string ItemName { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000291C File Offset: 0x00000B1C
		public string ItemId { get; }

		// Token: 0x060000C3 RID: 195 RVA: 0x00002924 File Offset: 0x00000B24
		public AlphanumericItemId(string itemId, ClothingItemType itemType = ClothingItemType.Undefined)
		{
			this.ItemId = itemId;
			this.ItemType = itemType;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00006F24 File Offset: 0x00005124
		public override bool Equals(object obj)
		{
			AlphanumericItemId other = obj as AlphanumericItemId;
			return other != null && this.ItemType == other.ItemType && this.ItemId == other.ItemId;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000293A File Offset: 0x00000B3A
		public override int GetHashCode()
		{
			return this.ItemId.GetHashCode();
		}
	}
}
