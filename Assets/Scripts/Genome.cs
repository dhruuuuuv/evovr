using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome : MonoBehaviour {

//	public poly_object ... ?

//	public interaction ... ?

//	pure data receiver index of array
	public int pd_receiver_index;

//	rigidbody property index float
	public int rb_property_index;

//	object to create and play with
	public Rigidbody rb;

//	List of property and floats
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

	public Genome() {
		get_rb_properties ();

		pd_receiver_index = Random.Range (0, sound_receives.Length);
		rb_property_index = Random.Range (0, rb_prop.Length);
	}

	public Genome(int pdri, int rbpi) {
		get_rb_properties ();

		pd_receiver_index = pdri;
		rb_property_index = rbpi;
	}


	float get_property_float () {
		return rb_property_index [rb_property_index];
	}

	string get_pd_string () {
		return sound_receives [pd_receiver_index];
	}
		
	//	get properties of rigidbody and store them in an array
	void get_rb_properties() {

		rb_prop = new List<float>();

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
		

//	//	gets a random element from the sound receives array (ie. what to send to pure data)
//	string get_random_sound_receive() {
//		return sound_receives[Random.Range(0,sound_receives.Length)];
//	}
}
