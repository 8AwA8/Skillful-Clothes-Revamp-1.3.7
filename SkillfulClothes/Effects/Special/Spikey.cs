using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000086 RID: 134
	internal class Spikey : SingleEffect<SpikeyParameters>
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0000414F File Offset: 0x0000234F
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00004157 File Offset: 0x00002357
		private Item SourceItem { get; set; }

		// Token: 0x060002F8 RID: 760 RVA: 0x00004160 File Offset: 0x00002360
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.MaxHealth, EffectHelper.ModHelper.Translation.Get("Spec-Spikey"));
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00004181 File Offset: 0x00002381
		public Spikey(SpikeyParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00004195 File Offset: 0x00002395
		public Spikey(int damage) : base(SpikeyParameters.With(damage))
		{
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000041AE File Offset: 0x000023AE
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			EffectHelper.Events.FarmerDamaged += this.Events_UpdateTicking;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000041E3 File Offset: 0x000023E3
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000D814 File Offset: 0x0000BA14
		private void Events_UpdateTicking(object sender, FarmerDamagedEventArgs e)
		{
			if (e.Farmer != Game1.player)
			{
				return;
			}
			if (Game1.player.health >= this.playerHealth.Value)
			{
				this.playerHealth.Value = Game1.player.health;
				return;
			}
			Game1.player.currentLocation.explode(Game1.player.Tile, 1, Game1.player, false, base.Parameters.ExtraDamage + (int)((float)(this.playerHealth.Value - Game1.player.health + Game1.player.buffs.Defense) * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), false);
			this.playerHealth.Value = Game1.player.health;
		}

		// Token: 0x04000284 RID: 644
		private PerScreen<int> playerHealth = new PerScreen<int>();
	}
}
