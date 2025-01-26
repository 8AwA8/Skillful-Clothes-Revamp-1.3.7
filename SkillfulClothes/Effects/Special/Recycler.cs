using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000092 RID: 146
	internal class Recycler : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000342 RID: 834 RVA: 0x000045D7 File Offset: 0x000027D7
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Popularity, EffectHelper.ModHelper.Translation.Get("Spec-Recyler"));
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000318D File Offset: 0x0000138D
		public Recycler() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000E834 File Offset: 0x0000CA34
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000E884 File Offset: 0x0000CA84
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			foreach (Item item in e.Added)
			{
				if (item != null && item.Category == -20)
				{
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("moneyDial", null, SoundContext.Default);
					}
					Game1.player.Money += (int)((float)((20 + 6 * Game1.player.fishingLevel) * item.Stack) * Game1.player.difficultyModifier * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f));
					StardewValley.Object item2 = new StardewValley.Object("DeluxeBait", item.Stack, false, -1, 0);
					Game1.player.removeItemFromInventory(item);
					Game1.player.addItemToInventory(item2);
				}
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x000045F8 File Offset: 0x000027F8
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
		}
	}
}
