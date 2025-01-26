using System;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x020000B9 RID: 185
	internal class FarmerDamagedEventArgs : EventArgs
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x00005290 File Offset: 0x00003490
		public Farmer Farmer { get; }

		// Token: 0x0600044B RID: 1099 RVA: 0x00005298 File Offset: 0x00003498
		public FarmerDamagedEventArgs(Farmer farmer)
		{
			this.Farmer = farmer;
		}
	}
}
