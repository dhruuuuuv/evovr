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
		float frequency = get_inst_pos ();
		Debug.Log (frequency);
		LibPD.SendFloat ("frequency", frequency);
	}

	float get_inst_pos() {
		Vector3 inst_pos = rb.position;
		float frequency = inst_pos.x;


		float mapped_frequency = remap (frequency, -30, 30, (float) -0.25, (float) 0.25);
		return mapped_frequency;
	}


	float remap(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
	}

}
