using EM.GameKit.UI.Editor;
using UnityEditor;

namespace EM.Game.Editor
{

public static class EditorMenu
{
	[MenuItem("Tools/Game/Assistant", priority = 1)]
	public static void OpenAssistantWindow()
	{
		GameAssistantWindow.Open();
	}

	[MenuItem("Tools/Game/Cheats", priority = 1)]
	public static void OpenCheatsAssistantWindow()
	{
		EditorWindow.GetWindow<CheatsWindow>("Cheats", true);
	}
}

}