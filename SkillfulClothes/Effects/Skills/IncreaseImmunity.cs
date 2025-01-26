using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000059 RID: 89
	internal class IncreaseImmunity : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseImmunity(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseImmunity(int amount) : base(AmountEffectParameters.With(amount))
		{
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000035C1 File Offset: 0x000017C1
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Immunity");
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001DA RID: 474 RVA: 0x000035DC File Offset: 0x000017DC
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Immunity;
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000B864 File Offset: 0x00009A64
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Immunity.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}
	}
}
