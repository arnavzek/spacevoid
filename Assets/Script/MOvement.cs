using UnityEngine;
using UnityEngine.UI;

public class MOvement : MonoBehaviour {

	public float Speed = 600f;

	public float AnalogSpeed = 350f;

	public Text Type;
	public GameObject TutorialL;
	public GameObject TutorialR;
	void Start(){
		
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		if (PlayerPrefs.GetString("ControlState" , "touch") == "tilt") {
			Type.text = "TILT";
		} else {
			Type.text = "TOUCH";
			TutorialL.SetActive (true);
			TutorialR.SetActive (true);
		}
	}


	void Update () {
		Vector3 Movement = Vector3.back* Input.GetAxis("Horizontal") * AnalogSpeed * Time.deltaTime;
		Vector3 Acc = new Vector3( 0, 0 ,- Input.acceleration.x * Speed * Time.deltaTime );
		transform.Rotate (Movement);

		if (PlayerPrefs.GetString("ControlState" , "touch") == "tilt") {

			transform.Rotate (Acc);
		
		} else {
		
			foreach (Touch touch in Input.touches ) {
				
				if (touch.position.x < Screen.width/2 && touch.position.y > Screen.height/5) {
					
					transform.Rotate (Vector3.back * -AnalogSpeed * Time.deltaTime);
				}
				else if (touch.position.x > Screen.width/2 && touch.position.y > Screen.height/5 ) {
					
					transform.Rotate (Vector3.back * AnalogSpeed * Time.deltaTime);
					} 
			
			}
		}
	
	}


	public void ChangeType(){
	
		if (PlayerPrefs.GetString("ControlState") == "tilt") {
		
			PlayerPrefs.SetString ("ControlState" , "touch");
			Type.text = "TOUCH";


		} else {

			PlayerPrefs.SetString ("ControlState" , "tilt");
			Type.text = "TILT";
		}


	}

}
