using UnityEngine;

public class GunSloting : MonoBehaviour {

	public GameObject[] Slots;
	private int currentSloat = -1;		
	public GameObject Gun;


	void Start () {
		

		Slots = new GameObject[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {

			Slots [i] = transform.GetChild(i).gameObject;
		}



	}
	
	public void GunPoint(){




		if (currentSloat < 1) {

			currentSloat++;
			Instantiate (Gun, Slots [currentSloat].transform.position, Slots [currentSloat].transform.rotation,Slots [currentSloat].transform);

		}
	}

	public void ResetSlot(){

		if (currentSloat > -1) {

			for (int i = 0; i <= currentSloat; i++) {

				Destroy (Slots [i].transform.GetChild (0).gameObject);
			}

			currentSloat = -1;

		} else {
			currentSloat = -1;
		}


	}


}
