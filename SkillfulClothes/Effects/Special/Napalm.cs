using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Audio;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000088 RID: 136
	internal class Napalm : SingleEffect<NapalmParameters>
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00004221 File Offset: 0x00002421
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00004229 File Offset: 0x00002429
		private Item SourceItem { get; set; }

		// Token: 0x06000304 RID: 772 RVA: 0x00004232 File Offset: 0x00002432
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.MaxHealth, EffectHelper.ModHelper.Translation.Get("Spec-Napalm"));
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00004253 File Offset: 0x00002453
		public Napalm(NapalmParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00004267 File Offset: 0x00002467
		public Napalm(int damage) : base(NapalmParameters.With(damage))
		{
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000D8F0 File Offset: 0x0000BAF0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.World.NpcListChanged += this.Events_UpdateTicking;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00004280 File Offset: 0x00002480
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000D960 File Offset: 0x0000BB60
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
					Game1.player.playNearbySoundLocal("explosion", null, SoundContext.Default);
				}
				Game1.currentLocation.explode(Game1.player.Tile, 2 + Game1.player.Attack / 6, Game1.player, false, base.Parameters.ExtraDamage, true);
				this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			}
		}

		// Token: 0x04000287 RID: 647
		private PerScreen<int> monstersSlain = new PerScreen<int>();
	}
}
