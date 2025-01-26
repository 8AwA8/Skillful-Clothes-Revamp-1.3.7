using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200005A RID: 90
	internal class IncreaseSkillLevel : ChangeSkillEffect<IncreaseSkillLevelParameters>
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000B8B0 File Offset: 0x00009AB0
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-" + base.Parameters.Skill.ToString());
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000B8F4 File Offset: 0x00009AF4
		protected override EffectIcon Icon
		{
			get
			{
				IncreaseSkillLevelParameters parameters = base.Parameters;
				if (parameters == null)
				{
					return EffectIcon.None;
				}
				return parameters.Skill.GetIcon();
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000B918 File Offset: 0x00009B18
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			switch (base.Parameters.Skill)
			{
			case Skill.Farming:
				targetEffects.FarmingLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Fishing:
				targetEffects.FishingLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Foraging:
				targetEffects.ForagingLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Mining:
				targetEffects.MiningLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Combat:
				targetEffects.CombatLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Luck:
				targetEffects.LuckLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			default:
				return;
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000035E0 File Offset: 0x000017E0
		public IncreaseSkillLevel(IncreaseSkillLevelParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000035E9 File Offset: 0x000017E9
		public IncreaseSkillLevel(Skill skill, int amount) : base(IncreaseSkillLevelParameters.With(skill, amount))
		{
		}
	}
}
