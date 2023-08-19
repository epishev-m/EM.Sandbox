using System.Collections.Generic;
using System.Linq;
using EM.GameKit;

namespace EM.Game.Configs
{

public sealed class SplashScreenConfigProvider : ISplashScreenConfigProvider
{
	private readonly GameConfig _configs;

	#region ISplashScreenConfigProvider

	public bool IsUsed => _configs.FeatureToggles.SplashScreen;

	public Queue<string> GetSplashNameQueue()
	{
		var names = _configs.SplashScreens.Select(definitions => definitions.Name);

		return new Queue<string>(names);
	}

	public bool CheckSkipByName(string name)
	{
		var splash = _configs.SplashScreens.FirstOrDefault(definitions => definitions.Name == name);

		return splash is {IsSkipped: true};
	}

	#endregion

	#region SplashScreenConfigFactory

	public SplashScreenConfigProvider(GameConfig configs)
	{
		_configs = configs;
	}

	#endregion
}

}