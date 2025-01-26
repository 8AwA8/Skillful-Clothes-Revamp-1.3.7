using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Audio;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000081 RID: 129
	internal class AutoWater : SingleEffect<NoEffectParameters>
	{
		// Token: 0x060002DB RID: 731 RVA: 0x00003FAB File Offset: 0x000021AB
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFarming, EffectHelper.ModHelper.Translation.Get("Spec-AW"));
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000318D File Offset: 0x0000138D
		public AutoWater() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000D574 File Offset: 0x0000B774
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000D5C4 File Offset: 0x0000B7C4
		private void GameLoop_UpdateTicking(object sender, UpdateTickingEventArgs e)
		{
			if (Context.IsPlayerFree && Game1.player.currentLocation.isTileHoeDirt(Game1.player.Tile) && !Game1.player.currentLocation.GetHoeDirtAtTile(Game1.player.Tile).isWatered() && Game1.player.stamina > 0f && ((Game1.player.ActiveItem != null && Game1.player.ActiveItem is WateringCan && (Game1.player.ActiveItem as WateringCan).WaterLeft >= 1) || !EffectHelper.Config.AutoWaterCanReq))
			{
				Game1.player.currentLocation.GetHoeDirtAtTile(Game1.player.Tile).state.Value = 1;
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("wateringCan", null, SoundContext.Default);
				}
				Game1.player.stamina = Game1.player.stamina - Math.Max(1f - (float)Game1.player.FarmingLevel / 18f, 0f);
				if (EffectHelper.Config.AutoWaterCanReq)
				{
					(Game1.player.ActiveItem as WateringCan).WaterLeft = Math.Max(0, (Game1.player.ActiveItem as WateringCan).WaterLeft - 1);
				}
				return;
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00003FCD File Offset: 0x000021CD
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking -= this.GameLoop_UpdateTicking;
		}
	}
}
