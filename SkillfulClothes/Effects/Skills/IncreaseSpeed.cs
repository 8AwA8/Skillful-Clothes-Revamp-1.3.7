using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200005C RID: 92
	internal class IncreaseSpeed : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00003626 File Offset: 0x00001826
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Speed;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000362A File Offset: 0x0000182A
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Speed");
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Speed.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().OneToOneSpeed ? 1f : 0.75f) * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseSpeed(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseSpeed(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
