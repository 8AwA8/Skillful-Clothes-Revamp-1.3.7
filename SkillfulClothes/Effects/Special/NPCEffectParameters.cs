using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009C RID: 156
	public class NPCEffectParameters : IEffectParameters
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600037E RID: 894 RVA: 0x0000499F File Offset: 0x00002B9F
		// (set) Token: 0x0600037F RID: 895 RVA: 0x000049A7 File Offset: 0x00002BA7
		public string NPC { get; set; }

		// Token: 0x06000380 RID: 896 RVA: 0x000049B0 File Offset: 0x00002BB0
		public static NPCEffectParameters With(string NPC, int amount, int type)
		{
			return new NPCEffectParameters
			{
				NPC = NPC,
				amount = amount,
				type = type
			};
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000381 RID: 897 RVA: 0x000049CC File Offset: 0x00002BCC
		// (set) Token: 0x06000382 RID: 898 RVA: 0x000049D4 File Offset: 0x00002BD4
		public int amount { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000383 RID: 899 RVA: 0x000049DD File Offset: 0x00002BDD
		// (set) Token: 0x06000384 RID: 900 RVA: 0x000049E5 File Offset: 0x00002BE5
		public int type { get; set; }
	}
}
