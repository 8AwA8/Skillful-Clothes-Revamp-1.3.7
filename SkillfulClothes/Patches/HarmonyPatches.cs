using System;
using System.Reflection;
using HarmonyLib;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;
using StardewValley.Tools;

namespace SkillfulClothes.Patches
{
	// Token: 0x02000034 RID: 52
	internal class HarmonyPatches
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00002DCD File Offset: 0x00000FCD
		private static Clothing ShimTrimmedLuckPurpleShorts
		{
			get
			{
				if (HarmonyPatches.shimTrimmedLuckPurpleShorts == null)
				{
					HarmonyPatches.shimTrimmedLuckPurpleShorts = new Clothing(KnownPants.TrimmedLuckyPurpleShorts.ItemId);
				}
				return HarmonyPatches.shimTrimmedLuckPurpleShorts;
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00008F9C File Offset: 0x0000719C
		public static void Apply(string modId)
		{
			Harmony harmony = new Harmony(modId);
			harmony.Patch(AccessTools.Method(typeof(Item), "getDescriptionWidth", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "getDescriptionWidth", null), null, null);
			harmony.Patch(typeof(IClickableMenu).GetMethod("drawToolTip", BindingFlags.Static | BindingFlags.Public), new HarmonyMethod(typeof(HarmonyPatches), "drawToolTip", null), null, null, null);
			harmony.Patch(AccessTools.Method(typeof(Farmer), "isWearingRing", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "isWearingRing", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(NPC), "checkAction", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "NPC_checkAction", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Farmer), "takeDamage", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "Farmer_TakeDamage", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Item), "onEquip", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "FarmTextureChanged", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Item), "onUnequip", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "FarmTextureChanged", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Item), "onDetachedFromParent", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "FarmTextureChanged", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(MeleeWeapon), "doDefenseSwordFunction", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "AbilityUsed", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(TailoringMenu), "_rightIngredientSpotClicked", null, null), new HarmonyMethod(typeof(ForgePatches), "CraftFix", null), null, null, null);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000091C0 File Offset: 0x000073C0
		private static void drawToolTip(ref Item hoveredItem)
		{
			if (hoveredItem != null && hoveredItem.Category == 0 && hoveredItem.QualifiedItemId == "(O)71")
			{
				hoveredItem = HarmonyPatches.ShimTrimmedLuckPurpleShorts;
			}
			IEffect effect;
			if (ItemDefinitions.GetEffect(hoveredItem, out effect))
			{
				Clothing clothing = hoveredItem as Clothing;
				if (clothing != null)
				{
					HarmonyPatches.clothingDrawWrapper.Assign(clothing, effect);
					hoveredItem = HarmonyPatches.clothingDrawWrapper;
					return;
				}
				Boots boots = hoveredItem as Boots;
				if (boots != null)
				{
					HarmonyPatches.shoesDrawWrapper.Assign(boots, effect);
					hoveredItem = HarmonyPatches.shoesDrawWrapper;
					return;
				}
				StardewValley.Objects.Hat hat = hoveredItem as StardewValley.Objects.Hat;
				if (hat != null)
				{
					HarmonyPatches.hatDrawWrapper.Assign(hat, effect);
					hoveredItem = HarmonyPatches.hatDrawWrapper;
				}
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000925C File Offset: 0x0000745C
		private static int getDescriptionWidth(int __result, Item __instance)
		{
			IEffect effect;
			if (ItemDefinitions.GetEffect(__instance, out effect))
			{
				return Math.Max(__result, EffectHelper.getDescriptionWidth(effect));
			}
			return __result;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00002DEF File Offset: 0x00000FEF
		private static bool isWearingRing(bool __result, string itemId)
		{
			return __result || EffectHelper.ClothingObserver.HasRingEffect(itemId);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00002E01 File Offset: 0x00001001
		private static void NPC_checkAction(bool __result, NPC __instance)
		{
			if (__result)
			{
				EffectHelper.Events.RaiseInteractedWithNPC(__instance);
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00002E31 File Offset: 0x00001031
		private static void Farmer_TakeDamage(Farmer __instance)
		{
			EffectHelper.Events.RaiseFarmerDamaged(__instance);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00009284 File Offset: 0x00007484
		private static void FarmTextureChanged(Item __instance)
		{
			if (__instance.TypeDefinitionId == "(H)" || __instance.TypeDefinitionId == "(S)" || __instance.TypeDefinitionId == "(P)" || __instance.TypeDefinitionId == "(B)")
			{
				EffectHelper.Events.RaiseClothingChanged();
				return;
			}
			EffectHelper.Events.RaiseEquipChange();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00002E3E File Offset: 0x0000103E
		private static void AbilityUsed()
		{
			EffectHelper.Events.RaiseSpecialUsed();
		}

		// Token: 0x040001CB RID: 459
		private static HatDrawWrapper hatDrawWrapper = new HatDrawWrapper();

		// Token: 0x040001CC RID: 460
		private static ClothingDrawWrapper clothingDrawWrapper = new ClothingDrawWrapper();

		// Token: 0x040001CD RID: 461
		private static FieldInfo craftStateFieldInfo;

		// Token: 0x040001CE RID: 462
		private static FieldInfo craftDisplayedDescriptionFieldInfo;

		// Token: 0x040001CF RID: 463
		private static Clothing shimTrimmedLuckPurpleShorts;

		// Token: 0x040001D0 RID: 464
		private static ShoesDrawWrapper shoesDrawWrapper = new ShoesDrawWrapper();
	}
}
