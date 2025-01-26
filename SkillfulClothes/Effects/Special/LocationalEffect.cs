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
	// Token: 0x020000B6 RID: 182
	internal class LocationalEffect : SingleEffect<LocationalEffectParameters>
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x00005075 File Offset: 0x00003275
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000507D File Offset: 0x0000327D
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x00005085 File Offset: 0x00003285
		private Item SourceItem { get; set; }

		// Token: 0x0600042E RID: 1070 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000508E File Offset: 0x0000328E
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.Location.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000050BC File Offset: 0x000032BC
		public LocationalEffect(LocationalEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x000050D0 File Offset: 0x000032D0
		public LocationalEffect(LocationGroup location, IEffect actualEffect) : base(LocationalEffectParameters.With(location, actualEffect))
		{
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00015694 File Offset: 0x00013894
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000050EA File Offset: 0x000032EA
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000156FC File Offset: 0x000138FC
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.Location.IsActive(Game1.player))
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

		// Token: 0x06000436 RID: 1078 RVA: 0x0000514D File Offset: 0x0000334D
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002E2 RID: 738
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002E3 RID: 739
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
