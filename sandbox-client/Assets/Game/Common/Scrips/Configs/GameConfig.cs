using System.Collections.Generic;
using MessagePack;

namespace EM.Game.Configs
{

[MessagePackObject]
public sealed class GameConfig
{
	[Key(0)]
	public FeatureTogglesDefinition FeatureToggles;

	[Key(1)]
	public List<SplashScreenDefinition> SplashScreens;

	[Key(2)]
	public GdpRegulationDefinition GdpRegulation;
}

}