using System;
using SkillfulClothes.Effects;
using StardewValley;

namespace SkillfulClothes.Types
{
	// Token: 0x02000031 RID: 49
	public static class SkilLExtensions
	{
		// Token: 0x06000111 RID: 273 RVA: 0x00002D0F File Offset: 0x00000F0F
		public static EffectIcon GetIcon(this Skill skill)
		{
			switch (skill)
			{
			case Skill.Farming:
				return EffectIcon.SkillFarming;
			case Skill.Fishing:
				return EffectIcon.SkillFishing;
			case Skill.Foraging:
				return EffectIcon.SkillForaging;
			case Skill.Mining:
				return EffectIcon.SkillMining;
			case Skill.Combat:
				return EffectIcon.SkillCombat;
			case Skill.Luck:
				return EffectIcon.SkillLuck;
			default:
				return EffectIcon.None;
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00008E28 File Offset: 0x00007028
		public static int GetCurrentLevel(this Skill skill)
		{
			switch (skill)
			{
			case Skill.Farming:
				return Game1.player.FarmingLevel;
			case Skill.Fishing:
				return Game1.player.FishingLevel;
			case Skill.Foraging:
				return Game1.player.ForagingLevel;
			case Skill.Mining:
				return Game1.player.MiningLevel;
			case Skill.Combat:
				return Game1.player.CombatLevel;
			default:
				return 0;
			}
		}
	}
}
