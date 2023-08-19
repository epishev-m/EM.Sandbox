using System;
using MessagePack;

namespace EM.Game.Configs
{

[Serializable]
[MessagePackObject]
public sealed class SplashScreenDefinition
{
	[Key(0)]
	public string Name;

	[Key(1)]
	public bool IsSkipped;
}

}