namespace EM.Game
{

using System.Threading;
using Cysharp.Threading.Tasks;
using GameKit.Context;
using Foundation;

public sealed class StartupContext : Context
{
	protected override void Initialize()
	{
	}

	protected override void Configure()
	{
	}

	protected override void Release()
	{
		DiContainer.ReleaseUiSystem()
			.ReleaseProfile()
			.ReleaseGameLoop();
	}

	protected override async UniTask RunAsync(CancellationToken ct)
	{
	}
}

}