using System;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x0200000B RID: 11
	internal class EffectHelperEvents
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000029 RID: 41 RVA: 0x000059E8 File Offset: 0x00003BE8
		// (remove) Token: 0x0600002A RID: 42 RVA: 0x00005A20 File Offset: 0x00003C20
		public event EventHandler<InteractedWithNPCEventArgs> InteractedWithNPC;

		// Token: 0x0600002B RID: 43 RVA: 0x00005A58 File Offset: 0x00003C58
		public void RaiseInteractedWithNPC(NPC npc)
		{
			Logger.Debug("RaiseInteractedWithNPC: " + npc.Name);
			EventHandler<InteractedWithNPCEventArgs> interactedWithNPC = this.InteractedWithNPC;
			if (interactedWithNPC == null)
			{
				return;
			}
			interactedWithNPC(this, new InteractedWithNPCEventArgs(npc));
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00005A94 File Offset: 0x00003C94
		public void RaiseFarmerDamaged(Farmer farmer)
		{
			Logger.Debug("RaiseFarmerDmaged: " + farmer.Name);
			EventHandler<FarmerDamagedEventArgs> farmerDamaged = this.FarmerDamaged;
			if (farmerDamaged == null)
			{
				return;
			}
			farmerDamaged(this, new FarmerDamagedEventArgs(farmer));
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600002E RID: 46 RVA: 0x00005AD0 File Offset: 0x00003CD0
		// (remove) Token: 0x0600002F RID: 47 RVA: 0x00005B08 File Offset: 0x00003D08
		public event EventHandler<FarmerDamagedEventArgs> FarmerDamaged;

		// Token: 0x06000030 RID: 48 RVA: 0x00005B40 File Offset: 0x00003D40
		public void RaiseClothingChanged()
		{
			EventHandler clothingChanged = this.ClothingChanged;
			if (clothingChanged == null)
			{
				return;
			}
			clothingChanged(this, null);
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000031 RID: 49 RVA: 0x00005B60 File Offset: 0x00003D60
		// (remove) Token: 0x06000032 RID: 50 RVA: 0x00005B98 File Offset: 0x00003D98
		public event EventHandler ClothingChanged;

		// Token: 0x06000033 RID: 51 RVA: 0x00005BD0 File Offset: 0x00003DD0
		public void RaiseEquipChange()
		{
			EventHandler equipChange = this.EquipChange;
			if (equipChange == null)
			{
				return;
			}
			equipChange(this, null);
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000034 RID: 52 RVA: 0x00005BF0 File Offset: 0x00003DF0
		// (remove) Token: 0x06000035 RID: 53 RVA: 0x00005C28 File Offset: 0x00003E28
		public event EventHandler EquipChange;

		// Token: 0x06000036 RID: 54 RVA: 0x00005C60 File Offset: 0x00003E60
		public void RaiseSpecialUsed()
		{
			EventHandler specialUsed = this.SpecialUsed;
			if (specialUsed == null)
			{
				return;
			}
			specialUsed(this, null);
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000037 RID: 55 RVA: 0x00005C80 File Offset: 0x00003E80
		// (remove) Token: 0x06000038 RID: 56 RVA: 0x00005CB8 File Offset: 0x00003EB8
		public event EventHandler SpecialUsed;
	}
}
