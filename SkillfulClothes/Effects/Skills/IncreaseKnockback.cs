using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007D RID: 125
	internal class IncreaseKnockback : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00003E98 File Offset: 0x00002098
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Animal_Cow;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00003E9C File Offset: 0x0000209C
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-KB");
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000D314 File Offset: 0x0000B514
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.KnockbackMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseKnockback(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseKnockback(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
