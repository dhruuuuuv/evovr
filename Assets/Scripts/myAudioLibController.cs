using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myAudioLibController : MonoBehaviour {

	public Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody> ();

		Hv_test_1_AudioLib script = GetComponent<Hv_test_1_AudioLib> ();

		// get parameter
		float freq = script.GetFloatParameter(Hv_test_1_AudioLib.Parameter.Freq);

		float x = rb.position.x * 100;

		//set parameter
		script.SetFloatParameter(Hv_test_1_AudioLib.Parameter.Freq, x);


	}
	
	// Update is called once per frame
	void Update () {
		Hv_test_1_AudioLib script = GetComponent<Hv_test_1_AudioLib> ();

		// get parameter
		float freq = script.GetFloatParameter(Hv_test_1_AudioLib.Parameter.Freq);

		float x = rb.position.x * 100;

		//set parameter
		script.SetFloatParameter(Hv_test_1_AudioLib.Parameter.Freq, x);
	}
}
