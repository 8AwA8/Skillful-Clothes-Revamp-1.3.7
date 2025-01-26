using System;

namespace SkillfulClothes.Types
{
	// Token: 0x02000028 RID: 40
	public class Pants : AlphanumericItemId
	{
		// Token: 0x060000FB RID: 251 RVA: 0x00002BF3 File Offset: 0x00000DF3
		public Pants(string itemId) : base(itemId, ClothingItemType.Pants)
		{
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00002BFD File Offset: 0x00000DFD
		public static implicit operator Pants(int value)
		{
			return new Pants(value.ToString());
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00002C0B File Offset: 0x00000E0B
		public static implicit operator Pants(string value)
		{
			return new Pants(value);
		}
	}
}
