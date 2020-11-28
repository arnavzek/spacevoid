using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour {

	public void Reset(){
		gameObject.SetActive (false);
		transform.GetComponent<Animator> ().Play ("Century",0,0f);
	}
}
