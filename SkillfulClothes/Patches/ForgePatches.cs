using System;
using SkillfulClothes.Configuration;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Audio;
using StardewValley.Menus;
using StardewValley.Objects;

namespace SkillfulClothes.Patches
{
	// Token: 0x0200009B RID: 155
	internal class ForgePatches
	{
		// Token: 0x0600037A RID: 890 RVA: 0x00004942 File Offset: 0x00002B42
		public static void Apply(IModHelper modHelper)
		{
			modHelper.Events.GameLoop.OneSecondUpdateTicked += ForgePatches.TailorCheck;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00010BD0 File Offset: 0x0000EDD0
		private static void TailorCheck(object sender, OneSecondUpdateTickedEventArgs e)
		{
			if (Context.IsPlayerFree || !Context.IsWorldReady)
			{
				return;
			}
			TailoringMenu tailoringMenu = Game1.activeClickableMenu as TailoringMenu;
			if (tailoringMenu == null)
			{
				return;
			}
			if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().EnableClothingForge)
			{
				return;
			}
			if (tailoringMenu != null)
			{
				Farmer player = Game1.player;
				if (tailoringMenu.leftIngredientSpot.item != null)
				{
					return;
				}
				Item item = tailoringMenu.rightIngredientSpot.item;
				if (item != null)
				{
					if (item.TypeDefinitionId == "(S)" && player.shirtItem.Value != null)
					{
						Clothing clothing = item as Clothing;
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, SoundContext.Default);
						}
						player.shirtItem.Value.indexInTileSheet.Value = clothing.indexInTileSheet.Value;
						player.shirtItem.Value.clothesColor.Value = clothing.clothesColor.Value;
						Clothing value = player.shirtItem.Value;
						player.shirtItem.Value = null;
						player.shirtItem.Value = value;
					}
					else if (item.TypeDefinitionId == "(P)" && player.pantsItem.Value != null)
					{
						Clothing clothing2 = item as Clothing;
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, SoundContext.Default);
						}
						player.pantsItem.Value.indexInTileSheet.Value = clothing2.indexInTileSheet.Value;
						player.pantsItem.Value.clothesColor.Value = clothing2.clothesColor.Value;
					}
				}
				if (item != null && item.ItemId == "428")
				{
					int num = 0;
					if (player.shirtItem.Value != null && player.shirtItem.Value.indexInTileSheet.Value != (ItemRegistry.Create(player.shirtItem.Value.QualifiedItemId, 1, 0, true) as Clothing).indexInTileSheet.Value)
					{
						num++;
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("secret1", null, SoundContext.Default);
						}
						player.shirtItem.Value = (ItemRegistry.Create(player.shirtItem.Value.QualifiedItemId, 1, 0, true) as Clothing);
					}
					if (player.pantsItem.Value != null && player.pantsItem.Value.indexInTileSheet.Value != (ItemRegistry.Create(player.pantsItem.Value.QualifiedItemId, 1, 0, true) as Clothing).indexInTileSheet.Value)
					{
						num++;
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("secret1", null, SoundContext.Default);
						}
						player.pantsItem.Value = (ItemRegistry.Create(player.pantsItem.Value.QualifiedItemId, 1, 0, true) as Clothing);
					}
					if (num > 0)
					{
						tailoringMenu.SpendRightItem();
					}
				}
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00004960 File Offset: 0x00002B60
		public static bool CraftFix(TailoringMenu __instance)
		{
			if (__instance.heldItem != null && __instance.rightIngredientSpot.item == null && __instance.heldItem is Clothing)
			{
				__instance.rightIngredientSpot.item = __instance.heldItem;
				__instance.heldItem = null;
				return false;
			}
			return true;
		}
	}
}
