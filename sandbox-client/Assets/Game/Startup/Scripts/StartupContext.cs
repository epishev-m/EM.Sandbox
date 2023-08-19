using System.Threading;
using Cysharp.Threading.Tasks;
using EM.Foundation;
using EM.Game.Configs;
using EM.GameKit.Context;

namespace EM.Game
{

public sealed class StartupContext : Context
{
	protected override void Initialize()
	{
		DiContainer.BindSplashScreen<SplashScreenConfigProvider>(LifeTime.Local)
			.BindInternetConnection<InternetConnectionConfigProvider>(LifeTime.Local)
			.BindGdpRegulation<GdpRegulationConfigProvider>(LifeTime.Local)
			.BindStartupStates();
	}

	protected override void Configure()
	{
		DiContainer.ConfigureStartupProfile();
	}

	protected override void Release()
	{
		DiContainer.ReleaseUiSystem(LifeTime.Global)
			.ReleaseProfile(LifeTime.Global)
			.ReleaseGameLoop(LifeTime.Global);
	}

	protected override async UniTask RunAsync(CancellationToken ct)
	{
		await DiContainer.RunStartup(ct);
	}
}

}