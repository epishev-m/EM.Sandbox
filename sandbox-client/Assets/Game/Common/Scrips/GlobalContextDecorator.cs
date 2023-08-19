using EM.Foundation;
using EM.Game.Configs;
using EM.GameKit.Context;
using EM.IoC;

namespace EM.Game
{

public sealed class GlobalContextDecorator : ContextDecorator
{
	public override void Initialize(IDiContainer container)
	{
		container.BindGameLoop(LifeTime.Global)
			.BindEcs(LifeTime.Global)
			.BindAssetsManager(LifeTime.Global)
			.BindUiSystem(LifeTime.Global)
			.BindProfile(LifeTime.Global)
			.BindCheats(LifeTime.Global)
			.BindStorage(LifeTime.Global)
			.BindStateMachine(LifeTime.Global)
			.BindConfigs(LifeTime.Global);
	}

	public override void Configure(IDiContainer container)
	{
		container.ConfigureGameLoop()
			.ConfigureEcsDebug(LifeTime.Global)
			.ConfigureUiSystem("UiContainer")
			.ConfigureTestCheats(LifeTime.Global);
	}

	public override void Release(IDiContainer container)
	{
	}
}

}