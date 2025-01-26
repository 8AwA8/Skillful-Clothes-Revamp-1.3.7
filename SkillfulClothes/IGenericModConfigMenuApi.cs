using System;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace SkillfulClothes
{
	// Token: 0x020000A0 RID: 160
	public interface IGenericModConfigMenuApi
	{
		// Token: 0x060003A3 RID: 931
		void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);

		// Token: 0x060003A4 RID: 932
		void AddBoolOption(IManifest mod, Func<bool> getValue, Action<bool> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);

		// Token: 0x060003A5 RID: 933
		void Unregister(IManifest mod);

		// Token: 0x060003A6 RID: 934
		void AddKeybindList(IManifest mod, Func<KeybindList> getValue, Action<KeybindList> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);

		// Token: 0x060003A7 RID: 935
		void AddNumberOption(IManifest mod, Func<float> getValue, Action<float> setValue, Func<string> name, Func<string> tooltip = null, float? min = null, float? max = null, float? interval = null, Func<float, string> formatValue = null, string fieldId = null);
	}
}
