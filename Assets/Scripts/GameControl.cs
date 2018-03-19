using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//class to manage instruments and objects
public class GameControl : MonoBehaviour {

	Vector3 base_position = new Vector3(1.82f, 8.29f, -13.95f);
	public Rigidbody inst_prefab; 
	public Rigidbody instrument;

	public GameObject libpd;

	public int count_before_evolution;
	private int instrument_number;

	public float save_x_min = -3.5;
	public float save_x_max = 12.5;

	public float save_z_min = 1.5;
	public float save_z_max = 17.5;

	public List<List<int>> saved_genomes = new List<List<int>> ();


	private LibControl lib_control;
	private Genome current_genome;


	void Awake () {
		libpd = GameObject.Find ("LibPD");
//		lib_control = libpd.GetComponent<Control>();
	}

	// Use this for initialization
	void Start () {
		//		make a new instrument
//		Instantiate(inst_prefab, base_position, Quaternion.identity, true);
		instrument = Instantiate (inst_prefab);

		instrument.GetComponent <MeshRenderer> ().material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));

		lib_control = new LibControl (instrument);

		current_genome = lib_control.get_genome ();

		instrument_number = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/genome.dat");

//		Genome g = new Genome (instrument);
//		g.blah = ...

		bf.Serialize (file, current_genome);

		file.Close();

	}

	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/genome.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "genome.dat", FileMode.Open);
		
			Genome g = (Genome)bf.Deserialize(file);
//			health = g.health ...
		}
	}

	public List<int> genome_to_list() {
		List<int> dna = new List<int> ();

		dna.Add (current_genome.metro_env_filter);
		dna.Add (current_genome.receiver_index);
		dna.Add (current_genome.rb_property_index);

		dna.Add (current_genome.env_gen);
		dna.Add (current_genome.filter_gen);
		dna.Add (current_genome.metro_gen);

		return dna;
	}
		

//	check if the instrument object is in the green area, and if so, save
	public void save_instrument() {
		float x_pos = instrument.position.x;
		float z_pos = instrument.position.z;

		if (x_pos > save_x_max && x_pos < save_x_min && z_pos > save_z_min && z_pos < save_z_max) {
			genome_to_list


		} else {
			DestroyObject (instrument);
		}

	}

	public void new_instrument() {
		if (instrument_number <= count_before_evolution) {
			instrument = Instantiate (inst_prefab);

			instrument.GetComponent <MeshRenderer> ().material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));

			lib_control = new LibControl (instrument);

			current_genome = lib_control.get_genome ();
			instrument_number += 1;
		} else {
//			mutate_genome ();
		}
	}
}
