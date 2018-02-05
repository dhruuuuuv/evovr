using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LibPDBinding;

public class oscControl : MonoBehaviour {

	public float frequency;
	
	// Update is called once per frame
	void Update () {

		LibPD.SendFloat ("frequency", frequency);
	}
}
