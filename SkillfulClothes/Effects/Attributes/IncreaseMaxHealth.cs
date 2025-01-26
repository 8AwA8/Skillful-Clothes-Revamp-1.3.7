using System;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000063 RID: 99
	internal class IncreaseMaxHealth : ChangeAttributeMaxEffect
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00003765 File Offset: 0x00001965
		public override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Health");
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600021B RID: 539 RVA: 0x000037FF File Offset: 0x000019FF
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.MaxHealth;
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000037BA File Offset: 0x000019BA
		public IncreaseMaxHealth(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000037C3 File Offset: 0x000019C3
		public IncreaseMaxHealth(int amount) : base(AmountEffectParameters.With(amount))
		{
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00003783 File Offset: 0x00001983
		protected override int GetCurrentValue(Farmer farmer)
		{
			return farmer.health;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00003793 File Offset: 0x00001993
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.health = newValue;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000378B File Offset: 0x0000198B
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.maxHealth;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00003802 File Offset: 0x00001A02
		protected override void SetMaxValue(Farmer farmer, int newValue)
		{
			farmer.maxHealth = newValue;
		}
	}
}
