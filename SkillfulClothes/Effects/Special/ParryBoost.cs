using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000082 RID: 130
	internal class ParryBoost : SingleEffect<NoEffectParameters>
	{
		// Token: 0x060002E0 RID: 736 RVA: 0x00003FEF File Offset: 0x000021EF
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Attack, EffectHelper.ModHelper.Translation.Get("Spec-Parry"));
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000318D File Offset: 0x0000138D
		public ParryBoost() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00004010 File Offset: 0x00002210
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.SpecialUsed -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.SpecialUsed += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000403E File Offset: 0x0000223E
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.SpecialUsed -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00004056 File Offset: 0x00002256
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			MeleeWeapon.defenseCooldown = 0;
		}
	}
}
