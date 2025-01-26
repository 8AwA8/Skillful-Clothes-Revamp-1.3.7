using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Force.DeepCloner;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.GameData.Buildings;
using StardewValley.Menus;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000045 RID: 69
	internal class ConstructDiscount : SingleEffect<ConstructDiscountParameters>
	{
		// Token: 0x06000162 RID: 354 RVA: 0x00003066 File Offset: 0x00001266
		public ConstructDiscount(ConstructDiscountParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000306F File Offset: 0x0000126F
		public ConstructDiscount(double discount) : base(ConstructDiscountParameters.With(discount))
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00009DBC File Offset: 0x00007FBC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
			EffectHelper.ModHelper.Events.Display.MenuChanged += this.Display_MenuChanged;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00009E0C File Offset: 0x0000800C
		private int applyDiscount(int value)
		{
			return (int)Math.Max(0.0, (double)value * (1.0 - base.Parameters.Discount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0)));
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00009E70 File Offset: 0x00008070
		private void Display_MenuChanged(object sender, MenuChangedEventArgs e)
		{
			GameLocation currentLocation = Game1.currentLocation;
			if (((currentLocation != null) ? currentLocation.NameOrUniqueName : null) == "ScienceHouse")
			{
				CarpenterMenu carpenterMenu = e.NewMenu as CarpenterMenu;
				if (carpenterMenu != null)
				{
					foreach (CarpenterMenu.BlueprintEntry blueprintEntry in carpenterMenu.Blueprints)
					{
						BuildingSkin buildingSkin;
						if (blueprintEntry.Skin == null)
						{
							buildingSkin = new BuildingSkin();
							buildingSkin.BuildCost = new int?(this.applyDiscount(blueprintEntry.Data.BuildCost));
							if (blueprintEntry.Data.BuildMaterials != null)
							{
								buildingSkin.BuildMaterials = (from x in blueprintEntry.Data.BuildMaterials
								select x.DeepClone<BuildingMaterial>()).ToList<BuildingMaterial>();
							}
						}
						else
						{
							buildingSkin = blueprintEntry.Skin.DeepClone<BuildingSkin>();
							buildingSkin.BuildCost = new int?(this.applyDiscount(blueprintEntry.Skin.BuildCost.Value));
						}
						if (buildingSkin.BuildMaterials != null)
						{
							foreach (BuildingMaterial buildingMaterial in buildingSkin.BuildMaterials)
							{
								buildingMaterial.Amount = this.applyDiscount(buildingMaterial.Amount);
							}
						}
						EffectHelper.ModHelper.Reflection.GetProperty<BuildingSkin>(blueprintEntry, "Skin", true).SetValue(buildingSkin);
					}
					carpenterMenu.SetNewActiveBlueprint(0);
					CustomOverlays overlays = EffectHelper.Overlays;
					SpriteFont dialogueFont = Game1.dialogueFont;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
					defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Shop-Popup"));
					defaultInterpolatedStringHandler.AppendFormatted<double>(base.Parameters.Discount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0) * 100.0, "0.#");
					defaultInterpolatedStringHandler.AppendLiteral("%)");
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
					{
						overlays.AddSparklingText(new SparklingText(dialogueFont, defaultInterpolatedStringHandler.ToStringAndClear(), Color.LimeGreen, Color.Azure, false, 0.1, 2500, -1, 500, 1f), new Vector2(64f, (float)(Game1.uiViewport.Height - 64)));
					}
				}
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000307D File Offset: 0x0000127D
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000A12C File Offset: 0x0000832C
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			EffectIcon icon = EffectIcon.Red;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(53, 1);
			defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Spec-CD"));
			defaultInterpolatedStringHandler.AppendFormatted<double>(base.Parameters.Discount * 100.0 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0), "0.#");
			defaultInterpolatedStringHandler.AppendLiteral("%)");
			return new EffectDescriptionLine(icon, defaultInterpolatedStringHandler.ToStringAndClear());
		}
	}
}
