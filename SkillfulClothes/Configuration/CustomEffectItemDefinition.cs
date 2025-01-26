using System;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Configuration
{
	// Token: 0x02000067 RID: 103
	public class CustomEffectItemDefinition
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600022D RID: 557 RVA: 0x00003883 File Offset: 0x00001A83
		public string ItemIdentifier { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600022E RID: 558 RVA: 0x0000388B File Offset: 0x00001A8B
		public IEffect Effect { get; }

		// Token: 0x0600022F RID: 559 RVA: 0x00003893 File Offset: 0x00001A93
		public CustomEffectItemDefinition(string id, IEffect effect)
		{
			this.ItemIdentifier = id;
			this.Effect = effect;
		}
	}
}
