using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008C RID: 140
	internal class BaitProduce : SingleEffect<BaitProduceParameters>
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00004367 File Offset: 0x00002567
		// (set) Token: 0x0600031D RID: 797 RVA: 0x0000436F File Offset: 0x0000256F
		private Item SourceItem { get; set; }

		// Token: 0x0600031E RID: 798 RVA: 0x00004378 File Offset: 0x00002578
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFishing, EffectHelper.ModHelper.Translation.Get("Spec-BP"));
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000439A File Offset: 0x0000259A
		public BaitProduce(BaitProduceParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000043C4 File Offset: 0x000025C4
		public BaitProduce(int steps) : base(BaitProduceParameters.With(steps))
		{
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000DD78 File Offset: 0x0000BF78
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.steps.Value = (int)Game1.player.stats.StepsTaken;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.Events_UpdateTicking;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000043F3 File Offset: 0x000025F3
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000DDE8 File Offset: 0x0000BFE8
		private void Events_UpdateTicking(object sender, TimeChangedEventArgs e)
		{
			if ((long)this.steps.Value < (long)((ulong)Game1.player.stats.StepsTaken))
			{
				this.count.Value += (int)(Game1.player.stats.StepsTaken - (uint)this.steps.Value);
				this.steps.Value = (int)Game1.player.stats.StepsTaken;
				if (this.count.Value >= (int)((float)base.Parameters.Steps * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? (1f / EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1f)))
				{
					Game1.player.playNearbySoundLocal("coin", null, SoundContext.Default);
					int value = this.overcount.Value;
					this.overcount.Value = value + this.count.Value / 10;
					this.count.Value = 0;
					if (this.overcount.Value >= 10)
					{
						this.overcount.Value = 0;
						Item item = ItemRegistry.Create("DeluxeBait", 1, 0, true);
						Game1.player.addItemToInventory(item);
					}
					else
					{
						Item item2 = ItemRegistry.Create("685", 1, 0, true);
						Game1.player.addItemToInventory(item2);
					}
				}
			}
			this.steps.Value = (int)Game1.player.stats.StepsTaken;
		}

		// Token: 0x0400028E RID: 654
		private PerScreen<int> steps = new PerScreen<int>();

		// Token: 0x0400028F RID: 655
		private PerScreen<int> count = new PerScreen<int>();

		// Token: 0x04000290 RID: 656
		private PerScreen<int> overcount = new PerScreen<int>();
	}
}
