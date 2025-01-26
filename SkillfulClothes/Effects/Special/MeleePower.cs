using System;
using System.Collections.Generic;
using System.Linq;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000095 RID: 149
	internal class MeleePower : SingleEffect<MeleePowerParameters>
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000352 RID: 850 RVA: 0x000046C0 File Offset: 0x000028C0
		// (set) Token: 0x06000353 RID: 851 RVA: 0x000046C8 File Offset: 0x000028C8
		private Item SourceItem { get; set; }

		// Token: 0x06000354 RID: 852 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000046D1 File Offset: 0x000028D1
		public MeleePower(MeleePowerParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000046E5 File Offset: 0x000028E5
		public MeleePower(IEffect actualEffect, int weaponid) : base(MeleePowerParameters.With(actualEffect, weaponid))
		{
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000EBB0 File Offset: 0x0000CDB0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.EquipChange += this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000046FF File Offset: 0x000028FF
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000EC04 File Offset: 0x0000CE04
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			MeleeWeapon meleeWeapon = Game1.player.ActiveItem as MeleeWeapon;
			if (meleeWeapon == null || (meleeWeapon.type.Value != base.Parameters.WeaponID && (meleeWeapon.type.Value != 3 || base.Parameters.WeaponID != 0) && (meleeWeapon.type.Value != 0 || base.Parameters.WeaponID != 3)))
			{
				if (this.isApplied.Value)
				{
					base.Parameters.Effect.Remove(sourceItem, reason);
					this.isApplied.Value = false;
				}
				return;
			}
			if (this.isApplied.Value)
			{
				return;
			}
			this.isApplied.Value = true;
			base.Parameters.Effect.Apply(sourceItem, reason);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000ECCC File Offset: 0x0000CECC
		public override void ReloadParameters()
		{
			if (base.Parameters.WeaponID == 0 || base.Parameters.WeaponID == 3)
			{
				this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
				select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeS"))).ToList<EffectDescriptionLine>();
				return;
			}
			if (base.Parameters.WeaponID == 1)
			{
				this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
				select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeD"))).ToList<EffectDescriptionLine>();
				return;
			}
			if (base.Parameters.WeaponID == 2)
			{
				this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
				select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeC"))).ToList<EffectDescriptionLine>();
				return;
			}
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeError"))).ToList<EffectDescriptionLine>();
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00004730 File Offset: 0x00002930
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00004738 File Offset: 0x00002938
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x0400029D RID: 669
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x0400029E RID: 670
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
