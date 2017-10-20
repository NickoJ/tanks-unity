using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{

    public override bool Decide(StateController controller)
    {
		bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
		return chaseTargetIsActive;
    }

}