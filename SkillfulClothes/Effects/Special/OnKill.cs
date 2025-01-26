using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008A RID: 138
	internal class OnKill : SingleEffect<OnKillParameters>
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000042E0 File Offset: 0x000024E0
		// (set) Token: 0x06000311 RID: 785 RVA: 0x000042E8 File Offset: 0x000024E8
		private Item SourceItem { get; set; }

		// Token: 0x06000312 RID: 786 RVA: 0x0000DA0C File Offset: 0x0000BC0C
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			if (base.Parameters.UniqueEff == 0)
			{
				return new EffectDescriptionLine(EffectIcon.SaveFromDeath, EffectHelper.ModHelper.Translation.Get("OK-Gain") + MathF.Round((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f), 2) + EffectHelper.ModHelper.Translation.Get("OK-EN"));
			}
			return new EffectDescriptionLine(EffectIcon.SaveFromDeath, EffectHelper.ModHelper.Translation.Get("OK-Gain") + MathF.Round((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f), 2) + EffectHelper.ModHelper.Translation.Get("OK-HP"));
		}

		// Token: 0x06000313 RID: 787 RVA: 0x000042F1 File Offset: 0x000024F1
		public OnKill(OnKillParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00004305 File Offset: 0x00002505
		public OnKill(int UniqueEff, int amount) : base(OnKillParameters.With(UniqueEff, amount))
		{
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000DB24 File Offset: 0x0000BD24
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.World.NpcListChanged += this.Events_UpdateTicking;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000431F File Offset: 0x0000251F
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000DB94 File Offset: 0x0000BD94
		private void Events_UpdateTicking(object sender, NpcListChangedEventArgs e)
		{
			if (!e.IsCurrentLocation)
			{
				return;
			}
			if (this.monstersSlain.Value < (int)Game1.player.stats.MonstersKilled)
			{
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("healSound", null, SoundContext.Default);
				}
				if (base.Parameters.UniqueEff == 0)
				{
					if (Game1.player.stamina + (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) < (float)Game1.player.MaxStamina)
					{
						Game1.player.stamina += (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
					}
					else
					{
						Game1.player.stamina = (float)Game1.player.MaxStamina;
					}
				}
				else if (Game1.player.health + (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) < Game1.player.maxHealth)
				{
					Game1.player.health += (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f));
				}
				else
				{
					Game1.player.health = Game1.player.maxHealth;
				}
				this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			}
		}

		// Token: 0x0400028B RID: 651
		private PerScreen<int> monstersSlain = new PerScreen<int>();
	}
}
