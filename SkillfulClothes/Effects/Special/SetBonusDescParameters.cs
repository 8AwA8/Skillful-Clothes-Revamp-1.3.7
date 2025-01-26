using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000AB RID: 171
	public class SetBonusDescParameters : IEffectParameters
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00004ECF File Offset: 0x000030CF
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00004ED7 File Offset: 0x000030D7
		public string setBonus { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00004EE0 File Offset: 0x000030E0
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x00004EE8 File Offset: 0x000030E8
		public string iconName { get; set; }

		// Token: 0x060003EB RID: 1003 RVA: 0x00004F04 File Offset: 0x00003104
		public static SetBonusDescParameters With(string setBonus, string iconName, IEffect actualEffect)
		{
			return new SetBonusDescParameters
			{
				setBonus = setBonus,
				iconName = iconName,
				Effect = actualEffect
			};
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00004F20 File Offset: 0x00003120
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x00004F28 File Offset: 0x00003128
		public IEffect Effect { get; set; } = new NullEffect();
	}
}
