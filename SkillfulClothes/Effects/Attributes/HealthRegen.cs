using System;
using Microsoft.Xna.Framework;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000061 RID: 97
	internal class HealthRegen : AttributeRegenEffect
	{
		// Token: 0x0600020C RID: 524 RVA: 0x00003750 File Offset: 0x00001950
		public HealthRegen() : base(AttributeRegenParameters.With(Color.Red, 5, 1, 1))
		{
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00003765 File Offset: 0x00001965
		protected override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Health");
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00003780 File Offset: 0x00001980
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Health;
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00003783 File Offset: 0x00001983
		protected override int GetCurrentValue(Farmer farmer)
		{
			return farmer.health;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000378B File Offset: 0x0000198B
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.maxHealth;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00003793 File Offset: 0x00001993
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.health = newValue;
		}
	}
}
