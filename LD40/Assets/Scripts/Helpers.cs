using UnityEngine;
using UnityEngine.AI;

public static class Helpers
{

	public static bool AgentHasStoppedMoving(NavMeshAgent agent)
	{
		if (agent.pathPending) return false;
		if (!(agent.remainingDistance <= agent.stoppingDistance)) return false;
		return !agent.hasPath || agent.velocity.sqrMagnitude == 0f;
	}

	public static Vector3 RandomBetweenVectors(Vector3 v1, Vector3 v2)
	{
		return new Vector3(
			Random.Range(v1.x, v2.x),
			Random.Range(v1.y, v2.y),
			Random.Range(v1.z, v2.z)
		);
	}

	public static string DateSuffix(int num)
	{
		if (num >= 11 && num <= 13)
			return "th";

		switch (num % 10)
		{
			case 1: return "st";
			case 2: return "nd";
			case 3: return "rd";
		}

		return "th";
	}
	
}
