using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B8 RID: 184
	internal class PetAnimalsOnTouch : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000443 RID: 1091 RVA: 0x0000318D File Offset: 0x0000138D
		public PetAnimalsOnTouch() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00015AD0 File Offset: 0x00013CD0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.GameLoop_UpdateTicked;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking += this.GameLoop_UpdateTicked;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00005208 File Offset: 0x00003408
		private bool canPet(FarmAnimal animal)
		{
			return Game1.timeOfDay < 1900 && !animal.wasPet.Value;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00015B20 File Offset: 0x00013D20
		private void CheckPetAnimal(GameLocation location, Farmer who)
		{
			foreach (KeyValuePair<long, FarmAnimal> keyValuePair in location.Animals.Pairs)
			{
				FarmAnimal value = keyValuePair.Value;
				if (this.canPet(value) && value.Tile.X - who.Tile.X <= 3f && value.Tile.Y - who.Tile.Y <= 3f && value.Tile.X - who.Tile.X >= -3f && value.Tile.Y - who.Tile.Y >= -3f)
				{
					value.pet(who, false);
				}
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00005226 File Offset: 0x00003426
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.GameLoop_UpdateTicked;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00005248 File Offset: 0x00003448
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Animal_Cow, EffectHelper.ModHelper.Translation.Get("Animal-Any"));
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0000526A File Offset: 0x0000346A
		private void GameLoop_UpdateTicked(object sender, OneSecondUpdateTickingEventArgs e)
		{
			if (!Context.IsPlayerFree || Game1.timeOfDay >= 1900)
			{
				return;
			}
			this.CheckPetAnimal(Game1.currentLocation, Game1.player);
		}
	}
}
