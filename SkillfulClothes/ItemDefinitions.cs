using System;
using System.Collections.Generic;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Objects;

namespace SkillfulClothes
{
	// Token: 0x02000012 RID: 18
	public class ItemDefinitions
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00005FB0 File Offset: 0x000041B0
		public static bool GetEffect(Item item, out IEffect effect)
		{
			ExtItemInfo extItemInfo = null;
			Clothing clothing = item as Clothing;
			if (clothing != null)
			{
				if (clothing.clothesType.Value == Clothing.ClothesType.SHIRT)
				{
					ItemDefinitions.GetExtInfoByItemId<Shirt>(item.ItemId, out extItemInfo);
				}
				else if (clothing.clothesType.Value == Clothing.ClothesType.PANTS)
				{
					ItemDefinitions.GetExtInfoByItemId<Pants>(item.ItemId, out extItemInfo);
				}
			}
			else
			{
				StardewValley.Objects.Hat hat = item as StardewValley.Objects.Hat;
				if (hat != null)
				{
					ItemDefinitions.GetExtInfoByItemId<SkillfulClothes.Types.Hat>(hat.ItemId, out extItemInfo);
				}
				else
				{
					Boots boots = item as Boots;
					if (boots != null)
					{
						ItemDefinitions.GetExtInfoByItemId<Shoes>(boots.ItemId, out extItemInfo);
					}
				}
			}
			effect = ((extItemInfo != null) ? extItemInfo.Effect : null);
			return effect != null;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000604C File Offset: 0x0000424C
		public static bool GetEffectByItemId<T>(string itemId, out IEffect effect)
		{
			ExtItemInfo extItemInfo;
			if (itemId != null && ItemDefinitions.GetExtInfoByItemId<T>(itemId, out extItemInfo))
			{
				effect = extItemInfo.Effect;
			}
			else
			{
				effect = null;
			}
			return effect != null;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006078 File Offset: 0x00004278
		public static bool GetExtInfo(Item item, out ExtItemInfo extInfo)
		{
			Clothing clothing = item as Clothing;
			if (clothing != null)
			{
				if (clothing.clothesType.Value == Clothing.ClothesType.SHIRT)
				{
					return ItemDefinitions.GetExtInfoByItemId<Shirt>(item.ItemId, out extInfo);
				}
				if (clothing.clothesType.Value == Clothing.ClothesType.PANTS)
				{
					return ItemDefinitions.GetExtInfoByItemId<Pants>(item.ItemId, out extInfo);
				}
			}
			else
			{
				StardewValley.Objects.Hat hat = item as StardewValley.Objects.Hat;
				if (hat != null)
				{
					return ItemDefinitions.GetExtInfoByItemId<SkillfulClothes.Types.Hat>(hat.ItemId, out extInfo);
				}
				Boots boots = item as Boots;
				if (boots != null)
				{
					return ItemDefinitions.GetExtInfoByItemId<Shoes>(boots.ItemId, out extInfo);
				}
			}
			extInfo = null;
			return false;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000060F8 File Offset: 0x000042F8
		public static bool GetExtInfo<T>(T value, out ExtItemInfo extInfo)
		{
			Shirt shirt = value as Shirt;
			if (shirt != null)
			{
				return ItemDefinitions.ShirtEffects.TryGetValue(shirt, out extInfo);
			}
			Pants pants = value as Pants;
			if (pants != null)
			{
				return ItemDefinitions.PantsEffects.TryGetValue(pants, out extInfo);
			}
			SkillfulClothes.Types.Hat hat = value as SkillfulClothes.Types.Hat;
			if (hat != null)
			{
				return ItemDefinitions.HatEffects.TryGetValue(hat, out extInfo);
			}
			Shoes shoes = value as Shoes;
			if (shoes != null)
			{
				return ItemDefinitions.ShoesEffects.TryGetValue(shoes, out extInfo);
			}
			extInfo = null;
			return false;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000617C File Offset: 0x0000437C
		public static bool GetExtInfoByItemId<T>(string itemId, out ExtItemInfo extInfo)
		{
			if (itemId != null)
			{
				if (typeof(T) == typeof(Shirt))
				{
					return ItemDefinitions.ShirtEffects.TryGetValue(itemId, out extInfo);
				}
				if (typeof(T) == typeof(Pants))
				{
					return ItemDefinitions.PantsEffects.TryGetValue(itemId, out extInfo);
				}
				if (typeof(T) == typeof(SkillfulClothes.Types.Hat))
				{
					return ItemDefinitions.HatEffects.TryGetValue(itemId, out extInfo);
				}
				if (typeof(T) == typeof(Shoes))
				{
					return ItemDefinitions.ShoesEffects.TryGetValue(itemId, out extInfo);
				}
			}
			extInfo = null;
			return false;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00006248 File Offset: 0x00004448
		public static T GetKnownItemById<T>(string itemId) where T : AlphanumericItemId
		{
			if (itemId == null)
			{
				if (typeof(T) == typeof(Shirt))
				{
					return KnownShirts.None as T;
				}
				if (typeof(T) == typeof(Pants))
				{
					return KnownPants.None as T;
				}
				if (typeof(T) == typeof(SkillfulClothes.Types.Hat))
				{
					return KnownHats.None as T;
				}
				if (typeof(T) == typeof(Shoes))
				{
					return KnownShoes.None as T;
				}
			}
			if (typeof(T) == typeof(Shirt))
			{
				return KnownShirts.GetById(itemId) as T;
			}
			if (typeof(T) == typeof(Pants))
			{
				return KnownPants.GetById(itemId) as T;
			}
			if (typeof(T) == typeof(SkillfulClothes.Types.Hat))
			{
				return KnownHats.GetById(itemId) as T;
			}
			if (typeof(T) == typeof(Shoes))
			{
				return KnownShoes.GetById(itemId) as T;
			}
			return default(T);
		}

		// Token: 0x04000023 RID: 35
		public static Dictionary<Shirt, ExtItemInfo> ShirtEffects = new Dictionary<Shirt, ExtItemInfo>();

		// Token: 0x04000024 RID: 36
		public static Dictionary<Pants, ExtItemInfo> PantsEffects = new Dictionary<Pants, ExtItemInfo>();

		// Token: 0x04000025 RID: 37
		public static Dictionary<SkillfulClothes.Types.Hat, ExtItemInfo> HatEffects = new Dictionary<SkillfulClothes.Types.Hat, ExtItemInfo>();

		// Token: 0x04000026 RID: 38
		public static Dictionary<Shoes, ExtItemInfo> ShoesEffects = new Dictionary<Shoes, ExtItemInfo>();
	}
}
