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
	// Token: 0x02000074 RID: 116
	internal class healthEffect : SingleEffect<healthEffectParameters>
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00003C01 File Offset: 0x00001E01
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00003C09 File Offset: 0x00001E09
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00003C11 File Offset: 0x00001E11
		private Item SourceItem { get; set; }

		// Token: 0x0600028E RID: 654 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00003C1D File Offset: 0x00001E1D
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.health.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00003C4B File Offset: 0x00001E4B
		public healthEffect(healthEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00003C5F File Offset: 0x00001E5F
		public healthEffect(healthGroup health, IEffect actualEffect) : base(healthEffectParameters.With(health, actualEffect))
		{
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000CC44 File Offset: 0x0000AE44
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_OneSecondUpdateTicks;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking += this.Events_OneSecondUpdateTicks;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00003C79 File Offset: 0x00001E79
		private void Events_OneSecondUpdateTicks(object sender, OneSecondUpdateTickingEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00003C88 File Offset: 0x00001E88
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_OneSecondUpdateTicks;
			this.SourceItem = null;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000CCAC File Offset: 0x0000AEAC
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.health.IsActive())
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

		// Token: 0x04000273 RID: 627
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x04000274 RID: 628
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
