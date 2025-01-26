using System;

namespace SkillfulClothes.Types
{
	// Token: 0x0200002C RID: 44
	public class Shirt : AlphanumericItemId
	{
		// Token: 0x06000105 RID: 261 RVA: 0x00002C91 File Offset: 0x00000E91
		public Shirt(string itemId) : base(itemId, ClothingItemType.Shirt)
		{
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00002C9B File Offset: 0x00000E9B
		public static implicit operator Shirt(int value)
		{
			return new Shirt(value.ToString());
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00002CA9 File Offset: 0x00000EA9
		public static implicit operator Shirt(string value)
		{
			return new Shirt(value);
		}
	}
}
