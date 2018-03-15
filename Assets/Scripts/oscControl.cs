using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

using LibPDBinding;

public class oscControl : MonoBehaviour {

	public Rigidbody rb;
//	public float freq_factor = 100;
//
//	public float min_x_lim = -30;
//	public float max_x_lim = 30;

	Genome instrument;

	void Start()
	{
		instrument = new Genome (rb);

		send_init_parameters ();


	}

	// Update is called once per frame
	void Update () {

		float prop_float = instrument.get_property_float ();

		string pd_receive = instrument.get_pd_string ();

		Debug.Log ("pd_receive");
		Debug.Log (pd_receive);
		Debug.Log ("instrument.rb_property_index");
		Debug.Log (instrument.rb_property_index);
		Debug.Log ("prop_float");
		Debug.Log (prop_float);

		LibPD.SendFloat (pd_receive, prop_float);

	}

//	sends all the non controlled randomised parameters to the various receivers in pd
	void send_init_parameters() {

		for (int i = 0; i < instrument.filter_gen.Length; i++) {
			LibPD.SendFloat (instrument.filter [i], instrument.filter_gen [i]);
		}

		for (int i = 0; i < instrument.env_gen.Length; i++) {
			LibPD.SendFloat (instrument.env [i], instrument.env_gen [i]);
		}

		for (int i = 0; i < instrument.metro_gen.Length; i++) {
			LibPD.SendFloat (instrument.metro [i], instrument.metro_gen [i]);
		}

//		check if the user is controlling the frequency of the instrument
//		if (instrument.metro_on == 1) {
//			LibPD.SendFloat ("metro-on", 1);
//
//		} else {
//			LibPD.SendFloat ("metro-on", 0);
//		}

	}

//	gets the x value of the rb and maps it to a frequency range.
//	float get_inst_pos() {
//		Vector3 inst_pos = rb.position;
//		float frequency = inst_pos.x;
//
//
//		float mapped_frequency = remap (frequency, min_x_lim, max_x_lim, (float) -0.25, (float) 0.25);
//		return mapped_frequency;
//	}

//	scales a value (s) from original range (a1, a2) to new range (b1, b2)
//	float remap(float s, float a1, float a2, float b1, float b2)
//	{
//		return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
//	}






}
	