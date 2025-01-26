using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007C RID: 124
	internal class IncreaseWeaponSpeed : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0000352A File Offset: 0x0000172A
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Attack;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00003E7D File Offset: 0x0000207D
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-WS");
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000D2C0 File Offset: 0x0000B4C0
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.WeaponSpeedMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseWeaponSpeed(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseWeaponSpeed(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
