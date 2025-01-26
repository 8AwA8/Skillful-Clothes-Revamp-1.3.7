using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000056 RID: 86
	internal class IncreaseAttack : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000352A File Offset: 0x0000172A
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Attack;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000352D File Offset: 0x0000172D
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Attack");
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000B44C File Offset: 0x0000964C
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Attack.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseAttack(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseAttack(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
