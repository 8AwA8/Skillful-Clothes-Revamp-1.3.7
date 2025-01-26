using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000093 RID: 147
	internal class Mercenery : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000347 RID: 839 RVA: 0x0000461A File Offset: 0x0000281A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillCombat, EffectHelper.ModHelper.Translation.Get("Spec-Mercen"));
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000463C File Offset: 0x0000283C
		public Mercenery() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000E99C File Offset: 0x0000CB9C
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.lastkills.Value = (int)Game1.player.stats.MonstersKilled;
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000EA04 File Offset: 0x0000CC04
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			int monstersKilled = (int)Game1.player.stats.MonstersKilled;
			if (this.lastkills.Value < monstersKilled)
			{
				foreach (Item item in e.Added)
				{
					if (item != null && (item.Category == -28 || item.ItemId == "413" || item.ItemId == "437" || item.ItemId == "439" || item.ItemId == "680" || item.ItemId == "766" || item.ItemId == "857"))
					{
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("moneyDial", null, SoundContext.Default);
						}
						Game1.player.Money += (int)((float)item.salePrice(false) * (float)item.Stack * Game1.MasterPlayer.difficultyModifier * Math.Max(2.5f, 2.5f + (float)Game1.player.CombatLevel / 7f) * 0.5f * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f));
						Game1.player.removeItemFromInventory(item);
					}
				}
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00004654 File Offset: 0x00002854
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x04000299 RID: 665
		private PerScreen<int> lastkills = new PerScreen<int>();
	}
}
