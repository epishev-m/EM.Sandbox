using EM.GameKit.UI;

namespace EM.Game.Configs
{

public sealed class InternetConnectionConfigProvider : IInternetConnectionConfigProvider
{
	private readonly GameConfig _config;

	#region IInternetConnectionConfigProvider

	public bool IsUsed => _config.FeatureToggles.InternetConnection;

	#endregion

	#region InternetConnectionConfigProvider

	public InternetConnectionConfigProvider(GameConfig config)
	{
		_config = config;
	}

	#endregion
}

}