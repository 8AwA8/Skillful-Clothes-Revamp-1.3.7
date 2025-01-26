using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000049 RID: 73
	public class GlowEffectParameters : IEffectParameters
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600017B RID: 379 RVA: 0x0000310D File Offset: 0x0000130D
		// (set) Token: 0x0600017C RID: 380 RVA: 0x00003115 File Offset: 0x00001315
		public float Radius { get; set; } = 5f;

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600017D RID: 381 RVA: 0x0000311E File Offset: 0x0000131E
		// (set) Token: 0x0600017E RID: 382 RVA: 0x00003126 File Offset: 0x00001326
		public Color Color { get; set; } = new Color(0, 30, 150);

		// Token: 0x0600017F RID: 383 RVA: 0x0000312F File Offset: 0x0000132F
		public static GlowEffectParameters With(float radius, Color? color = null)
		{
			if (color == null)
			{
				color = new Color?(new Color(0, 30, 150));
			}
			return new GlowEffectParameters
			{
				Radius = radius,
				Color = color.Value
			};
		}
	}
}
