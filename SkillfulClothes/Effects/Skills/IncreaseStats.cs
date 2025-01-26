using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;
using StardewValley.Locations;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000079 RID: 121
	internal class IncreaseStats : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00003E25 File Offset: 0x00002025
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Glow;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00003E29 File Offset: 0x00002029
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-DSS");
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000D07C File Offset: 0x0000B27C
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			MineShaft mineShaft = Game1.currentLocation as MineShaft;
			if (mineShaft != null && mineShaft.mineLevel < 121 && mineShaft.mineLevel < 10000)
			{
				targetEffects.Attack.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)mineShaft.mineLevel / 25f;
				targetEffects.Speed.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)mineShaft.mineLevel / 50f;
				return;
			}
			if (mineShaft != null && mineShaft.mineLevel > 120 && mineShaft.mineLevel < 10000)
			{
				targetEffects.Attack.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)(mineShaft.mineLevel - 120) / 25f;
				targetEffects.Speed.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)(mineShaft.mineLevel - 120) / 50f;
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseStats(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseStats(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
