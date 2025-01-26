using System;
using Microsoft.Xna.Framework;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000064 RID: 100
	internal class StaminaRegen : AttributeRegenEffect
	{
		// Token: 0x06000222 RID: 546 RVA: 0x0000380B File Offset: 0x00001A0B
		public StaminaRegen() : base(AttributeRegenParameters.With(Color.Green, 5, 1, 1))
		{
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000379C File Offset: 0x0000199C
		protected override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Energy");
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00003820 File Offset: 0x00001A20
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Energy;
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000037D1 File Offset: 0x000019D1
		protected override int GetCurrentValue(Farmer farmer)
		{
			return (int)farmer.stamina;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00003823 File Offset: 0x00001A23
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.MaxStamina;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000382B File Offset: 0x00001A2B
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.Stamina = (float)newValue;
		}
	}
}
