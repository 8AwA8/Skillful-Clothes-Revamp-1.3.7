using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007B RID: 123
	internal class IncreaseCritDamage : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00003E44 File Offset: 0x00002044
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.CriticalHitRate;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00003E62 File Offset: 0x00002062
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-CritD");
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000D26C File Offset: 0x0000B46C
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.CriticalPowerMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseCritDamage(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseCritDamage(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
