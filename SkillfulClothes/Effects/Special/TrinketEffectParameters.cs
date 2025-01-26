using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B2 RID: 178
	public class TrinketEffectParameters : IEffectParameters
	{
		// Token: 0x06000412 RID: 1042 RVA: 0x00004FA3 File Offset: 0x000031A3
		public static TrinketEffectParameters With(int Trinket)
		{
			return new TrinketEffectParameters
			{
				Trinket = Trinket
			};
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x00004FB1 File Offset: 0x000031B1
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x00004FB9 File Offset: 0x000031B9
		public int Trinket { get; set; }
	}
}
