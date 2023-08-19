using EM.GameKit;

namespace EM.Game.Configs
{

public sealed class GdpRegulationConfigProvider : IGdpRegulationConfigProvider
{
	private readonly GameConfig _configs;

	#region IGdpRegulationConfigProvider

	public bool IsUsed => _configs.FeatureToggles.GdpRegulation;

	public string PrivacyUrl => _configs.GdpRegulation.PrivacyUrl;

	public string LicenseUrl => _configs.GdpRegulation.LicenseUrl;

	#endregion

	#region GdpRegulationConfigProvider

	public GdpRegulationConfigProvider(GameConfig configs)
	{
		_configs = configs;
	}

	#endregion
}

}