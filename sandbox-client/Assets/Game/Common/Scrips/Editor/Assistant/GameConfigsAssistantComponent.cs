using EM.Configs;
using EM.Configs.Editor;
using EM.Game.Configs;

namespace EM.Game.Editor
{

public sealed class GameConfigsAssistantComponent : ConfigsAssistantComponent<GameConfig>
{
	public override string Name => nameof(GameConfig);

	protected override IConfigsSerializerFactory GetSourceSerializerFactory()
	{
		return new YamlConfigsSerializerFactory();
	}

	protected override IConfigsSerializerFactory GetReleaseSerializerFactory()
	{
		return new MessagePackConfigsSerializerFactory();
	}

	protected override IConfigsValidatorFactory GetValidatorFactory()
	{
		return new ConfigsValidatorFactory();
	}
}

}