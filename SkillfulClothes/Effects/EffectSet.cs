using System;
using System.Collections.Generic;
using System.Linq;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000039 RID: 57
	public class EffectSet : IEffect
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00002EC6 File Offset: 0x000010C6
		public IEffect[] Effects { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00002ECE File Offset: 0x000010CE
		List<EffectDescriptionLine> IEffect.EffectDescription
		{
			get
			{
				return this.Effects.SelectMany((IEffect x) => x.EffectDescription).ToList<EffectDescriptionLine>();
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00002E4A File Offset: 0x0000104A
		public string EffectId
		{
			get
			{
				return EffectHelper.GetEffectId(this);
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00002EFF File Offset: 0x000010FF
		private EffectSet(params IEffect[] effects)
		{
			this.Effects = effects;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00002F0E File Offset: 0x0000110E
		public static EffectSet Of(params IEffect[] effects)
		{
			return new EffectSet(effects);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00009ABC File Offset: 0x00007CBC
		public void Apply(Item sourceItem, EffectChangeReason reason)
		{
			foreach (IEffect effect in this.Effects)
			{
				effect.Apply(sourceItem, reason);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00009AEC File Offset: 0x00007CEC
		public void Remove(Item sourceItem, EffectChangeReason reason)
		{
			foreach (IEffect effect in this.Effects)
			{
				effect.Remove(sourceItem, reason);
			}
		}
	}
}
