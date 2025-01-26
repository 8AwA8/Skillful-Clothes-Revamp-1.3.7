using System;
using System.Collections.Generic;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000091 RID: 145
	internal class ProfessionalForager : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600033D RID: 829 RVA: 0x0000457B File Offset: 0x0000277B
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillForaging, EffectHelper.ModHelper.Translation.Get("Spec-ProfFor"));
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000459D File Offset: 0x0000279D
		public ProfessionalForager() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000E630 File Offset: 0x0000C830
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.lastxp.Value = Game1.player.experiencePoints[2];
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000E698 File Offset: 0x0000C898
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			int num = Game1.player.experiencePoints[2];
			if (this.lastxp.Value < num)
			{
				this.lastxp.Value = num;
				using (IEnumerator<Item> enumerator = e.Added.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						if (item != null && ((item.Category > -82 && item.Category < -78 && item.ItemId != "430") || item.ItemId == "259"))
						{
							if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
							{
								Game1.player.playNearbySoundLocal("moneyDial", null, SoundContext.Default);
							}
							Game1.player.Money += (int)((double)((float)item.salePrice(false)) * (double)(1f + (float)Game1.player.ForagingLevel / 10f) * (double)((float)item.Stack) * (double)Game1.MasterPlayer.difficultyModifier * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0) * (double)((float)(1.0 + (double)item.Quality * 0.25)));
							Game1.player.removeItemFromInventory(item);
						}
					}
					return;
				}
			}
			this.lastxp.Value = num;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x000045B5 File Offset: 0x000027B5
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x04000298 RID: 664
		private PerScreen<int> lastxp = new PerScreen<int>();
	}
}
