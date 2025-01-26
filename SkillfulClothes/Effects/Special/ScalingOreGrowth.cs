using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;
using StardewValley.Locations;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000090 RID: 144
	internal class ScalingOreGrowth : SingleEffect<NoEffectParameters>
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000336 RID: 822 RVA: 0x000044FC File Offset: 0x000026FC
		// (set) Token: 0x06000337 RID: 823 RVA: 0x00004504 File Offset: 0x00002704
		private Item SourceItem { get; set; }

		// Token: 0x06000338 RID: 824 RVA: 0x0000450D File Offset: 0x0000270D
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillMining, EffectHelper.ModHelper.Translation.Get("Spec-SOG"));
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000452F File Offset: 0x0000272F
		public ScalingOreGrowth() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000E388 File Offset: 0x0000C588
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.rocks.Value = (int)Game1.player.stats.RocksCrushed;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking += this.Events_UpdateTicking;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00004552 File Offset: 0x00002752
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000E3F8 File Offset: 0x0000C5F8
		private void Events_UpdateTicking(object sender, OneSecondUpdateTickingEventArgs e)
		{
			int rocksCrushed = (int)Game1.player.stats.RocksCrushed;
			if (rocksCrushed > this.rocks.Value)
			{
				this.count.Value += rocksCrushed - this.rocks.Value;
				this.rocks.Value = rocksCrushed;
				if (this.count.Value >= (int)(5f * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? (1f / EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1f)))
				{
					this.count.Value = 0;
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("coin", null, SoundContext.Default);
					}
					MineShaft mineShaft = Game1.player.currentLocation as MineShaft;
					if (mineShaft != null)
					{
						if (mineShaft.mineLevel < 40)
						{
							Item item = ItemRegistry.Create("378", 1, 0, true);
							Game1.player.addItemToInventory(item);
						}
						else if (mineShaft.mineLevel < 70)
						{
							Item item2 = ItemRegistry.Create("380", 1, 0, true);
							Game1.player.addItemToInventory(item2);
						}
						else if (mineShaft.mineLevel < 120)
						{
							Item item3 = ItemRegistry.Create("384", 1, 0, true);
							Game1.player.addItemToInventory(item3);
						}
						else if (mineShaft.mineLevel < 160)
						{
							Item item4 = ItemRegistry.Create("382", 1, 0, true);
							Game1.player.addItemToInventory(item4);
						}
						else if (mineShaft.mineLevel < 220)
						{
							Item item5 = ItemRegistry.Create("386", 1, 0, true);
							Game1.player.addItemToInventory(item5);
						}
						else
						{
							Item item6 = ItemRegistry.Create("337", 1, 0, true);
							Game1.player.addItemToInventory(item6);
						}
					}
					else if (Game1.player.currentLocation is VolcanoDungeon)
					{
						Item item7 = ItemRegistry.Create("848", 1, 0, true);
						Game1.player.addItemToInventory(item7);
					}
					else
					{
						Item item8 = ItemRegistry.Create("330", 1, 0, true);
						Game1.player.addItemToInventory(item8);
					}
				}
			}
			this.rocks.Value = rocksCrushed;
		}

		// Token: 0x04000296 RID: 662
		private PerScreen<int> rocks = new PerScreen<int>();

		// Token: 0x04000297 RID: 663
		private PerScreen<int> count = new PerScreen<int>();
	}
}
