using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000050 RID: 80
	internal class SeasonalEffect : CustomizableEffect<SeasonalEffectParameters>
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000336E File Offset: 0x0000156E
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00003376 File Offset: 0x00001576
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x0000337E File Offset: 0x0000157E
		private Item SourceItem { get; set; }

		// Token: 0x060001A5 RID: 421 RVA: 0x00003387 File Offset: 0x00001587
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.Season.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000033B5 File Offset: 0x000015B5
		public SeasonalEffect(SeasonalEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000033C9 File Offset: 0x000015C9
		public SeasonalEffect(Season season, IEffect actualEffect) : base(SeasonalEffectParameters.With(season, actualEffect))
		{
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000AC84 File Offset: 0x00008E84
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000033E3 File Offset: 0x000015E3
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000ACEC File Offset: 0x00008EEC
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.Season.IsActive())
			{
				if (!this.isApplied.Value)
				{
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts && this.SourceItem != null && (reason == EffectChangeReason.Reset || (reason == EffectChangeReason.DayStart && Game1.dayOfMonth == 1)))
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
						defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-EFXB"));
						defaultInterpolatedStringHandler.AppendFormatted<Item>(this.SourceItem);
						defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-Active"));
						Game1.addHUDMessage(new CustomHUDMessage(defaultInterpolatedStringHandler.ToStringAndClear(), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
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
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(23, 1);
					defaultInterpolatedStringHandler2.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-EFXB"));
					defaultInterpolatedStringHandler2.AppendFormatted<Item>(this.SourceItem);
					defaultInterpolatedStringHandler2.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-Wore"));
					Game1.addHUDMessage(new CustomHUDMessage(defaultInterpolatedStringHandler2.ToStringAndClear(), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				this.isApplied.Value = false;
				base.Parameters.Effect.Remove(sourceItem, reason);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00003446 File Offset: 0x00001646
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(null, EffectChangeReason.Reset);
		}

		// Token: 0x04000229 RID: 553
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x0400022A RID: 554
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
