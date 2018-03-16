using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//class to manage instruments and objects
public class GameControl : MonoBehaviour {

	Vector3 base_position = new Vector3(1.82f, 8.29f, -13.95f);
	public Transform inst_prefab; 


	void Awake () {

	}

	// Use this for initialization
	void Start () {
		//		make a new instrument
//		Instantiate(inst_prefab, base_position, Quaternion.identity, true);
		Instantiate (inst_prefab);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/genome.dat");

		Genome g = new Genome ();
//		g.blah = ...

		bf.Serialize (file, g);

		file.Close();

	}

	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/genome.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "genome.dat", FileMode.Open);

			Genome g = (Genome)bf.Deserialize;
//			health = g.health ...
		}
	}
}
