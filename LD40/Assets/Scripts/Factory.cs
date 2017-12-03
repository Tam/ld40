using System;
using System.Collections;
using UnityEngine;

public class Factory : MonoBehaviour
{
	
	// Variables
	// =====================================================================

	private GlobalVars _globalVars;

	private WaitForSeconds _processingSpeed = new WaitForSeconds(1f);
	private float _processingSpeedSeconds = 1f;
	public float processingSpeed
	{
		get { return _processingSpeedSeconds; }
		set
		{
			_processingSpeedSeconds = value;
			_processingSpeed = new WaitForSeconds(value);
		}
	}

	public int globflobsToProcessEachTime = 1;
	
	// Unity
	// =====================================================================

	private void Start()
	{
		_globalVars = GlobalVars.instance;
		StartCoroutine("Process");
	}
	
	// Actions
	// =====================================================================

	private IEnumerator Process()
	{
		for(;;) {
			_globalVars.ProcessGlobflobs(globflobsToProcessEachTime);
			yield return _processingSpeed;
		}
	}
	
}
