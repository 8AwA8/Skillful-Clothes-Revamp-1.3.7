using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000078 RID: 120
	internal class IncreaseAttackMultiplier : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000352A File Offset: 0x0000172A
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Attack;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00003E0A File Offset: 0x0000200A
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-AttackM");
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000D028 File Offset: 0x0000B228
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.AttackMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseAttackMultiplier(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseAttackMultiplier(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
