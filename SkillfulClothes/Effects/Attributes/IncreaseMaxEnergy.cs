using System;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000062 RID: 98
	internal class IncreaseMaxEnergy : ChangeAttributeMaxEffect
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000212 RID: 530 RVA: 0x0000379C File Offset: 0x0000199C
		public override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Energy");
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000213 RID: 531 RVA: 0x000037B7 File Offset: 0x000019B7
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.MaxEnergy;
			}
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000037BA File Offset: 0x000019BA
		public IncreaseMaxEnergy(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000037C3 File Offset: 0x000019C3
		public IncreaseMaxEnergy(int amount) : base(AmountEffectParameters.With(amount))
		{
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000037D1 File Offset: 0x000019D1
		protected override int GetCurrentValue(Farmer farmer)
		{
			return (int)farmer.stamina;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000037DA File Offset: 0x000019DA
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.stamina = (float)newValue;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000037E4 File Offset: 0x000019E4
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.maxStamina;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x000037F1 File Offset: 0x000019F1
		protected override void SetMaxValue(Farmer farmer, int newValue)
		{
			farmer.maxStamina.Value = newValue;
		}
	}
}
