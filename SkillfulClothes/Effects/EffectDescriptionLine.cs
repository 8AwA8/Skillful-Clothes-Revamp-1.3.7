using System;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000036 RID: 54
	public class EffectDescriptionLine
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00002EA0 File Offset: 0x000010A0
		public EffectIcon Icon { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00002EA8 File Offset: 0x000010A8
		public string Text { get; }

		// Token: 0x06000135 RID: 309 RVA: 0x00002EB0 File Offset: 0x000010B0
		public EffectDescriptionLine(EffectIcon icon, string text)
		{
			this.Icon = icon;
			this.Text = text;
		}
	}
}
