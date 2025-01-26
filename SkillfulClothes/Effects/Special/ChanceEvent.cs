using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Events;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000BB RID: 187
	internal class ChanceEvent : SingleEffect<ChanceEventParameters>
	{
		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x000052DE File Offset: 0x000034DE
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x000052E6 File Offset: 0x000034E6
		private Item SourceItem { get; set; }

		// Token: 0x06000454 RID: 1108 RVA: 0x00015C10 File Offset: 0x00013E10
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Swirl, string.Concat(new object[]
			{
				(int)((float)Math.Abs(base.Parameters.Chance) * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)),
				"% ",
				this.Name(),
				" ",
				(base.Parameters.Chance < 0) ? EffectHelper.ModHelper.Translation.Get("EventHelp1") : EffectHelper.ModHelper.Translation.Get("EventHelp2")
			}));
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000052EF File Offset: 0x000034EF
		public ChanceEvent(ChanceEventParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00005303 File Offset: 0x00003503
		public ChanceEvent(int chance, int code) : base(ChanceEventParameters.With(chance, code))
		{
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00015CC8 File Offset: 0x00013EC8
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			if (this.day.Value == Game1.dayOfMonth)
			{
				return;
			}
			this.day.Value = Game1.dayOfMonth;
			if (base.Parameters.Chance < 0)
			{
				switch (base.Parameters.Code)
				{
				case 0:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is FairyEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is FairyEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				case 1:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is WitchEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is WitchEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				case 2:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is SoundInTheNightEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is SoundInTheNightEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				case 3:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is SoundInTheNightEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is SoundInTheNightEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				default:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is SoundInTheNightEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is SoundInTheNightEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				}
			}
			FarmEvent farmEvent = Game1.farmEvent;
			switch (base.Parameters.Code)
			{
			case 0:
				farmEvent = new FairyEvent();
				break;
			case 1:
				farmEvent = new WitchEvent();
				break;
			case 2:
				farmEvent = new SoundInTheNightEvent(0);
				break;
			case 3:
				farmEvent = new SoundInTheNightEvent(1);
				break;
			default:
				farmEvent = new SoundInTheNightEvent(3);
				break;
			}
			if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
			{
				Game1.farmEventOverride = ((Game1.farmEventOverride == null) ? farmEvent : Game1.farmEventOverride);
				return;
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000531D File Offset: 0x0000351D
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = null;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00016054 File Offset: 0x00014254
		private string Name()
		{
			if (base.Parameters.Code == 0)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode0");
			}
			if (base.Parameters.Code == 1)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode1");
			}
			if (base.Parameters.Code == 2)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode2");
			}
			if (base.Parameters.Code == 3)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode3");
			}
			return EffectHelper.ModHelper.Translation.Get("NightCode4");
		}

		// Token: 0x040002EB RID: 747
		private PerScreen<int> day = new PerScreen<int>();
	}
}
