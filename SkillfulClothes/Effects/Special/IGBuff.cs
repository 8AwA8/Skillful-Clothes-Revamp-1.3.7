using System;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A2 RID: 162
	internal class IGBuff : SingleEffect<IGBuffParameters>
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00004BE1 File Offset: 0x00002DE1
		// (set) Token: 0x060003AD RID: 941 RVA: 0x00004BE9 File Offset: 0x00002DE9
		private Item SourceItem { get; set; }

		// Token: 0x060003AE RID: 942 RVA: 0x00011A48 File Offset: 0x0000FC48
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			string str = EffectHelper.ModHelper.Translation.Get("Spec-BuffU");
			string buffId = base.Parameters.buffId;
			int num = 0;
			int.TryParse(buffId, out num);
			if (num == 17)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffT");
			}
			else if (num == 18)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffF");
			}
			else if (num == 25)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffN");
			}
			else if (num == 13)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffS");
			}
			else if (num == 26)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffD");
			}
			else if (num == 24)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffMM");
			}
			else if (num == 28)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffDI");
			}
			else if (num == 23)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffOOG");
			}
			else if (num == 12)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffB");
			}
			return new EffectDescriptionLine(EffectIcon.Immunity, EffectHelper.ModHelper.Translation.Get("Spec-BuffApply") + str + EffectHelper.ModHelper.Translation.Get("Spec-BuffEffect"));
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00004BF2 File Offset: 0x00002DF2
		public IGBuff(IGBuffParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00004C06 File Offset: 0x00002E06
		public IGBuff(string buffId) : base(IGBuffParameters.With(buffId))
		{
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00011BFC File Offset: 0x0000FDFC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			Buff buff = new Buff(base.Parameters.buffId, EffectHelper.ModHelper.Translation.Get("Base-SCName"), null, -1, null, -1, null, new bool?(false), null, null);
			buff.millisecondsDuration = -2;
			Game1.player.applyBuff(buff);
			this.isApplied.Value = true;
			this.SourceItem = sourceItem;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00004C1F File Offset: 0x00002E1F
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			Game1.player.buffs.Remove(base.Parameters.buffId);
			this.isApplied.Value = false;
			this.SourceItem = null;
		}

		// Token: 0x040002BA RID: 698
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
