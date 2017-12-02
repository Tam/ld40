using System;

using UnityEngine;

public class SetRandomColor : MonoBehaviour {

    public Color[] colors;
    
	void Start () {
        Material material = GetComponent<Renderer>().material;
        System.Random random = new System.Random();
        material.color = colors[random.Next(colors.Length - 1)];
	}
	
}
