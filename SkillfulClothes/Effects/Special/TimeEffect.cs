using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009F RID: 159
	internal class TimeEffect : SingleEffect<TimeEffectParameters>
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00004AE4 File Offset: 0x00002CE4
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00004AEC File Offset: 0x00002CEC
		// (set) Token: 0x06000398 RID: 920 RVA: 0x00004AF4 File Offset: 0x00002CF4
		private Item SourceItem { get; set; }

		// Token: 0x06000399 RID: 921 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00004AFD File Offset: 0x00002CFD
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + this.TimeText())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00004B2B File Offset: 0x00002D2B
		public TimeEffect(TimeEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00004B3F File Offset: 0x00002D3F
		public TimeEffect(int timeStart, int timeEnd, IEffect actualEffect) : base(TimeEffectParameters.With(timeStart, timeEnd, actualEffect))
		{
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00011498 File Offset: 0x0000F698
		private string TimeText()
		{
			string text = EffectHelper.ModHelper.Translation.Get("Spec-Time4");
			if (base.Parameters.timeStart > 1800)
			{
				text = text + (base.Parameters.timeStart - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeStart < 300)
			{
				text = text + base.Parameters.timeStart.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeStart > 200 && base.Parameters.timeStart < 1200)
			{
				text = text + base.Parameters.timeStart.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time2");
			}
			else if (base.Parameters.timeStart >= 1200 && base.Parameters.timeStart < 1300)
			{
				text = text + base.Parameters.timeStart.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			else if (base.Parameters.timeStart >= 1300 && base.Parameters.timeStart < 1900)
			{
				text = text + (base.Parameters.timeStart - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			text += EffectHelper.ModHelper.Translation.Get("Spec-Time5");
			if (base.Parameters.timeEnd > 1800)
			{
				text = text + (base.Parameters.timeEnd - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeEnd < 300)
			{
				text = text + base.Parameters.timeEnd.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeEnd > 200 && base.Parameters.timeEnd < 1200)
			{
				text = text + base.Parameters.timeEnd.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time2");
			}
			else if (base.Parameters.timeEnd >= 1200 && base.Parameters.timeEnd < 1300)
			{
				text = text + base.Parameters.timeEnd.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			else if (base.Parameters.timeEnd >= 1300 && base.Parameters.timeEnd < 1900)
			{
				text = text + (base.Parameters.timeEnd - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			return text.Replace("00", "");
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00011848 File Offset: 0x0000FA48
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_TimeChanged;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.Events_TimeChanged;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00004B5A File Offset: 0x00002D5A
		private void Events_TimeChanged(object sender, TimeChangedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00004B69 File Offset: 0x00002D69
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_TimeChanged;
			this.SourceItem = null;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000118B0 File Offset: 0x0000FAB0
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.timeEnd >= Game1.timeOfDay && base.Parameters.timeStart <= Game1.timeOfDay)
			{
				if (!this.isApplied.Value)
				{
					if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
					{
						Game1.addHUDMessage(new CustomHUDMessage(EffectHelper.ModHelper.Translation.Get("Base-EFXB") + this.SourceItem.DisplayName + EffectHelper.ModHelper.Translation.Get("Base-Active"), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
					}
					this.isApplied.Value = true;
					base.Parameters.Effect.Apply(sourceItem, reason);
					return;
				}
			}
			else if (this.isApplied.Value)
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					Game1.addHUDMessage(new CustomHUDMessage(EffectHelper.ModHelper.Translation.Get("Base-EFXB") + this.SourceItem.DisplayName + EffectHelper.ModHelper.Translation.Get("Base-Wore"), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				this.isApplied.Value = false;
				base.Parameters.Effect.Remove(sourceItem, reason);
			}
		}

		// Token: 0x040002B6 RID: 694
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002B7 RID: 695
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
