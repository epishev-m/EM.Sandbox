using EM.GameKit.UI;
using EM.IoC;
using EM.Profile;

namespace EM.Game
{

public static class StartupDiContainerExtensions
{
	public static IDiContainer BindStartupStates(this IDiContainer container)
	{
		container.Bind<PreloadState>()
			.InLocal()
			.To<PreloadState>();

		return container;
	}

	public static IDiContainer ConfigureStartupProfile(this IDiContainer container)
	{
		container.Resolve<IProfile>()
			.Bind(ProfileStorages.Privacy)
			.InLocal()
			.To<GdpRegulationSaver>();

		return container;
	}
}

}