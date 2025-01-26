using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000057 RID: 87
	internal class IncreaseDefense : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001CC RID: 460 RVA: 0x0000355F File Offset: 0x0000175F
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Defense;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00003562 File Offset: 0x00001762
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Defense");
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000B498 File Offset: 0x00009698
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Defense.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseDefense(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseDefense(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
