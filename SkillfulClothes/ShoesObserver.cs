using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Objects;

namespace SkillfulClothes
{
	// Token: 0x020000BD RID: 189
	internal class ShoesObserver : EquippedClothingItemObserver<Shoes>
	{
		// Token: 0x0600045D RID: 1117 RVA: 0x0001611C File Offset: 0x0001431C
		protected override string GetCurrentItemId(Farmer farmer)
		{
			Boots value = farmer.boots.Value;
			return ((value != null) ? value.ItemId : null) ?? null;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00005346 File Offset: 0x00003546
		protected override Item GetCurrentItem(Farmer farmer)
		{
			return farmer.boots.Value;
		}
	}
}
