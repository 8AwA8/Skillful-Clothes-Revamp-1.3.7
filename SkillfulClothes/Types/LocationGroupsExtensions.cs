using System;
using System.Collections.Generic;
using StardewValley;
using StardewValley.Locations;

namespace SkillfulClothes.Types
{
	// Token: 0x02000025 RID: 37
	public static class LocationGroupsExtensions
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x000076B4 File Offset: 0x000058B4
		public static string GetEffectDescriptionSuffix(this LocationGroup location)
		{
			if (location == LocationGroup.DesertPlaces)
			{
				return EffectHelper.ModHelper.Translation.Get("LOC-Des");
			}
			if (location == LocationGroup.FarmPlaces)
			{
				return EffectHelper.ModHelper.Translation.Get("LOC-Farm");
			}
			if (location == LocationGroup.WaterPlaces)
			{
				return EffectHelper.ModHelper.Translation.Get("LOC-Water");
			}
			if (location == LocationGroup.IslandPlaces)
			{
				return EffectHelper.ModHelper.Translation.Get("LOC-Island");
			}
			if (location == LocationGroup.UndergroundPlaces)
			{
				return EffectHelper.ModHelper.Translation.Get("LOC-Under");
			}
			if (location == LocationGroup.DangerousMines)
			{
				return EffectHelper.ModHelper.Translation.Get("LOC-Danger");
			}
			return "";
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000777C File Offset: 0x0000597C
		static LocationGroupsExtensions()
		{
			LocationGroupsExtensions.islandLocationNames = new HashSet<string>
			{
				"islandsouth",
				"islandsoutheast",
				"islandsoutheastcave",
				"islandeast",
				"islandwest",
				"islandnorth",
				"islandhut",
				"islandwestcavel",
				"islandnorthcavel",
				"islandfieldoffice",
				"islandfarmhouse",
				"captainroom",
				"islandshrine",
				"islandfarmcave",
				"caldera",
				"leotreehouse",
				"qinutroom"
			};
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000079FC File Offset: 0x00005BFC
		public static bool IsActive(this LocationGroup location, Farmer farmer)
		{
			GameLocation currentLocation = farmer.currentLocation;
			if (location == LocationGroup.FarmPlaces)
			{
				return LocationGroupsExtensions.farmLocationNames.Contains((currentLocation != null) ? currentLocation.Name.ToLower() : null);
			}
			if (location == LocationGroup.WaterPlaces)
			{
				return LocationGroupsExtensions.waterLocationNames.Contains((currentLocation != null) ? currentLocation.Name.ToLower() : null);
			}
			if (location == LocationGroup.IslandPlaces)
			{
				if (LocationGroupsExtensions.islandLocationNames.Contains((currentLocation != null) ? currentLocation.Name.ToLower() : null))
				{
					return true;
				}
				VolcanoDungeon volcanoDungeon = Game1.player.currentLocation as VolcanoDungeon;
				return volcanoDungeon != null && volcanoDungeon.level != 0;
			}
			else if (location == LocationGroup.DesertPlaces)
			{
				if (LocationGroupsExtensions.desertLocationNames.Contains((currentLocation != null) ? currentLocation.Name.ToLower() : null))
				{
					return true;
				}
				MineShaft mineShaft = Game1.player.currentLocation as MineShaft;
				return mineShaft != null && mineShaft.mineLevel > 120;
			}
			else
			{
				if (location != LocationGroup.UndergroundPlaces)
				{
					if (location == LocationGroup.DangerousMines)
					{
						MineShaft mineShaft2 = Game1.player.currentLocation as MineShaft;
						if (mineShaft2 != null && mineShaft2.mineLevel != 0 && mineShaft2.GetAdditionalDifficulty() > 0)
						{
							return true;
						}
					}
					return false;
				}
				if (LocationGroupsExtensions.underLocationNames.Contains((currentLocation != null) ? currentLocation.Name.ToLower() : null))
				{
					return true;
				}
				MineShaft mineShaft3 = Game1.player.currentLocation as MineShaft;
				if (mineShaft3 != null && mineShaft3.mineLevel != 0)
				{
					return true;
				}
				VolcanoDungeon volcanoDungeon2 = Game1.player.currentLocation as VolcanoDungeon;
				return volcanoDungeon2 != null && volcanoDungeon2.level != 0;
			}
		}

		// Token: 0x040000BF RID: 191
		private const int desertMineAreaId = 121;

		// Token: 0x040000C0 RID: 192
		private static HashSet<string> desertLocationNames = new HashSet<string>
		{
			"desert",
			"sandyhouse",
			"skullcave",
			"club"
		};

		// Token: 0x040000C1 RID: 193
		private static HashSet<string> farmLocationNames = new HashSet<string>
		{
			"farm",
			"farmhouse",
			"farmcave",
			"greenhouse"
		};

		// Token: 0x040000C2 RID: 194
		private static HashSet<string> waterLocationNames = new HashSet<string>
		{
			"beach",
			"beachnightmarket",
			"islandwest",
			"islandsouth",
			"islandsoutheast",
			"islandsoutheastcave",
			"fishshop",
			"elliotthouse",
			"islandfarmhouse",
			"submarine",
			"captainroom"
		};

		// Token: 0x040000C3 RID: 195
		private static HashSet<string> islandLocationNames;

		// Token: 0x040000C4 RID: 196
		private static HashSet<string> underLocationNames = new HashSet<string>
		{
			"farmcave",
			"sewer",
			"sebastionroom",
			"wizardhousebasement",
			"mine",
			"bugland",
			"witchwarpcave",
			"skullcave",
			"cellar",
			"cellar2",
			"cellar3",
			"cellar4"
		};
	}
}
