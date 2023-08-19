using EM.Configs;
using EM.Foundation;

namespace EM.Game.Configs
{

public sealed class GameConfigsFactory : ConfigsFactory<GameConfig>
{
	#region BaseConfigsFactory

	protected override string Key => nameof(GameConfig);

	#endregion

	#region ConfigsFactory

	public GameConfigsFactory(IAssetsManager assetsManager,
		ILibraryEntryCatalog catalog,
		IConfigsSerializerFactory factory)
		: base(assetsManager, catalog, factory)
	{
	}

	#endregion
}

}