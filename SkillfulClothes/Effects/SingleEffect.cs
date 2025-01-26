using System;
using System.Collections.Generic;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000042 RID: 66
	internal abstract class SingleEffect<TParameters> : CustomizableEffect<TParameters> where TParameters : IEffectParameters, new()
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00002F8A File Offset: 0x0000118A
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				if (this.effectDescription == null)
				{
					this.effectDescription = new List<EffectDescriptionLine>
					{
						this.GenerateEffectDescription()
					};
				}
				return this.effectDescription;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00002FB1 File Offset: 0x000011B1
		public SingleEffect(TParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00002FBA File Offset: 0x000011BA
		public override void ReloadParameters()
		{
			base.ReloadParameters();
			this.effectDescription = new List<EffectDescriptionLine>
			{
				this.GenerateEffectDescription()
			};
		}

		// Token: 0x0600015B RID: 347
		protected abstract EffectDescriptionLine GenerateEffectDescription();

		// Token: 0x04000212 RID: 530
		private List<EffectDescriptionLine> effectDescription;
	}
}
