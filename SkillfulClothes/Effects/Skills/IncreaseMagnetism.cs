using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007E RID: 126
	internal class IncreaseMagnetism : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x00003EB7 File Offset: 0x000020B7
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.TreasureChest;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00003EBB File Offset: 0x000020BB
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Mag");
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000D368 File Offset: 0x0000B568
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.MagneticRadius.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * 64f;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00003548 File Offset: 0x00001748
		public IncreaseMagnetism(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00003551 File Offset: 0x00001751
		public IncreaseMagnetism(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
