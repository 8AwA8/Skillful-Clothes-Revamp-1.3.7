using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003C RID: 60
	public interface IEffect
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000145 RID: 325
		string EffectId { get; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000146 RID: 326
		List<EffectDescriptionLine> EffectDescription { get; }

		// Token: 0x06000147 RID: 327
		void Apply(Item sourceItem, EffectChangeReason reason);

		// Token: 0x06000148 RID: 328
		void Remove(Item sourceItem, EffectChangeReason reason);
	}
}
