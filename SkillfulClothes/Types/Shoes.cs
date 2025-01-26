using System;

namespace SkillfulClothes.Types
{
	// Token: 0x020000BC RID: 188
	public class Shoes : AlphanumericItemId
	{
		// Token: 0x0600045A RID: 1114 RVA: 0x00005326 File Offset: 0x00003526
		public Shoes(string itemId) : base(itemId, ClothingItemType.Shoes)
		{
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00005330 File Offset: 0x00003530
		public static implicit operator Shoes(int value)
		{
			return new Shoes(value.ToString());
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0000533E File Offset: 0x0000353E
		public static implicit operator Shoes(string value)
		{
			return new Shoes(value);
		}
	}
}
