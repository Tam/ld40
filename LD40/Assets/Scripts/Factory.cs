using UnityEngine;

public class Factory : MonoBehaviour
{
	
	// Variables
	// =====================================================================

	private GlobalVars _globalVars;

	public float processingSpeed = 1f;
	
	// Unity
	// =====================================================================

	private void Start()
	{
		_globalVars = GlobalVars.instance;
	}
	
	// Actions
	// =====================================================================

	private void Process()
	{
		//
	}
	
}
