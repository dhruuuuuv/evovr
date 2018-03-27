namespace VRTK.Examples
{
	using UnityEngine;
	using UnityEventHelper;

	public class RejectButtonReactor : MonoBehaviour
	{
//		public GameObject go;
//		public Transform dispenseLocation;

		public GameControl gc;

		private VRTK_Button_UnityEvents buttonEvents;

		private void Start()
		{
			buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
			if (buttonEvents == null)
			{
				buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
			}
			buttonEvents.OnPushed.AddListener(handle_reject_push);
		}

		private void handle_reject_push(object sender, Control3DEventArgs e)
		{
			Debug.Log("Reject Button Pushed");

			//            GameObject newGo = (GameObject)Instantiate(go, dispenseLocation.position, Quaternion.identity);
			//            Destroy(newGo, 10f);

			gc.destroy_instrument ();
			gc.new_instrument ();
		}
	}
}