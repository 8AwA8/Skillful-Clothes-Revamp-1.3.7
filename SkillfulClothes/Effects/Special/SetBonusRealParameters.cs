using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A8 RID: 168
	public class SetBonusRealParameters : IEffectParameters
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00004D89 File Offset: 0x00002F89
		// (set) Token: 0x060003CA RID: 970 RVA: 0x00004D91 File Offset: 0x00002F91
		public string hat { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00004D9A File Offset: 0x00002F9A
		// (set) Token: 0x060003CC RID: 972 RVA: 0x00004DA2 File Offset: 0x00002FA2
		public string shirt { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00004DAB File Offset: 0x00002FAB
		// (set) Token: 0x060003CE RID: 974 RVA: 0x00004DB3 File Offset: 0x00002FB3
		public string pants { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00004DBC File Offset: 0x00002FBC
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x00004DC4 File Offset: 0x00002FC4
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x00004DE0 File Offset: 0x00002FE0
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x00004DE8 File Offset: 0x00002FE8
		public string setBonus { get; set; }

		// Token: 0x060003D4 RID: 980 RVA: 0x00004DF1 File Offset: 0x00002FF1
		public static SetBonusRealParameters With(string hat, string shirt, string pants, string setBonus, string iconName, IEffect actualEffect)
		{
			return new SetBonusRealParameters
			{
				hat = hat,
				shirt = shirt,
				pants = pants,
				setBonus = setBonus,
				iconName = iconName,
				Effect = actualEffect
			};
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00004E24 File Offset: 0x00003024
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x00004E2C File Offset: 0x0000302C
		public string iconName { get; set; }
	}
}
