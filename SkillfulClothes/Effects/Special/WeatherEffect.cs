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
	// Token: 0x020000B7 RID: 183
	internal class WeatherEffect : SingleEffect<WeatherEffectParameters>
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000515C File Offset: 0x0000335C
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00005164 File Offset: 0x00003364
		// (set) Token: 0x06000439 RID: 1081 RVA: 0x0000516C File Offset: 0x0000336C
		private Item SourceItem { get; set; }

		// Token: 0x0600043A RID: 1082 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00005175 File Offset: 0x00003375
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.Weather.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000051A3 File Offset: 0x000033A3
		public WeatherEffect(WeatherEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x000051B7 File Offset: 0x000033B7
		public WeatherEffect(WeatherGroup weather, IEffect actualEffect) : base(WeatherEffectParameters.With(weather, actualEffect))
		{
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00015884 File Offset: 0x00013A84
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, EffectChangeReason.Reset);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000158EC File Offset: 0x00013AEC
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00015940 File Offset: 0x00013B40
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.Weather.IsActive(Game1.player.currentLocation))
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

		// Token: 0x06000442 RID: 1090 RVA: 0x000051F9 File Offset: 0x000033F9
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002E5 RID: 741
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002E6 RID: 742
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
