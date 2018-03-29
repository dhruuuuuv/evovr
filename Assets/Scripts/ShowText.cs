using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

	public Text text;

	void Start() {
		text.enabled = false;
	}

	public void enable_text(string message) {
		text.enabled = true;
		text.text = message;
		Invoke ("disable_text", 5f);
	}

	public void disable_text() {
		text.enabled = false;
	}


}
