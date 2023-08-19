using MessagePack;

namespace EM.Game.Configs
{

[MessagePackObject]
public sealed class FeatureTogglesDefinition
{
	[Key(0)]
	public bool SplashScreen;

	[Key(1)]
	public bool InternetConnection;

	[Key(2)]
	public bool GdpRegulation;
}

}