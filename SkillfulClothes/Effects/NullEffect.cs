using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003D RID: 61
	internal class NullEffect : IEffect
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00002F2A File Offset: 0x0000112A
		public List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return new List<EffectDescriptionLine>
				{
					new EffectDescriptionLine(EffectIcon.None, "Does nothing")
				};
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00002E4A File Offset: 0x0000104A
		public string EffectId
		{
			get
			{
				return EffectHelper.GetEffectId(this);
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00002E8B File Offset: 0x0000108B
		public void Apply(Item sourceItem, EffectChangeReason reason)
		{
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00002E8B File Offset: 0x0000108B
		public void Remove(Item sourceItem, EffectChangeReason reason)
		{
		}
	}
}
