using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000073 RID: 115
	public class healthEffectParameters : IEffectParameters
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00003BB7 File Offset: 0x00001DB7
		// (set) Token: 0x06000286 RID: 646 RVA: 0x00003BBF File Offset: 0x00001DBF
		public healthGroup health { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00003BC8 File Offset: 0x00001DC8
		// (set) Token: 0x06000288 RID: 648 RVA: 0x00003BD0 File Offset: 0x00001DD0
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x06000289 RID: 649 RVA: 0x00003BD9 File Offset: 0x00001DD9
		public static healthEffectParameters With(healthGroup health, IEffect actualEffect)
		{
			return new healthEffectParameters
			{
				health = health,
				Effect = actualEffect
			};
		}
	}
}
