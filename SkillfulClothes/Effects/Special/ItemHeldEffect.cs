using System;
using System.Collections.Generic;
using System.Linq;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A5 RID: 165
	internal class ItemHeldEffect : SingleEffect<ItemHeldEffectParameters>
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00004C98 File Offset: 0x00002E98
		// (set) Token: 0x060003BB RID: 955 RVA: 0x00004CA0 File Offset: 0x00002EA0
		private Item SourceItem { get; set; }

		// Token: 0x060003BC RID: 956 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00004CA9 File Offset: 0x00002EA9
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00004CB1 File Offset: 0x00002EB1
		public ItemHeldEffect(ItemHeldEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00004CC5 File Offset: 0x00002EC5
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-ItemH") + base.Parameters.itemId)).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00004CF3 File Offset: 0x00002EF3
		public ItemHeldEffect(string itemId, IEffect actualEffect) : base(ItemHeldEffectParameters.With(itemId, actualEffect))
		{
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00011CA0 File Offset: 0x0000FEA0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.EquipChange += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00004D0D File Offset: 0x00002F0D
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00011CF4 File Offset: 0x0000FEF4
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (Game1.player.ActiveItem == null || Game1.player.ActiveItem.Name == null || !Game1.player.ActiveItem.Name.Contains(base.Parameters.itemId))
			{
				if (this.isApplied.Value)
				{
					base.Parameters.Effect.Remove(sourceItem, reason);
					this.isApplied.Value = false;
				}
				return;
			}
			if (!this.isApplied.Value)
			{
				this.isApplied.Value = true;
				base.Parameters.Effect.Apply(sourceItem, reason);
				return;
			}
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00004D7A File Offset: 0x00002F7A
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002BE RID: 702
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002BF RID: 703
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
