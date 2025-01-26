using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SkillfulClothes.Types
{
	// Token: 0x020000BE RID: 190
	public static class KnownShoes
	{
		// Token: 0x06000460 RID: 1120 RVA: 0x00016148 File Offset: 0x00014348
		static KnownShoes()
		{
			foreach (FieldInfo fieldInfo in from x in typeof(KnownShoes).GetFields(BindingFlags.Static | BindingFlags.Public)
			where x.FieldType == typeof(Shoes)
			select x)
			{
				Shoes shoes = fieldInfo.GetValue(null) as Shoes;
				shoes.ItemName = fieldInfo.Name;
				KnownShoes.lut_ids.Add(shoes.ItemId, shoes);
				KnownShoes.lut_names.Add(shoes.ItemName, shoes);
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00016318 File Offset: 0x00014518
		public static Shoes GetById(string itemId)
		{
			if (itemId == null)
			{
				return KnownShoes.None;
			}
			Shoes result;
			if (KnownShoes.lut_ids.TryGetValue(itemId, out result) || KnownShoes.lut_names.TryGetValue(itemId, out result))
			{
				return result;
			}
			return new Shoes(itemId)
			{
				ItemName = itemId
			};
		}

		// Token: 0x040002EC RID: 748
		public static Shoes None = -1;

		// Token: 0x040002ED RID: 749
		public static Shoes Sneakers = 504;

		// Token: 0x040002EE RID: 750
		public static Shoes RubberBoots = 505;

		// Token: 0x040002EF RID: 751
		public static Shoes LeatherBoots = 506;

		// Token: 0x040002F0 RID: 752
		public static Shoes WorkBoots = 507;

		// Token: 0x040002F1 RID: 753
		public static Shoes CombatBoots = 508;

		// Token: 0x040002F2 RID: 754
		public static Shoes TundraBoots = 509;

		// Token: 0x040002F3 RID: 755
		public static Shoes ThermalBoots = 510;

		// Token: 0x040002F4 RID: 756
		public static Shoes DarkBoots = 511;

		// Token: 0x040002F5 RID: 757
		public static Shoes FirewalkerBoots = 512;

		// Token: 0x040002F6 RID: 758
		public static Shoes GenieShoes = 513;

		// Token: 0x040002F7 RID: 759
		public static Shoes SpaceBoots = 514;

		// Token: 0x040002F8 RID: 760
		public static Shoes CowboyBoots = 515;

		// Token: 0x040002F9 RID: 761
		public static Shoes EmilysMagicBoots = 804;

		// Token: 0x040002FA RID: 762
		public static Shoes LeprechaunShoes = 806;

		// Token: 0x040002FB RID: 763
		public static Shoes CinderclownShoes = 853;

		// Token: 0x040002FC RID: 764
		public static Shoes MermaidBoots = 854;

		// Token: 0x040002FD RID: 765
		public static Shoes DragonscaleBoots = 855;

		// Token: 0x040002FE RID: 766
		public static Shoes PrismaticGenieShoes = 878;

		// Token: 0x040002FF RID: 767
		private static Dictionary<string, Shoes> lut_ids = new Dictionary<string, Shoes>();

		// Token: 0x04000300 RID: 768
		private static Dictionary<string, Shoes> lut_names = new Dictionary<string, Shoes>();
	}
}
