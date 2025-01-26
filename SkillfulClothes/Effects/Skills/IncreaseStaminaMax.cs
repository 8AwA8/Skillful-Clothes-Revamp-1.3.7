using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x020000AE RID: 174
	internal class IncreaseStaminaMax : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x000037B7 File Offset: 0x000019B7
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.MaxEnergy;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x0000379C File Offset: 0x0000199C
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Energy");
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00012A1C File Offset: 0x00010C1C
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.MaxStamina.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseStaminaMax(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseStaminaMax(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
