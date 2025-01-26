using System;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003E RID: 62
	internal class RingEffect : SingleEffect<RingEffectParameters>
	{
		// Token: 0x0600014E RID: 334 RVA: 0x00002F42 File Offset: 0x00001142
		public RingEffect(RingEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00002F4B File Offset: 0x0000114B
		public RingEffect(RingType ring) : base(RingEffectParameters.With(ring))
		{
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00002F59 File Offset: 0x00001159
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return base.Parameters.Ring.GetEffectDescription();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00002E8B File Offset: 0x0000108B
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00002E8B File Offset: 0x0000108B
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
		}
	}
}
