using System.Collections.Generic;
using EM.Assistant.Editor;
using EM.BuildSystem.Editor;
using EM.Profile.Editor;

namespace EM.Game.Editor
{

public sealed class GameAssistantWindow : AssistantWindow
{
	public static void Open()
	{
		GetWindow<GameAssistantWindow>("Assistant", true);
	}

	protected override IEnumerable<AssistantComponent> GetWindowComponents()
	{
		return new AssistantComponent[]
		{
			new GameConfigsAssistantComponent(),
			new SaveAssistantComponent(),
			new BuildSystemAssistantComponent()
		};
	}
}

}