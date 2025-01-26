using System;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000084 RID: 132
	internal class RangedPower : SingleEffect<RangedPowerParameters>
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00004090 File Offset: 0x00002290
		// (set) Token: 0x060002EA RID: 746 RVA: 0x00004098 File Offset: 0x00002298
		private Item SourceItem { get; set; }

		// Token: 0x060002EB RID: 747 RVA: 0x000040A1 File Offset: 0x000022A1
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillCombat, EffectHelper.ModHelper.Translation.Get("Spec-Ranged"));
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000040C3 File Offset: 0x000022C3
		public RangedPower(RangedPowerParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000040D7 File Offset: 0x000022D7
		public RangedPower(IEffect actualEffect) : base(RangedPowerParameters.With(actualEffect))
		{
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000D734 File Offset: 0x0000B934
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.EquipChange += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000040F0 File Offset: 0x000022F0
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000D788 File Offset: 0x0000B988
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (Game1.player.ActiveItem == null || !Game1.player.ActiveItem.Name.Contains("Slingshot"))
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

		// Token: 0x060002F1 RID: 753 RVA: 0x00004121 File Offset: 0x00002321
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x04000281 RID: 641
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
