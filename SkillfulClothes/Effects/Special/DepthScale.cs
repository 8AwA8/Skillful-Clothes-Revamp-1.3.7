using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000076 RID: 118
	internal class DepthScale : SingleEffect<DepthScalingParameters>
	{
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00003D35 File Offset: 0x00001F35
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00003D3D File Offset: 0x00001F3D
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00003D45 File Offset: 0x00001F45
		private Item SourceItem { get; set; }

		// Token: 0x060002A0 RID: 672 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000CE30 File Offset: 0x0000B030
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, string.Concat(new object[]
			{
				x.Text,
				EffectHelper.ModHelper.Translation.Get("Spec-DScale")
			}))).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00003D4E File Offset: 0x00001F4E
		public DepthScale(DepthScalingParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00003D62 File Offset: 0x00001F62
		public DepthScale(int floors, IEffect actualEffect) : base(DepthScalingParameters.With(floors, actualEffect))
		{
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000CE7C File Offset: 0x0000B07C
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00003D7C File Offset: 0x00001F7C
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000CED8 File Offset: 0x0000B0D8
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			MineShaft mineShaft = Game1.currentLocation as MineShaft;
			if (mineShaft != null && ((mineShaft.mineLevel < 120 && mineShaft.mineLevel > 25) || mineShaft.mineLevel > 145))
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					Game1.addHUDMessage(new CustomHUDMessage(string.Concat(new object[]
					{
						"The effect of ",
						this.SourceItem.DisplayName,
						" is scaling "
					}), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				this.isApplied.Value = true;
				base.Parameters.Effect.Apply(sourceItem, reason);
				return;
			}
			if (this.isApplied.Value)
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					Game1.addHUDMessage(new CustomHUDMessage("The effect of " + this.SourceItem.DisplayName + " wore off", this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				base.Parameters.Effect.Remove(sourceItem, reason);
				this.isApplied.Value = false;
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00003DB7 File Offset: 0x00001FB7
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x04000278 RID: 632
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x04000279 RID: 633
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
