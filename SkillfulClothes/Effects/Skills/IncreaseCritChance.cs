using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007A RID: 122
	internal class IncreaseCritChance : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00003E44 File Offset: 0x00002044
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.CriticalHitRate;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00003E47 File Offset: 0x00002047
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-CritC");
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000D218 File Offset: 0x0000B418
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.CriticalChanceMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseCritChance(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseCritChance(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
