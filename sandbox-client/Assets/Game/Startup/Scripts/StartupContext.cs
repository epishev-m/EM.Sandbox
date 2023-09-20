using System.Threading;
using Cysharp.Threading.Tasks;
using EM.Game.Configs;
using EM.GameKit;
using EM.GameKit.Context;

namespace EM.Game
{

public sealed class StartupContext : Context
{
	protected override void Initialize()
	{
		DiContainer.BindSplashScreen<SplashScreenConfigProvider>()
			.BindInternetConnection<InternetConnectionConfigProvider>()
			.BindGdpRegulation<GdpRegulationConfigProvider>()
			.BindStartupStates();
	}

	protected override void Configure()
	{
		DiContainer.ConfigureStartupProfile()
			.ConfigureTestCheats();
	}

	protected override void Release()
	{
		DiContainer.ReleaseUiSystem()
			.ReleaseProfile()
			.ReleaseGameLoop();
	}

	protected override async UniTask RunAsync(CancellationToken ct)
	{
		var stateMachine = DiContainer.Resolve<IGameStateMachine>();

		await stateMachine.EnterAsync<PreloadState>(ct);
	}
}

}