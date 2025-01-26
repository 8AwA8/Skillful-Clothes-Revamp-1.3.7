using System;

namespace SkillfulClothes.Types
{
	// Token: 0x02000022 RID: 34
	public class Hat : AlphanumericItemId
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00002B3F File Offset: 0x00000D3F
		public Hat(string itemId) : base(itemId, ClothingItemType.Hat)
		{
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00002B49 File Offset: 0x00000D49
		public static implicit operator Hat(int value)
		{
			return new Hat(value.ToString());
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00002B57 File Offset: 0x00000D57
		public static implicit operator Hat(string value)
		{
			return new Hat(value);
		}
	}
}
