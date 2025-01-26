using System;
using System.Runtime.CompilerServices;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004E RID: 78
	internal class MultiplyExperience : SingleEffect<MultiplyExperienceParameters>
	{
		// Token: 0x06000196 RID: 406 RVA: 0x0000AA2C File Offset: 0x00008C2C
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(base.Parameters.Skill.GetIcon(), EffectHelper.ModHelper.Translation.Get("EXP-Inc") + EffectHelper.ModHelper.Translation.Get("Skills-" + base.Parameters.Skill.ToString()) + EffectHelper.ModHelper.Translation.Get("EXP-Exp"));
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000032D4 File Offset: 0x000014D4
		public MultiplyExperience(MultiplyExperienceParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000032E8 File Offset: 0x000014E8
		public MultiplyExperience(Skill skill, float multiplier) : base(MultiplyExperienceParameters.With(skill, multiplier))
		{
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000AABC File Offset: 0x00008CBC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.lastXp.Value = Game1.player.experiencePoints[(int)base.Parameters.Skill];
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00003302 File Offset: 0x00001502
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000AB30 File Offset: 0x00008D30
		private void GameLoop_UpdateTicking(object sender, TimeChangedEventArgs e)
		{
			if (!this.lastXp.IsActiveForScreen())
			{
				this.lastXp.Value = Game1.player.experiencePoints[(int)base.Parameters.Skill];
				return;
			}
			int num = Game1.player.experiencePoints[(int)base.Parameters.Skill];
			int value = this.lastXp.Value;
			int num2 = num;
			int? num3 = new int?(this.lastXp.Value);
			if (num2 > num3.GetValueOrDefault() & num3 != null)
			{
				int num4 = num - this.lastXp.Value;
				int num5 = (int)((float)num4 * (base.Parameters.Multiplier - 1f) * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f));
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
				defaultInterpolatedStringHandler.AppendLiteral("XP = ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
				defaultInterpolatedStringHandler.AppendLiteral(" + ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num5);
				Logger.Debug(defaultInterpolatedStringHandler.ToStringAndClear());
				Game1.player.gainExperience((int)base.Parameters.Skill, num5);
			}
			this.lastXp.Value = Game1.player.experiencePoints[(int)base.Parameters.Skill];
		}

		// Token: 0x04000225 RID: 549
		private PerScreen<int> lastXp = new PerScreen<int>();
	}
}
