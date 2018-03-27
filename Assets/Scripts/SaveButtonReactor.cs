namespace VRTK.Examples
{
	using UnityEngine;
	using UnityEventHelper;

	public class SaveButtonReactor : MonoBehaviour
	{
//		public GameObject go;
//		public Transform dispenseLocation;

		private GameObject game_c;
		private GameControl gc;

		private VRTK_Button_UnityEvents buttonEvents;

		private void Start()
		{
			game_c = GameObject.Find ("GameControl");

			Debug.Log (game_c);
			Debug.Log ("about to print 'genome");
			gc = game_c.GetComponent<GameControl> ();

			buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
			if (buttonEvents == null)
			{
				buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
			}
			buttonEvents.OnPushed.AddListener(handle_save_push);
		}

		private void handle_save_push(object sender, Control3DEventArgs e)
		{
			Debug.Log("Save Button Pushed");

//			GameObject newGo = (GameObject)Instantiate(go, dispenseLocation.position, Quaternion.identity);
//			Destroy(newGo, 10f);

			gc.save_instrument ();
			gc.new_instrument ();
		}
	}
}