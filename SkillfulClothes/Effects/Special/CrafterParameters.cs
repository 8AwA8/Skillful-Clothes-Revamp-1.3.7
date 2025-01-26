using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000098 RID: 152
	public class CrafterParameters : IEffectParameters
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00004856 File Offset: 0x00002A56
		// (set) Token: 0x0600036A RID: 874 RVA: 0x0000485E File Offset: 0x00002A5E
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x0600036B RID: 875 RVA: 0x00004867 File Offset: 0x00002A67
		public static CrafterParameters With(IEffect actualEffect)
		{
			return new CrafterParameters
			{
				Effect = actualEffect
			};
		}
	}
}
