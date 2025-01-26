using System;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004C RID: 76
	internal class LewisDisapprovesEffect : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600018B RID: 395 RVA: 0x0000318D File Offset: 0x0000138D
		public LewisDisapprovesEffect() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00003222 File Offset: 0x00001422
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.InteractedWithNPC -= this.Events_InteractedWithNPC;
			EffectHelper.Events.InteractedWithNPC += this.Events_InteractedWithNPC;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00003250 File Offset: 0x00001450
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.InteractedWithNPC -= this.Events_InteractedWithNPC;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000A9D8 File Offset: 0x00008BD8
		private void Events_InteractedWithNPC(object sender, InteractedWithNPCEventArgs e)
		{
			if (e.Npc.id == 17)
			{
				Game1.addHUDMessage(new HUDMessage(EffectHelper.ModHelper.Translation.Get("Spec-LewHUD")));
				Game1.player.changeFriendship(-10, e.Npc);
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00003268 File Offset: 0x00001468
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Person_Lewis, EffectHelper.ModHelper.Translation.Get("Spec-Lew"));
		}

		// Token: 0x04000222 RID: 546
		private const int LewisNpcId = 17;
	}
}
