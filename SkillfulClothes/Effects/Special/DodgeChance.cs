using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000080 RID: 128
	internal class DodgeChance : SingleEffect<DodgeChanceParameters>
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00003EF5 File Offset: 0x000020F5
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00003EFD File Offset: 0x000020FD
		private Item SourceItem { get; set; }

		// Token: 0x060002D4 RID: 724 RVA: 0x0000D3BC File Offset: 0x0000B5BC
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Immunity, EffectHelper.ModHelper.Translation.Get("Spec-GainA") + (int)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) + EffectHelper.ModHelper.Translation.Get("Spec-DodgeC"));
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00003F06 File Offset: 0x00002106
		public DodgeChance(DodgeChanceParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00003F1A File Offset: 0x0000211A
		public DodgeChance(int chance) : base(DodgeChanceParameters.With(chance))
		{
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00003F33 File Offset: 0x00002133
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			EffectHelper.Events.FarmerDamaged += this.Events_UpdateTicking;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00003F70 File Offset: 0x00002170
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000D444 File Offset: 0x0000B644
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (Game1.player.health >= this.playerHealth.Value)
			{
				this.playerHealth.Value = Game1.player.health;
				return;
			}
			if (Game1.random.Next(0, 10) < (int)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) / 10)
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.addHUDMessage(new CustomHUDMessage("Dodge!", this.SourceItem, Color.Gold, TimeSpan.FromSeconds(2.0)));
				}
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("yoba", null, SoundContext.Default);
				}
				Game1.player.health = Math.Min(this.playerHealth.Value, Game1.player.maxHealth);
				return;
			}
			this.playerHealth.Value = Game1.player.health;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00003F8F File Offset: 0x0000218F
		private void Events_UpdateTicking(object sender, FarmerDamagedEventArgs e)
		{
			if (e.Farmer == Game1.player)
			{
				this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
			}
		}

		// Token: 0x0400027E RID: 638
		private PerScreen<int> playerHealth = new PerScreen<int>();
	}
}
