using System.Collections.Generic;
using EM.Configs;
using EM.Foundation;
using Newtonsoft.Json;

namespace EM.Game.Editor
{

public sealed class JsonConfigsSerializerFactory : IConfigsSerializerFactory
{
	public IConfigsSerializer Create(ILibraryEntryCatalog catalog)
	{
		Requires.NotNullParam(catalog, nameof(catalog));

		JsonSerializerSettings jsonSettings = new()
		{
			Formatting = Formatting.Indented,
			NullValueHandling = NullValueHandling.Ignore,
			Converters = new List<JsonConverter>
			{
				new LibraryEntryJsonConverter(catalog),
				new LibraryEntryLinkJsonConverter(catalog),
				new UnionJsonConverter()
			}
		};

		var jsonSerializer = new JsonConfigsSerializer(jsonSettings);

		return jsonSerializer;
	}
}

}