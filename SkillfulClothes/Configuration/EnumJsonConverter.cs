using System;
using Newtonsoft.Json;

namespace SkillfulClothes.Configuration
{
	// Token: 0x0200006C RID: 108
	internal class EnumJsonConverter : JsonConverter
	{
		// Token: 0x0600024A RID: 586 RVA: 0x000039C3 File Offset: 0x00001BC3
		public override bool CanConvert(Type objectType)
		{
			return objectType.IsEnum;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x000039CB File Offset: 0x00001BCB
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600024C RID: 588 RVA: 0x000039D2 File Offset: 0x00001BD2
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((value != null) ? value.ToString() : null) ?? "");
		}
	}
}
