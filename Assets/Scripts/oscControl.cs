using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

using LibPDBinding;

public class oscControl : MonoBehaviour {

	public Rigidbody rb;
	public float freq_factor = 100;

	public float min_x_lim = -30;
	public float max_x_lim = 30;

	List<float> rb_prop;

	public string[] sound_receives = {"lfo-freq",
		"sd-l",
		"sd-fb",
		"sd-lp",
		"sd-r",
		"ahr-lfo-1-a",
		"ahr-lfo-1-r",
		"ahr-lfo-1-h",
		"ahr-lfo-2-a",
		"ahr-lfo-2-r",
		"ahr-lfo-2-h",
		"vca-1",
		"vca-2",
		"seq-scale",
		"glob-clk-rate"
	};

	void Start()
	{
		rb_prop = new List<float>();
		get_rb_properties ();
	}

	// Update is called once per frame
	void Update () {
		float frequency = get_inst_pos ();
//		Debug.Log (frequency);
		LibPD.SendFloat ("frequency", frequency);
	}

//	gets the x value of the rb and maps it to a frequency range.
	float get_inst_pos() {
		Vector3 inst_pos = rb.position;
		float frequency = inst_pos.x;


		float mapped_frequency = remap (frequency, min_x_lim, max_x_lim, (float) -0.25, (float) 0.25);
		return mapped_frequency;
	}

//	scales a value (s) from original range (a1, a2) to new range (b1, b2)
	float remap(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
	}

	//	gets a random element from the sound receives array (ie. what to send to pure data)
	string get_random_sound_receive() {
		return sound_receives[Random.Range(0,sound_receives.Length)];
	}

//	get properties of rigidbody and store them in an array
	void get_rb_properties() {

//		get the x, y, z position and the magnitude of the vector
		rb_prop.Add(rb.position.x);
		rb_prop.Add(rb.position.y);
		rb_prop.Add(rb.position.z);
		rb_prop.Add(rb.position.magnitude);

//		get the euler x, y, z rotation and the magnitude of the resultant vector.
		rb_prop.Add(rb.rotation.eulerAngles.x);
		rb_prop.Add(rb.rotation.eulerAngles.y);
		rb_prop.Add(rb.rotation.eulerAngles.z);
		rb_prop.Add(rb.rotation.eulerAngles.magnitude);

//		get the velocity x, y, z components, and the magnitude of the vector
		rb_prop.Add(rb.velocity.x);
		rb_prop.Add(rb.velocity.y);
		rb_prop.Add(rb.velocity.z);
		rb_prop.Add(rb.velocity.magnitude);
	}

}
	