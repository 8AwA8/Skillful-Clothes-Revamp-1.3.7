using System;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Types
{
	// Token: 0x0200001F RID: 31
	public class ExtendItem
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00002A7D File Offset: 0x00000C7D
		public static ExtendItem With
		{
			get
			{
				return new ExtendItem();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00002A84 File Offset: 0x00000C84
		public ExtendItem And
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002A87 File Offset: 0x00000C87
		public ExtendItem Description(string newDescription)
		{
			this.newItemDescription = newDescription;
			return this;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002A91 File Offset: 0x00000C91
		public ExtendItem Effect(params IEffect[] effects)
		{
			if (effects.Length == 1)
			{
				this.effect = effects[0];
			}
			else if (effects.Length > 1)
			{
				this.effect = EffectSet.Of(effects);
			}
			else
			{
				this.effect = null;
			}
			return this;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00002AC0 File Offset: 0x00000CC0
		public ExtendItem SoldBy(Shop shop, int price, SellingCondition sellingCondition = SellingCondition.None)
		{
			this.soldBy = shop;
			this.price = price;
			this.sellingCondition = sellingCondition;
			return this;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public ExtendItem CannotBeCrafted
		{
			get
			{
				this.cannotCraft = true;
				return this;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00002AE2 File Offset: 0x00000CE2
		public static implicit operator ExtItemInfo(ExtendItem item)
		{
			return new ExtItemInfo(item.newItemDescription, item.cannotCraft, item.effect, item.soldBy, item.price, item.sellingCondition);
		}

		// Token: 0x0400004D RID: 77
		private bool cannotCraft;

		// Token: 0x0400004E RID: 78
		private string newItemDescription;

		// Token: 0x0400004F RID: 79
		private IEffect effect;

		// Token: 0x04000050 RID: 80
		private Shop soldBy = Shop.None;

		// Token: 0x04000051 RID: 81
		private int price;

		// Token: 0x04000052 RID: 82
		private SellingCondition sellingCondition;
	}
}
