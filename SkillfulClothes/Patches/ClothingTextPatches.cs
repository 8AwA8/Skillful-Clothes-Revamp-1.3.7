using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace SkillfulClothes.Patches
{
	// Token: 0x02000032 RID: 50
	internal static class ClothingTextPatches
	{
		// Token: 0x06000113 RID: 275 RVA: 0x00002D44 File Offset: 0x00000F44
		public static void Apply(IModHelper helper)
		{
			helper.Events.Content.AssetRequested += ClothingTextPatches.Content_AssetRequested;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00002D62 File Offset: 0x00000F62
		private static void Content_AssetRequested(object sender, AssetRequestedEventArgs e)
		{
			if (ClothingTextPatches.CanEdit(e.NameWithoutLocale.BaseName))
			{
				e.Edit(delegate(IAssetData assetData)
				{
					ClothingTextPatches.EditAsset(assetData);
				}, AssetEditPriority.Default, null);
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00002D9D File Offset: 0x00000F9D
		private static bool CanEdit(string assetNameWithoutLocale)
		{
			return assetNameWithoutLocale == "Data/ClothingInformation" || assetNameWithoutLocale == "Data/Hats";
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00008E8C File Offset: 0x0000708C
		private static void EditAsset(IAssetData asset)
		{
			IDictionary<int, string> data = asset.AsDictionary<int, string>().Data;
			if (asset.NameWithoutLocale.IsEquivalentTo("Data/ClothingInformation", false))
			{
				ClothingTextPatches.UpdateTexts<Shirt>(ItemDefinitions.ShirtEffects, data, 2);
				ClothingTextPatches.UpdateTexts<Pants>(ItemDefinitions.PantsEffects, data, 2);
				return;
			}
			ClothingTextPatches.UpdateTexts<Hat>(ItemDefinitions.HatEffects, data, 1);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00008EE0 File Offset: 0x000070E0
		private static void UpdateTexts<T>(Dictionary<T, ExtItemInfo> itemDefinitions, IDictionary<int, string> dict, int descriptionIndex)
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an Enum");
			}
			foreach (KeyValuePair<T, ExtItemInfo> keyValuePair in itemDefinitions)
			{
				int key = Convert.ToInt32(keyValuePair.Key);
				string text;
				if (keyValuePair.Value.ShouldDescriptionBePatched && dict.TryGetValue(key, out text))
				{
					string[] array = text.Split('/', StringSplitOptions.None);
					array[descriptionIndex] = keyValuePair.Value.NewItemDescription;
					dict[key] = string.Join("/", array);
				}
			}
		}

		// Token: 0x040001C7 RID: 455
		private const string clothingAssetName = "Data/ClothingInformation";

		// Token: 0x040001C8 RID: 456
		private const string hatAssetName = "Data/Hats";
	}
}
