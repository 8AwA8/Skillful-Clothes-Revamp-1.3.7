using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;

namespace SkillfulClothes.Configuration
{
	// Token: 0x02000069 RID: 105
	internal class EffectJsonConverter : JsonConverter<IEffect>
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000235 RID: 565 RVA: 0x000038A9 File Offset: 0x00001AA9
		private EffectLibrary EffectLibrary { get; }

		// Token: 0x06000236 RID: 566 RVA: 0x000038B1 File Offset: 0x00001AB1
		public EffectJsonConverter(EffectLibrary effectLibrary)
		{
			this.EffectLibrary = effectLibrary;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000C5A0 File Offset: 0x0000A7A0
		public override IEffect ReadJson(JsonReader reader, Type objectType, [AllowNull] IEffect existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JToken token = JToken.ReadFrom(reader);
			return this.ParseJsonEffectDefinition(token, serializer);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000C5C0 File Offset: 0x0000A7C0
		public override void WriteJson(JsonWriter writer, [AllowNull] IEffect effect, JsonSerializer serializer)
		{
			EffectSet effectSet = effect as EffectSet;
			if (effectSet != null)
			{
				writer.WriteStartArray();
				foreach (IEffect childEffect in effectSet.Effects)
				{
					this.WriteJson(writer, childEffect, serializer);
				}
				writer.WriteEndArray();
				return;
			}
			ICustomizableEffect customizableEffect = effect as ICustomizableEffect;
			if (customizableEffect != null && !(customizableEffect.ParameterObject is NoEffectParameters))
			{
				writer.WriteStartObject();
				writer.WritePropertyName(this.GetEffectName(effect));
				JToken parameterToken = JToken.FromObject(customizableEffect.ParameterObject, serializer);
				parameterToken.WriteTo(writer, Array.Empty<JsonConverter>());
				writer.WriteEndObject();
				return;
			}
			writer.WriteValue(this.GetEffectName(effect));
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000C664 File Offset: 0x0000A864
		private string GetEffectName(IEffect effect)
		{
			string name = effect.GetType().Name;
			if (name.ToLower().EndsWith("effect"))
			{
				return name.Substring(0, name.Length - "effect".Length);
			}
			return name;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000C6AC File Offset: 0x0000A8AC
		public IEffect ParseJsonEffectDefinition(JToken token, JsonSerializer serializer)
		{
			JTokenType type = token.Type;
			switch (type)
			{
			case JTokenType.Object:
				return this.ParseJsonEffectObject(token.Value<JObject>().First.Value<JProperty>(), serializer);
			case JTokenType.Array:
				return this.ParseJsonEffectSet(token, serializer);
			case JTokenType.Constructor:
				break;
			case JTokenType.Property:
				return this.ParseJsonEffectObject(token.Value<JProperty>(), serializer);
			default:
				if (type == JTokenType.String)
				{
					return this.EffectLibrary.CreateEffectInstance(token.ToObject<string>());
				}
				break;
			}
			Logger.Error("Unexpected value: " + token.ToString());
			return new NullEffect();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000C738 File Offset: 0x0000A938
		private EffectSet ParseJsonEffectSet(JToken arrayToken, JsonSerializer serializer)
		{
			if (arrayToken.Type != JTokenType.Array)
			{
				throw new ArgumentException("The specified token is not a JSON array", "arrayToken");
			}
			List<IEffect> effects = new List<IEffect>();
			foreach (JToken child in arrayToken.Values())
			{
				effects.Add(this.ParseJsonEffectDefinition(child, serializer));
			}
			return EffectSet.Of(effects.ToArray());
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000C7B8 File Offset: 0x0000A9B8
		private IEffect ParseJsonEffectObject(JProperty jproperty, JsonSerializer serializer)
		{
			try
			{
				string effectName = jproperty.Name;
				IEffect effect = this.EffectLibrary.CreateEffectInstance(effectName);
				ICustomizableEffect customizableEffect = effect as ICustomizableEffect;
				if (customizableEffect != null)
				{
					JToken parameterDefinition = jproperty.Value;
					IEffectParameters parameters = parameterDefinition.ToObject(customizableEffect.ParameterType, serializer) as IEffectParameters;
					customizableEffect.ParameterObject = parameters;
				}
				return effect;
			}
			catch (Exception)
			{
				Logger.Error("Encountered an invalid effect definition at " + jproperty.Path);
			}
			return new NullEffect();
		}
	}
}
