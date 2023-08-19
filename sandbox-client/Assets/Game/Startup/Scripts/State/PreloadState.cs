namespace EM.Game
{

using System.Threading;
using Cysharp.Threading.Tasks;
using GameKit;
using Profile;

public sealed class PreloadState : IGameState
{
	private readonly IProfile _profile;

	private readonly SplashScreen _splashScreen;

	private readonly GdpRegulation _gdpRegulation;

	private readonly InternetConnection _internetConnection;

	#region IGameState

	public async UniTask OnEnterAsync(CancellationToken ct)
	{
		await _splashScreen.ShowAsync(ct);
		await _internetConnection.CheckAsync(ct);
		_profile.Load(ProfileStorages.Privacy);
		await _gdpRegulation.ShowAsync(ct);
		_profile.Save(ProfileStorages.Privacy);
	}

	#endregion

	#region PreloadGameState

	public PreloadState(IProfile profile,
		SplashScreen splashScreen,
		GdpRegulation gdpRegulation,
		InternetConnection internetConnection)
	{
		_profile = profile;
		_splashScreen = splashScreen;
		_gdpRegulation = gdpRegulation;
		_internetConnection = internetConnection;
	}

	#endregion
}

}