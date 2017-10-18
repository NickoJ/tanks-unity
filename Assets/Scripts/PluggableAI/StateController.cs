using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

	public State currentState;
	public EnemyStats enemyStats;
	public Transform eyes;

	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public TankShooting tankShooting;
	[HideInInspector] public List<Transform> wayPointList;
	[HideInInspector] public int nextWayPoint;

	private bool aiActive;


	void Awake () 
	{
		tankShooting = GetComponent<TankShooting> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
	{
		wayPointList = wayPointsFromTankManager;
		aiActive = aiActivationFromTankManager;
		if (aiActive) 
		{
			navMeshAgent.enabled = true;
		} else 
		{
			navMeshAgent.enabled = false;
		}
	}

	void Update()
	{
		if (!aiActive) return;

		currentState.UpdateState(this);
	}

	void OnDrawGizmos()
	{
		if (currentState != null && eyes != null)
		{
			Gizmos.color = currentState.sceneGizmoColor;
			Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
		}
	}

}