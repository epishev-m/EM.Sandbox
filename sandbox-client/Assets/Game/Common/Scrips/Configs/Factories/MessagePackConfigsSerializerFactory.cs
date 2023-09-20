using System;
using System.Collections.Generic;
using EM.Configs;
using EM.Foundation;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using MessagePack.Unity.Extension;

namespace EM.Game
{

public sealed class MessagePackConfigsSerializerFactory : IConfigsSerializerFactory
{
	public IConfigsSerializer Create(ILibraryEntryCatalog catalog)
	{
		Requires.NotNullParam(catalog, nameof(catalog));

		var resolver = CompositeResolver.Create(
			new LibraryEntryResolver(catalog),
			GeneratedResolver.Instance,
			DynamicGenericResolver.Instance,
			DynamicEnumAsStringResolver.Instance,
			StaticCompositeResolver.Instance,
			UnityBlitResolver.Instance,
			StandardResolver.Instance
		);
		var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);
		var mpSerializer = new MessagePackConfigSerializer(options);

		return mpSerializer;
	}

	#region Nested

	private sealed class LibraryEntryResolver : IFormatterResolver
	{
		private readonly ILibraryEntryCatalog _catalog;

		#region IFormatterResolver

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			var formatter = FormatterCache<T>.Formatter;

			if (formatter is ILibraryEntryCatalogProvider provider)
			{
				provider.Catalog = _catalog;
			}

			return formatter;
		}

		#endregion

		#region LibraryEntryResolver

		public LibraryEntryResolver(ILibraryEntryCatalog catalog)
		{
			_catalog = catalog;
		}

		#endregion

		#region Nested

		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> Formatter;

			static FormatterCache()
			{
				Formatter = (IMessagePackFormatter<T>) ResolverGetFormatterHelper.GetFormatter(typeof(T));
			}
		}

		private static class ResolverGetFormatterHelper
		{
			private static readonly Dictionary<Type, object> FormatterMap = new()
			{
				//{typeof(Test), new LibraryEntryFormatter<Test>(GeneratedResolver.Instance)},
				//{typeof(LibraryEntryLink<Test>), new LibraryEntryLinkFormatter<LibraryEntryLink<Test>>(GeneratedResolver.Instance)}
			};

			internal static object GetFormatter(Type t)
			{
				if (FormatterMap.TryGetValue(t, out var formatter))
				{
					return formatter;
				}

				return null;
			}
		}

		#endregion
	}

	#endregion
}

}