using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A4 RID: 164
	public class ItemHeldEffectParameters : IEffectParameters
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00004C4E File Offset: 0x00002E4E
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x00004C56 File Offset: 0x00002E56
		public string itemId { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00004C5F File Offset: 0x00002E5F
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00004C67 File Offset: 0x00002E67
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x060003B8 RID: 952 RVA: 0x00004C70 File Offset: 0x00002E70
		public static ItemHeldEffectParameters With(string itemId, IEffect actualEffect)
		{
			return new ItemHeldEffectParameters
			{
				itemId = itemId,
				Effect = actualEffect
			};
		}
	}
}
