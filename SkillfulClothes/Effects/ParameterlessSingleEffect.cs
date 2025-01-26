using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000043 RID: 67
	internal abstract class ParameterlessSingleEffect : CustomizableEffect<NoEffectParameters>
	{
		// Token: 0x0600015C RID: 348 RVA: 0x00002FD9 File Offset: 0x000011D9
		public ParameterlessSingleEffect() : base(NoEffectParameters.Default)
		{
		}
	}
}
