using System;
using System.Collections.Generic;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B5 RID: 181
	internal class IncreasePopularityAdvanced : SingleEffect<IncreasePopularityParameters>
	{
		// Token: 0x06000424 RID: 1060 RVA: 0x00015414 File Offset: 0x00013614
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Popularity, EffectHelper.ModHelper.Translation.Get("Spec-Pop") + " (" + MathF.Round(1f + (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f, 4).ToString() + "x) ");
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x000154A0 File Offset: 0x000136A0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SetUpFriendshipDictionary();
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00005026 File Offset: 0x00003226
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00005048 File Offset: 0x00003248
		public IncreasePopularityAdvanced(IncreasePopularityParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000505C File Offset: 0x0000325C
		public IncreasePopularityAdvanced(int Amount) : base(IncreasePopularityParameters.With(Amount))
		{
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000154F4 File Offset: 0x000136F4
		private void GameLoop_UpdateTicking(object sender, TimeChangedEventArgs e)
		{
			if (!this.currentPoints.IsActiveForScreen())
			{
				this.SetUpFriendshipDictionary();
			}
			foreach (string key in Game1.player.friendshipData.Keys)
			{
				Friendship friendship = Game1.player.friendshipData[key];
				int num;
				if (this.currentPoints.Value.TryGetValue(key, out num) && friendship.Points > num)
				{
					float num2 = (float)(friendship.Points - num) * ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) / 100f;
					friendship.Points = (int)((float)friendship.Points + num2);
				}
				this.currentPoints.Value[key] = friendship.Points;
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00015604 File Offset: 0x00013804
		private void SetUpFriendshipDictionary()
		{
			this.currentPoints.Value = new Dictionary<string, int>();
			foreach (string key in Game1.player.friendshipData.Keys)
			{
				this.currentPoints.Value.Add(key, Game1.player.friendshipData[key].Points);
			}
		}

		// Token: 0x040002E0 RID: 736
		private PerScreen<Dictionary<string, int>> currentPoints = new PerScreen<Dictionary<string, int>>();
	}
}
