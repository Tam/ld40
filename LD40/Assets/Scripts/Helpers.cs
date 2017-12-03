using UnityEngine.AI;

public static class Helpers
{

	public static bool AgentHasStoppedMoving(NavMeshAgent agent)
	{
		if (agent.pathPending) return false;
		if (!(agent.remainingDistance <= agent.stoppingDistance)) return false;
		return !agent.hasPath || agent.velocity.sqrMagnitude == 0f;
	}
	
}
