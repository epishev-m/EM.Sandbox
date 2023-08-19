using System;
using MessagePack;

namespace EM.Game.Configs
{

[Serializable]
[MessagePackObject]
public sealed class GdpRegulationDefinition
{
	[Key(0)]
	public string PrivacyUrl;

	[Key(2)]
	public string LicenseUrl;
}

}