using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.BellsAndWhistles;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A9 RID: 169
	internal class SetBonusReal : SingleEffect<SetBonusRealParameters>
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00004E35 File Offset: 0x00003035
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x00004E3D File Offset: 0x0000303D
		private Item SourceItem { get; set; }

		// Token: 0x060003D9 RID: 985 RVA: 0x00003C1A File Offset: 0x00001E1A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00004E46 File Offset: 0x00003046
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00004E4E File Offset: 0x0000304E
		public SetBonusReal(SetBonusRealParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00011FAC File Offset: 0x000101AC
		public override void ReloadParameters()
		{
			EffectIcon icon = this.iconFromName(base.Parameters.iconName);
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(icon, EffectHelper.ModHelper.Translation.Get("SetBonusTitle") + this.CheckForTranslation(this.Parameters.setBonus) + ": " + x.Text)).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001200C File Offset: 0x0001020C
		public SetBonusReal(string hat, string shirt, string pants, string setBonus, string iconName, IEffect actualEffect) : base(SetBonusRealParameters.With(hat, shirt, pants, setBonus, iconName, actualEffect))
		{
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001205C File Offset: 0x0001025C
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, EffectChangeReason.ItemPutOn);
			EffectHelper.Events.ClothingChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.ClothingChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00004E83 File Offset: 0x00003083
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.Events.ClothingChanged -= this.GameLoop_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x000120B0 File Offset: 0x000102B0
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.hat != "")
			{
				if (Game1.player.hat.Value != null)
				{
					if (Game1.player.hat.Value.ItemId == base.Parameters.hat)
					{
						this.correctHat.Value = true;
					}
					else
					{
						this.correctHat.Value = false;
					}
				}
				else
				{
					this.correctHat.Value = false;
				}
			}
			else
			{
				this.correctHat.Value = true;
			}
			if (base.Parameters.shirt != "")
			{
				if (Game1.player.shirtItem.Value != null)
				{
					if (Game1.player.shirtItem.Value.ItemId == base.Parameters.shirt)
					{
						this.correctShirt.Value = true;
					}
					else
					{
						this.correctShirt.Value = false;
					}
				}
				else
				{
					this.correctShirt.Value = false;
				}
			}
			else
			{
				this.correctShirt.Value = true;
			}
			if (base.Parameters.pants != "")
			{
				if (Game1.player.pantsItem.Value != null)
				{
					if (Game1.player.pantsItem.Value.ItemId == base.Parameters.pants)
					{
						this.correctPants.Value = true;
					}
					else
					{
						this.correctPants.Value = false;
					}
				}
				else
				{
					this.correctPants.Value = false;
				}
			}
			else
			{
				this.correctPants.Value = true;
			}
			if (this.correctHat.Value && this.correctPants.Value && this.correctShirt.Value)
			{
				if (!this.isApplied.Value)
				{
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
					{
						EffectHelper.Overlays.AddSparklingText(new SparklingText(Game1.dialogueFont, EffectHelper.ModHelper.Translation.Get("SetBonusText"), Color.Purple, Color.Azure, true, 0.3, 5000, -1, 500, 1f), new Vector2(64f, (float)(Game1.uiViewport.Height - 82)));
					}
					this.isApplied.Value = true;
					base.Parameters.Effect.Apply(sourceItem, reason);
					return;
				}
			}
			else if (this.isApplied.Value)
			{
				this.isApplied.Value = false;
				base.Parameters.Effect.Remove(sourceItem, reason);
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00012350 File Offset: 0x00010550
		private EffectIcon iconFromName(string name)
		{
			if (name == "Popularity")
			{
				return EffectIcon.Popularity;
			}
			if (name == "Attack")
			{
				return EffectIcon.Attack;
			}
			if (name == "Defense")
			{
				return EffectIcon.Defense;
			}
			if (name == "CriticalHitRate")
			{
				return EffectIcon.CriticalHitRate;
			}
			if (name == "Immunity")
			{
				return EffectIcon.Immunity;
			}
			if (name == "Speed")
			{
				return EffectIcon.Speed;
			}
			if (name == "SaveFromDeath")
			{
				return EffectIcon.SaveFromDeath;
			}
			if (name == "Yoba")
			{
				return EffectIcon.Yoba;
			}
			if (name == "TreasureChest")
			{
				return EffectIcon.TreasureChest;
			}
			if (name == "Chicken")
			{
				return EffectIcon.Animal_Chicken;
			}
			if (name == "Cow")
			{
				return EffectIcon.Animal_Cow;
			}
			if (name == "Glow")
			{
				return EffectIcon.Glow;
			}
			if (name == "Money")
			{
				return EffectIcon.Money;
			}
			if (name == "Red")
			{
				return EffectIcon.Red2;
			}
			if (name == "Blue")
			{
				return EffectIcon.Blue;
			}
			if (name == "Yellow")
			{
				return EffectIcon.Yellow;
			}
			if (name == "Lewis")
			{
				return EffectIcon.Person_Lewis;
			}
			if (name == "Fire")
			{
				return EffectIcon.Fire;
			}
			if (name == "Crown")
			{
				return EffectIcon.Crown;
			}
			if (name == "Iridium")
			{
				return EffectIcon.Iridium;
			}
			if (name == "DustSprite")
			{
				return EffectIcon.DustSprite;
			}
			if (name == "Stardrop")
			{
				return EffectIcon.Stardrop;
			}
			if (name == "Crab")
			{
				return EffectIcon.Crab;
			}
			if (name == "CandyCane")
			{
				return EffectIcon.CandyCane;
			}
			if (name == "Pumpkin")
			{
				return EffectIcon.Pumpkin;
			}
			if (name == "Heart")
			{
				return EffectIcon.Heart;
			}
			if (name == "Swirl")
			{
				return EffectIcon.Swirl;
			}
			if (name == "Lightning")
			{
				return EffectIcon.Lightning;
			}
			if (name == "Clover")
			{
				return EffectIcon.Clover;
			}
			if (name == "Dwarf")
			{
				return EffectIcon.Dwarf;
			}
			if (name == "Krobus")
			{
				return EffectIcon.Krobus;
			}
			return EffectIcon.Stardrop;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001254C File Offset: 0x0001074C
		private string CheckForTranslation(string s)
		{
			if (s == "Diggy Diggy:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus1");
			}
			if (s == "Eonic Tribute:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus2");
			}
			if (s == "Ruler of Infinity:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus3");
			}
			if (s == "Miderian Finale:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus4");
			}
			if (s == "Spook:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus5");
			}
			if (s == "Truly Magic:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus6");
			}
			if (s == "Eclipse:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus7");
			}
			if (s == "Hidden Treasure:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus8");
			}
			if (s == "Street Smarts:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus9");
			}
			if (s == "Decorated Past:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus10");
			}
			if (s == "Vigil Ascension:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus11");
			}
			if (s == "No Will To Break:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus12");
			}
			if (s == "Jolly:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus13");
			}
			if (s == "Running River:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus14");
			}
			if (s == "Siren:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus15");
			}
			if (s == "Michelin Star:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus16");
			}
			if (s == "Season of Luck:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus17");
			}
			if (s == "Prairie Friend:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus18");
			}
			if (s == "Salem's Fallout:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus19");
			}
			if (s == "Why Go Alone?:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus20");
			}
			if (s == "Clown Around:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus21");
			}
			if (s == "Wild:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus22");
			}
			if (s == "One WIth Nature:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus23");
			}
			if (s == "Squawk Proud:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus24");
			}
			return s;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00004EC0 File Offset: 0x000030C0
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002C7 RID: 711
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002C8 RID: 712
		private PerScreen<bool> isApplied = new PerScreen<bool>();

		// Token: 0x040002C9 RID: 713
		private PerScreen<bool> correctHat = new PerScreen<bool>();

		// Token: 0x040002CA RID: 714
		private PerScreen<bool> correctShirt = new PerScreen<bool>();

		// Token: 0x040002CB RID: 715
		private PerScreen<bool> correctPants = new PerScreen<bool>();
	}
}
