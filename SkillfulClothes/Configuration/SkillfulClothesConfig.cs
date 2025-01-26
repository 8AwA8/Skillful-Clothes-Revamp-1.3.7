using System;
using StardewModdingAPI.Utilities;

namespace SkillfulClothes.Configuration
{
	// Token: 0x0200006D RID: 109
	internal class SkillfulClothesConfig
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600024E RID: 590 RVA: 0x000039F7 File Offset: 0x00001BF7
		// (set) Token: 0x0600024F RID: 591 RVA: 0x000039FF File Offset: 0x00001BFF
		public bool EnableShirtEffects { get; set; } = true;

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00003A08 File Offset: 0x00001C08
		// (set) Token: 0x06000251 RID: 593 RVA: 0x00003A10 File Offset: 0x00001C10
		public bool EnablePantsEffects { get; set; } = true;

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00003A19 File Offset: 0x00001C19
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00003A21 File Offset: 0x00001C21
		public bool EnableHatEffects { get; set; } = true;

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00003A2A File Offset: 0x00001C2A
		// (set) Token: 0x06000255 RID: 597 RVA: 0x00003A32 File Offset: 0x00001C32
		public bool AllItemsCanBeTailored { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00003A3B File Offset: 0x00001C3B
		// (set) Token: 0x06000257 RID: 599 RVA: 0x00003A43 File Offset: 0x00001C43
		public bool verboseLogging { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00003A4C File Offset: 0x00001C4C
		// (set) Token: 0x0600025A RID: 602 RVA: 0x00003A54 File Offset: 0x00001C54
		public bool EnableClothingForge { get; set; } = true;

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00003A5D File Offset: 0x00001C5D
		// (set) Token: 0x0600025C RID: 604 RVA: 0x00003A65 File Offset: 0x00001C65
		public bool LessImpactfulClothes { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00003A6E File Offset: 0x00001C6E
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00003A76 File Offset: 0x00001C76
		public bool DisableWhenActiveAlerts { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00003A7F File Offset: 0x00001C7F
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00003A87 File Offset: 0x00001C87
		public bool DisableEffectSFX { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00003A90 File Offset: 0x00001C90
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00003A98 File Offset: 0x00001C98
		public KeybindList KeyForWardrobeSetOne { get; set; } = KeybindList.Parse("D1");

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00003AA1 File Offset: 0x00001CA1
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00003AA9 File Offset: 0x00001CA9
		public KeybindList KeyForWardrobeSetTwo { get; set; } = KeybindList.Parse("D2");

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00003AB2 File Offset: 0x00001CB2
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00003ABA File Offset: 0x00001CBA
		public KeybindList KeyForWardrobeSetThree { get; set; } = KeybindList.Parse("D3");

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00003AC3 File Offset: 0x00001CC3
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00003ACB File Offset: 0x00001CCB
		public KeybindList KeyForWardrobeSetFour { get; set; } = KeybindList.Parse("D4");

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00003AD4 File Offset: 0x00001CD4
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00003ADC File Offset: 0x00001CDC
		public KeybindList KeyForWardrobeSetFive { get; set; } = KeybindList.Parse("D5");

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00003AE5 File Offset: 0x00001CE5
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00003AED File Offset: 0x00001CED
		public KeybindList KeyForWardrobeSetSix { get; set; } = KeybindList.Parse("D6");

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00003AF6 File Offset: 0x00001CF6
		// (set) Token: 0x0600026E RID: 622 RVA: 0x00003AFE File Offset: 0x00001CFE
		public KeybindList ToggleForWardrobeSetReplace { get; set; } = KeybindList.Parse("LeftShift");

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00003B07 File Offset: 0x00001D07
		// (set) Token: 0x06000270 RID: 624 RVA: 0x00003B0F File Offset: 0x00001D0F
		public KeybindList KeysForWardrobeOpening { get; set; } = KeybindList.Parse("Q + LeftShift");

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000271 RID: 625 RVA: 0x00003B18 File Offset: 0x00001D18
		// (set) Token: 0x06000272 RID: 626 RVA: 0x00003B20 File Offset: 0x00001D20
		public bool CritDamageBalanceActive { get; set; } = true;

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00003B29 File Offset: 0x00001D29
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00003B31 File Offset: 0x00001D31
		public bool GlobalFarmWardrobe { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00003B3A File Offset: 0x00001D3A
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00003B42 File Offset: 0x00001D42
		public bool OneToOneSpeed { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00003B4B File Offset: 0x00001D4B
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00003B53 File Offset: 0x00001D53
		public float TypicalClothesMultiple { get; set; } = 0.55f;

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00003B5C File Offset: 0x00001D5C
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00003B64 File Offset: 0x00001D64
		public bool AutoWaterCanReq { get; set; }
	}
}
