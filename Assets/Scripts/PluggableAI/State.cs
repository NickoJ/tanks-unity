using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{

	public Action[] actions;

    private Color sceneGizmoColor = Color.grey;

	public Color SceneGizmoColor { get { return sceneGizmoColor; } }

    public void UpdateState(StateController controller)
	{

	}

	private void DoActions(StateController controller)
	{
		for (int i = 0; i < actions.Length; i++) actions[i].Act(controller);
	}

}