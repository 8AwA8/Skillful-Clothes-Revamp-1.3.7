using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008F RID: 143
	internal class Sapping : SingleEffect<SappingParameters>
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000447F File Offset: 0x0000267F
		// (set) Token: 0x0600032E RID: 814 RVA: 0x00004487 File Offset: 0x00002687
		private Item SourceItem { get; set; }

		// Token: 0x0600032F RID: 815 RVA: 0x00004490 File Offset: 0x00002690
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillForaging, EffectHelper.ModHelper.Translation.Get("Spec-Sapping"));
		}

		// Token: 0x06000330 RID: 816 RVA: 0x000044B2 File Offset: 0x000026B2
		public Sapping(SappingParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000331 RID: 817 RVA: 0x000044C6 File Offset: 0x000026C6
		public Sapping(int chance) : base(SappingParameters.With(chance))
		{
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000E0C0 File Offset: 0x0000C2C0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.lastXp.Value = Game1.player.experiencePoints[2];
			if (Game1.player.getProfessionForSkill(2, 10) == 15)
			{
				this.tapperBuff = 1.2;
			}
			else
			{
				this.tapperBuff = 1.0;
			}
			EffectHelper.ModHelper.Events.World.TerrainFeatureListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked -= this.xpUpdate;
			EffectHelper.ModHelper.Events.World.TerrainFeatureListChanged += this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked += this.xpUpdate;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000E1A0 File Offset: 0x0000C3A0
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.World.TerrainFeatureListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked -= this.xpUpdate;
			this.SourceItem = null;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000044DF File Offset: 0x000026DF
		private void xpUpdate(object sender, OneSecondUpdateTickedEventArgs e)
		{
			this.lastXp.Value = Game1.player.experiencePoints[2];
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000E1F4 File Offset: 0x0000C3F4
		private void Events_UpdateTicking(object sender, TerrainFeatureListChangedEventArgs e)
		{
			int num = Game1.player.experiencePoints[2];
			if (num - this.lastXp.Value >= 12 && Game1.player.ActiveItem != null && Game1.player.ActiveItem.Name.EndsWith("Axe"))
			{
				this.lastXp.Value = num;
				if ((double)Game1.random.NextInt64(100L) <= (double)((long)((int)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)))) * this.tapperBuff)
				{
					long num2 = Game1.random.NextInt64(100L);
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("coin", null, SoundContext.Default);
					}
					if (num2 <= 50L)
					{
						Item item = ItemRegistry.Create("725", 1, 0, true);
						Game1.player.addItemToInventory(item);
						return;
					}
					if (num2 <= 75L)
					{
						Item item2 = ItemRegistry.Create("724", 1, 0, true);
						Game1.player.addItemToInventory(item2);
						return;
					}
					if (num2 <= 95L)
					{
						Item item3 = ItemRegistry.Create("726", 1, 0, true);
						Game1.player.addItemToInventory(item3);
						return;
					}
					Item item4 = ItemRegistry.Create("MysticSyrup", 1, 0, true);
					Game1.player.addItemToInventory(item4);
				}
				return;
			}
			this.lastXp.Value = Game1.player.experiencePoints[2];
		}

		// Token: 0x04000293 RID: 659
		private double tapperBuff;

		// Token: 0x04000294 RID: 660
		private PerScreen<int> lastXp = new PerScreen<int>();
	}
}
