using System.Threading;
using Cysharp.Threading.Tasks;
using EM.GameKit;
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

	public static async UniTask RunStartup(this IDiContainer container,
		CancellationToken ct)
	{
		var stateMachine = container.Resolve<IGameStateMachine>();

		await stateMachine.EnterAsync<PreloadState>(ct);
	}
}

}