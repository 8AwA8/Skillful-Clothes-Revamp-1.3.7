using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000035 RID: 53
	public abstract class CustomizableEffect<TParameters> : IEffect, ICustomizableEffect where TParameters : IEffectParameters, new()
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00002E4A File Offset: 0x0000104A
		public string EffectId
		{
			get
			{
				return EffectHelper.GetEffectId(this);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00002E52 File Offset: 0x00001052
		public Type ParameterType
		{
			get
			{
				return typeof(TParameters);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00002E5E File Offset: 0x0000105E
		// (set) Token: 0x06000129 RID: 297 RVA: 0x000092F0 File Offset: 0x000074F0
		public object ParameterObject
		{
			get
			{
				return this.Parameters;
			}
			set
			{
				if (value is TParameters)
				{
					TParameters parameters = (TParameters)((object)value);
					this.SetParameters(parameters);
					return;
				}
				string str = "Effect ";
				string name = base.GetType().Name;
				string str2 = " received wrong parameter type ";
				string text;
				if (value == null)
				{
					text = null;
				}
				else
				{
					Type type = value.GetType();
					text = ((type != null) ? type.Name : null);
				}
				throw new Exception(str + name + str2 + (text ?? "none"));
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00002E6B File Offset: 0x0000106B
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00002E73 File Offset: 0x00001073
		public TParameters Parameters { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600012C RID: 300
		public abstract List<EffectDescriptionLine> EffectDescription { get; }

		// Token: 0x0600012D RID: 301 RVA: 0x00002E7C File Offset: 0x0000107C
		public void SetParameters(TParameters parameters)
		{
			this.Parameters = parameters;
			this.ReloadParameters();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00002E8B File Offset: 0x0000108B
		public virtual void ReloadParameters()
		{
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00009354 File Offset: 0x00007554
		public CustomizableEffect(TParameters parameters)
		{
			this.SetParameters((parameters != null) ? parameters : Activator.CreateInstance<TParameters>());
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00002E8D File Offset: 0x0000108D
		public CustomizableEffect()
		{
			this.SetParameters(Activator.CreateInstance<TParameters>());
		}

		// Token: 0x06000131 RID: 305
		public abstract void Apply(Item sourceItem, EffectChangeReason reason);

		// Token: 0x06000132 RID: 306
		public abstract void Remove(Item sourceItem, EffectChangeReason reason);
	}
}
