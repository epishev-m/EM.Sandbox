using System;
using System.Collections.Generic;
using EM.Configs;
using EM.Foundation;
using EM.Game.Configs;
using YamlDotNet.Serialization;

namespace EM.Game.Editor
{

public sealed class YamlConfigsSerializerFactory : IConfigsSerializerFactory
{
	public IConfigsSerializer Create(ILibraryEntryCatalog catalog)
	{
		Requires.NotNullParam(catalog, nameof(catalog));

		var serializerBuilder = new SerializerBuilder();
		var deserializerBuilder = new DeserializerBuilder()
			.WithTypeConverter(new LibraryEntryYamlTypeConverter(catalog))
			.WithTypeConverter(new LibraryEntryLinkYamlTypeConverter(catalog))
			/*.WithTypeDiscriminatingNodeDeserializer(deserializerOptions =>
			{
				deserializerOptions.AddUniqueKeyTypeDiscriminator<TestBase>(
					new Dictionary<string, Type>
					{
						{nameof(TestBaseA.Int), typeof(TestBaseA)},
						{nameof(TestBaseB.Bool), typeof(TestBaseB)}
					});
			})*/;

		var yamlConfigsSerializer = new YamlConfigsSerializer(serializerBuilder, deserializerBuilder);

		return yamlConfigsSerializer;
	}
}

}