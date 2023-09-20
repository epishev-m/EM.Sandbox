using EM.Configs;
using EM.Foundation;
using EM.IoC;

namespace EM.Game.Configs
{

public static class ConfigsDiContainerExtensions
{
	public static IDiContainer BindConfigs(this IDiContainer container,
		LifeTime lifeTime = LifeTime.Global)
	{
		container.Bind<ILibraryEntryCatalog>()
			.SetLifeTime(lifeTime)
			.To<LibraryEntryCatalog>()
			.AsSingle();

		container.Bind<IConfigsSerializerFactory>()
			.SetLifeTime(lifeTime)
			.To<MessagePackConfigsSerializerFactory>()
			.AsSingle();

		container.Bind<GameConfig>()
			.SetLifeTime(lifeTime)
			.ToFactory<GameConfigsFactory>()
			.AsSingle();

		return container;
	}
}

}