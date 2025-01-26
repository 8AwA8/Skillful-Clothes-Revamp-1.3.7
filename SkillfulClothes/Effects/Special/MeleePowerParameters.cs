using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000094 RID: 148
	public class MeleePowerParameters : IEffectParameters
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00004676 File Offset: 0x00002876
		// (set) Token: 0x0600034D RID: 845 RVA: 0x0000467E File Offset: 0x0000287E
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00004687 File Offset: 0x00002887
		// (set) Token: 0x0600034F RID: 847 RVA: 0x0000468F File Offset: 0x0000288F
		public int WeaponID { get; set; }

		// Token: 0x06000350 RID: 848 RVA: 0x00004698 File Offset: 0x00002898
		public static MeleePowerParameters With(IEffect actualEffect, int weaponid)
		{
			return new MeleePowerParameters
			{
				Effect = actualEffect,
				WeaponID = weaponid
			};
		}
	}
}
