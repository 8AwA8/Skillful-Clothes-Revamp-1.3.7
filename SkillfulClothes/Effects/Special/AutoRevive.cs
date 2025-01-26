using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000044 RID: 68
	internal class AutoRevive : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600015D RID: 349 RVA: 0x00002FE6 File Offset: 0x000011E6
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SaveFromDeath, EffectHelper.ModHelper.Translation.Get("Spec-AR"));
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00003008 File Offset: 0x00001208
		public AutoRevive() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00003020 File Offset: 0x00001220
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.FarmerDamaged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000304E File Offset: 0x0000124E
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00009CD0 File Offset: 0x00007ED0
		private void GameLoop_UpdateTicking(object sender, FarmerDamagedEventArgs e)
		{
			if (e.Farmer != Game1.player)
			{
				return;
			}
			if (Game1.player.health <= 0 && this.day.Value != Game1.dayOfMonth && (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes || (this.day.Value != Game1.dayOfMonth - 1 && this.day.Value != 31 && Game1.dayOfMonth != 1)))
			{
				this.day.Value = Game1.dayOfMonth;
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("cowboy_explosion", null, SoundContext.Default);
				}
				Game1.currentLocation.explode(Game1.player.Tile, 5, Game1.player, false, 5, false);
				Game1.player.health = Game1.player.maxHealth / 2;
			}
		}

		// Token: 0x04000213 RID: 531
		private PerScreen<int> day = new PerScreen<int>();
	}
}
