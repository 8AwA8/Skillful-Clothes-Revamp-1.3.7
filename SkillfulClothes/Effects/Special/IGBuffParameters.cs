using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A1 RID: 161
	public class IGBuffParameters : IEffectParameters
	{
		// Token: 0x060003A9 RID: 937 RVA: 0x00004BC2 File Offset: 0x00002DC2
		public static IGBuffParameters With(string buffid)
		{
			return new IGBuffParameters
			{
				buffId = buffid
			};
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00004BD0 File Offset: 0x00002DD0
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00004BD8 File Offset: 0x00002DD8
		public string buffId { get; set; }
	}
}
