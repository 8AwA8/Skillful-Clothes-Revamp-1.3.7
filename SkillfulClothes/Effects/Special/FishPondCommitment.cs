using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008D RID: 141
	internal class FishPondCommitment : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000324 RID: 804 RVA: 0x0000441C File Offset: 0x0000261C
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFishing, EffectHelper.ModHelper.Translation.Get("Spec-FPC"));
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000318D File Offset: 0x0000138D
		public FishPondCommitment() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000DF60 File Offset: 0x0000C160
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000DFB0 File Offset: 0x0000C1B0
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			foreach (Item item in e.Added)
			{
				if (item != null && item.QualifiedItemId == "(O)812")
				{
					ColoredObject coloredObject = new ColoredObject("447", item.Stack * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1 : 2), TailoringMenu.GetDyeColor(item) ?? Color.Orange);
					coloredObject.Name = "Efficiently Aged " + item.Name;
					coloredObject.Price = (int)((double)((float)item.salePrice(false)) * (double)((float)Game1.player.FishingLevel / 7f) * (double)Game1.player.difficultyModifier);
					coloredObject.Quality = 2;
					Game1.player.removeItemFromInventory(item);
					Game1.player.addItemToInventory(coloredObject);
				}
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000443E File Offset: 0x0000263E
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
		}
	}
}
