using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome {

//	public poly_object ... ?

//	public interaction ... ?

//	pure data receiver index of array
	public int receiver_index;
	public int metro_env_filter;

//	rigidbody property index float
	public int rb_property_index;

//	object to create and play with
	public Rigidbody rb;

//	List of property and floats
	List<float> rb_prop;
	int rb_prop_length;

	bool debug = true;

	public float min_x_lim = -20;
	public float max_x_lim = 20;
		
	public float min_y_lim = 0;
	public float max_y_lim = 30;

	public string[][] sound_receives;

	public int[] env_gen = new int[4];
	public int[] filter_gen = new int[4];
	public int[] metro_gen = new int[3];

	public int metro_on = 1;

	public string[] metro = {
		"scale-choice",
//		"metro-on",
		"metro-val",
		"freq"
	};

	public string[] env = {
		"att",
		"dec",
		"sus",
		"rel"
	};

	public string[] filter = {
		"filter_start",
		"filter_end",
		"filter_time",
		"filter_q"
	};

	public Genome(Rigidbody r) {
		rb = r;
		get_rb_properties ();

		sound_receives = new string[4][];
		sound_receives[0] = metro;
		sound_receives[1] = env;
		sound_receives[2] = filter;

		new_genome ();

//		if debugging then recieve is the global clock rate and the property is x translation
		if (debug) {
			metro_env_filter = 0;
			receiver_index = 1;
			rb_property_index = 0;
		} 
	}

//	make a new genome, randomise all parameters 
	public void new_genome() {

		for (int i = 0; i < env_gen.Length; i++) {
			env_gen[i] = Random.Range(0, 127);
		}

		for (int i = 0; i < filter_gen.Length; i++) {
			filter_gen[i] = Random.Range(0, 127);
		}

		for (int i = 0; i < metro_gen.Length; i++) {
			metro_gen[i] = Random.Range(0, 127);
		}

		metro_env_filter = Random.Range(0, 2);

		if (metro_env_filter == 0) {
			receiver_index = Random.Range(0, metro_gen.Length);
		}

		else {
			receiver_index = Random.Range(0, filter_gen.Length);
		}

		if (metro_env_filter == 0 && receiver_index == 2) {
			metro_on = 0;
		}

		rb_property_index = Random.Range (0, rb_prop_length);
			
	}

	public Genome(Rigidbody r, int[] old_metro, int[] old_env, int[] old_filter, int old_metro_env_filter, int old_ri,  int old_rbpi) {
		rb = r;
		get_rb_properties ();

		sound_receives = new string[4][];
		sound_receives[0] = metro;
		sound_receives[1] = env;
		sound_receives[2] = filter;

		receiver_index = old_ri;
		rb_property_index = old_rbpi;
	}
		
//	calculate the value of the property being tracked
	public float get_property_float () {
		get_rb_properties ();

		float unmapped_property = rb_prop [rb_property_index];

		return map_property_float (rb_property_index, unmapped_property); 
	}

//	get the string that's the receiver for pure data
	public string get_pd_string () {

		if (debug) {
			
			return "metro-val";

		} else {
			return sound_receives [metro_env_filter][receiver_index];
		}
	}

//	given a float and an index, map from the relevant index and the float to an acceptable range to send.
	public float map_property_float (int index, float property_val) {

//		if (debug) {
////			map to clock ranges
//			return remap (property_val, min_x_lim, max_x_lim, 0, 127);
//		} 

//		if transform x or transform z
		if (index == 0 | index == 2) {
			return remap (property_val, min_x_lim, max_x_lim, 0, 127);
		} 

//		if transform is y
		else if (index == 1) {
			return remap (property_val, min_y_lim, max_y_lim, 0, 127);

		}
//		if transform magnitude - currently let's just see what happens
		else if (index == 3) {
			return property_val;

		}
//		if rotations, for now take abs and mod 360, then map
		else if (index > 3 && index <= 6) {
			float rotation_val = Mathf.Abs (property_val) % 360;
			return remap (rotation_val, 0, 360, 0, 127);
		}

//		if rotation magnitude - currently let's just see what happens
		else if (index == 7) {
				return property_val;
		}

//		if velocity, for now, let us see what happens (probably at least need a map)
		else if (index > 7 && index < 12) {
			return property_val;

		}
//		do proper things
		else {
			return property_val;
		}
	}
		
	//	get properties of rigidbody and store them in an array
	public void get_rb_properties() {

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

		rb_prop_length = rb_prop.Count;
	}

	//	scales a value (s) from original range (a1, a2) to new range (b1, b2)
	public float remap(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
	}
	

//	takes an index for the property array, and checks the limits and maps onto range 127
//	float mapped_properties(int index) {
//	}
		

//	//	gets a random element from the sound receives array (ie. what to send to pure data)
//	string get_random_sound_receive() {
//		return sound_receives[Random.Range(0,sound_receives.Length)];
//	}
}
