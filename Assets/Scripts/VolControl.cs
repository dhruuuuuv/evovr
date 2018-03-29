using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LibPDBinding;

public class VolControl : MonoBehaviour {

	public float volume;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void vol_changed(float value) {
		this.volume = value;
		send_volume_control ();
	}

	void send_volume_control() {
		LibPD.SendFloat ("volume", volume);
	}
}
