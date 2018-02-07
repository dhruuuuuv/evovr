using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LibPDBinding;

public class oscControl : MonoBehaviour {

	public Rigidbody rb;
	public float freq_factor = 100;

	void Start()
	{
	}

	// Update is called once per frame
	void Update () {
		Vector3 cube_pos = rb.position;
		float frequency = cube_pos.x * freq_factor;
		Debug.Log (cube_pos.x);
		Debug.Log (frequency);
		LibPD.SendFloat ("frequency", frequency);
	}
}
