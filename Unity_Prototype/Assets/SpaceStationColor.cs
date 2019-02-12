using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationColor : MonoBehaviour {

	Renderer r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer>();
		r.material.SetColor("_Color", Random.ColorHSV());
	}
}
