using System;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x02000005 RID: 5
	internal class ClothingObserver
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000053F0 File Offset: 0x000035F0
		public ClothingObserver()
		{
			this.shoesObserver = new ShoesObserver();
			if (EffectHelper.Config.EnableShirtEffects)
			{
				this.shirtObserver = new ShirtObserver();
				Logger.Info("Shirt effects will be active");
			}
			else
			{
				ItemDefinitions.ShirtEffects.Clear();
				Logger.Info("Shirt effects have been disabled");
			}
			if (EffectHelper.Config.EnablePantsEffects)
			{
				this.pantsObserver = new PantsObserver();
				Logger.Info("Pants effects will be active");
			}
			else
			{
				ItemDefinitions.PantsEffects.Clear();
				Logger.Info("Pants effects have been disabled");
			}
			if (EffectHelper.Config.EnableHatEffects)
			{
				this.hatObserver = new HatObserver();
				Logger.Info("Hat effects will be active");
				return;
			}
			ItemDefinitions.HatEffects.Clear();
			Logger.Info("Hat effects have been disabled");
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000054B4 File Offset: 0x000036B4
		public bool HasRingEffect(string ringId)
		{
			ShirtObserver shirtObserver = this.shirtObserver;
			if (shirtObserver == null || !shirtObserver.HasRingEffect(ringId))
			{
				PantsObserver pantsObserver = this.pantsObserver;
				if (pantsObserver == null || !pantsObserver.HasRingEffect(ringId))
				{
					HatObserver hatObserver = this.hatObserver;
					if (hatObserver == null || !hatObserver.HasRingEffect(ringId))
					{
						ShoesObserver shoesObserver = this.shoesObserver;
						return shoesObserver != null && shoesObserver.HasRingEffect(ringId);
					}
				}
			}
			return true;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00005510 File Offset: 0x00003710
		public void Reset(Farmer farmer)
		{
			ShirtObserver shirtObserver = this.shirtObserver;
			if (shirtObserver != null)
			{
				shirtObserver.Reset(Game1.player);
			}
			PantsObserver pantsObserver = this.pantsObserver;
			if (pantsObserver != null)
			{
				pantsObserver.Reset(Game1.player);
			}
			ShoesObserver shoesObserver = this.shoesObserver;
			if (shoesObserver != null)
			{
				shoesObserver.Reset(Game1.player);
			}
			HatObserver hatObserver = this.hatObserver;
			if (hatObserver == null)
			{
				return;
			}
			hatObserver.Reset(Game1.player);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00005574 File Offset: 0x00003774
		public void Restore(Farmer farmer, EffectChangeReason reason)
		{
			ShirtObserver shirtObserver = this.shirtObserver;
			if (shirtObserver != null)
			{
				shirtObserver.Restore(farmer, reason);
			}
			PantsObserver pantsObserver = this.pantsObserver;
			if (pantsObserver != null)
			{
				pantsObserver.Restore(farmer, reason);
			}
			ShoesObserver shoesObserver = this.shoesObserver;
			if (shoesObserver != null)
			{
				shoesObserver.Restore(farmer, reason);
			}
			HatObserver hatObserver = this.hatObserver;
			if (hatObserver == null)
			{
				return;
			}
			hatObserver.Restore(farmer, reason);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000055CC File Offset: 0x000037CC
		public void Suspend(Farmer farmer, EffectChangeReason reason)
		{
			ShirtObserver shirtObserver = this.shirtObserver;
			if (shirtObserver != null)
			{
				shirtObserver.Suspend(farmer, reason);
			}
			PantsObserver pantsObserver = this.pantsObserver;
			if (pantsObserver != null)
			{
				pantsObserver.Suspend(farmer, reason);
			}
			ShoesObserver shoesObserver = this.shoesObserver;
			if (shoesObserver != null)
			{
				shoesObserver.Suspend(farmer, reason);
			}
			HatObserver hatObserver = this.hatObserver;
			if (hatObserver == null)
			{
				return;
			}
			hatObserver.Suspend(farmer, reason);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00005624 File Offset: 0x00003824
		public void Update(Farmer farmer)
		{
			ShirtObserver shirtObserver = this.shirtObserver;
			if (shirtObserver != null)
			{
				shirtObserver.Update(farmer);
			}
			PantsObserver pantsObserver = this.pantsObserver;
			if (pantsObserver != null)
			{
				pantsObserver.Update(farmer);
			}
			ShoesObserver shoesObserver = this.shoesObserver;
			if (shoesObserver != null)
			{
				shoesObserver.Update(farmer);
			}
			HatObserver hatObserver = this.hatObserver;
			if (hatObserver == null)
			{
				return;
			}
			hatObserver.Update(farmer);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00005678 File Offset: 0x00003878
		public void UpdateHat(Farmer farmer)
		{
			HatObserver hatObserver = this.hatObserver;
			if (hatObserver == null)
			{
				return;
			}
			hatObserver.Update(farmer);
		}

		// Token: 0x04000003 RID: 3
		private ShirtObserver shirtObserver;

		// Token: 0x04000004 RID: 4
		private PantsObserver pantsObserver;

		// Token: 0x04000005 RID: 5
		private HatObserver hatObserver;

		// Token: 0x04000006 RID: 6
		private ShoesObserver shoesObserver;
	}
}
