using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;
		Vector3 position = controller.eyes.position;
		float radius = controller.enemyStats.lookSphereCastRadius;
		Vector3 direction = controller.eyes.forward;
		float lookRange = controller.enemyStats.lookRange;

		Debug.DrawRay(position, direction.normalized * lookRange, Color.green);

        if (Physics.SphereCast(position, radius, direction, out hit, lookRange) && hit.collider.CompareTag("Player"))
        {
			controller.chaseTarget = hit.transform;
			return true;
        }
		else
		{
			return false;
		}
    }

}