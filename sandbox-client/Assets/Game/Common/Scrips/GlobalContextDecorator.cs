using EM.Game.Configs;
using EM.GameKit.Context;
using EM.IoC;

namespace EM.Game
{

public sealed class GlobalContextDecorator : ContextDecorator
{
	public override void Initialize(IDiContainer container)
	{
		container.BindGameLoop()
			.BindEcs()
			.BindAssetsManager()
			.BindUiSystem()
			.BindProfile()
			.BindCheats()
			.BindStateMachine()
			.BindConfigs();
	}

	public override void Configure(IDiContainer container)
	{
		container.ConfigureGameLoop()
			.ConfigureEcsDebug()
			.ConfigureUiSystem(Assets.UiContainer);
	}

	public override void Release(IDiContainer container)
	{
	}
}

}