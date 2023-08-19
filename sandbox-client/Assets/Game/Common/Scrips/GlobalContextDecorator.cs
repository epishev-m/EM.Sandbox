namespace EM.Game
{

using GameKit.Context;
using Foundation;
using IoC;

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
			.BindStateMachine();
	}

	public override void Configure(IDiContainer container)
	{
		container.ConfigureGameLoop()
			.ConfigureEcsDebug(LifeTime.Global)
			.ConfigureUiSystem("UiContainer");
	}

	public override void Release(IDiContainer container)
	{
	}
}

}