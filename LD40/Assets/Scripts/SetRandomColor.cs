using System;

using UnityEngine;

public class SetRandomColor : MonoBehaviour {

    static System.Random random = new System.Random();

    public Color[] colors;
    
	void Start () {
        Material material = GetComponent<Renderer>().material;
        material.color = colors[random.Next(colors.Length - 1)];
	}
	
}
