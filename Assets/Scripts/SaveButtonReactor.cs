namespace VRTK.Examples
{
	using UnityEngine;
	using UnityEventHelper;

	public class SaveButtonReactor : MonoBehaviour
	{
		public GameObject go;
		public Transform dispenseLocation;

		public GameControl gc;

		private VRTK_Button_UnityEvents buttonEvents;

		private void Start()
		{
			buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
			if (buttonEvents == null)
			{
				buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
			}
			buttonEvents.OnPushed.AddListener(handle_save_push);
		}

		private void handle_save_push(object sender, Control3DEventArgs e)
		{
			VRTK_Logger.Info("Save Button Pushed");

//			GameObject newGo = (GameObject)Instantiate(go, dispenseLocation.position, Quaternion.identity);
//			Destroy(newGo, 10f);

			gc.save_instrument ();
			gc.new_instrument ();
		}
	}
}