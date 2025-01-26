using System;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003B RID: 59
	public interface ICustomizableEffect : IEffect
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000141 RID: 321
		Type ParameterType { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000142 RID: 322
		// (set) Token: 0x06000143 RID: 323
		object ParameterObject { get; set; }

		// Token: 0x06000144 RID: 324
		void ReloadParameters();
	}
}
