using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Configuration
{
	// Token: 0x02000065 RID: 101
	public class CustomEffectConfigurationParser
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00003835 File Offset: 0x00001A35
		public CustomEffectConfigurationParser()
		{
			this.defaultSerializer.Converters.Add(new EffectJsonConverter(EffectLibrary.Default));
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000C250 File Offset: 0x0000A450
		public List<CustomEffectItemDefinition> Parse(Stream jsonStream)
		{
			JsonSerializer serializer = new JsonSerializer();
			serializer.Converters.Add(new EffectJsonConverter(EffectLibrary.Default));
			List<CustomEffectItemDefinition> result;
			using (StreamReader reader = new StreamReader(jsonStream))
			{
				using (JsonTextReader jsonReader = new JsonTextReader(reader))
				{
					Dictionary<string, IEffect> lst = serializer.Deserialize<Dictionary<string, IEffect>>(jsonReader);
					result = (from x in lst
					select new CustomEffectItemDefinition(x.Key, x.Value)).ToList<CustomEffectItemDefinition>();
				}
			}
			return result;
		}

		// Token: 0x0400023F RID: 575
		private JsonSerializer defaultSerializer = new JsonSerializer();
	}
}
