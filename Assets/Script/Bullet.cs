using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 15;
	public float DestroyDistance = 0.5f;
	public float Scalefq = 1f;
	public float scaleM = 0.1f;




	void Start(){
		Destroy (gameObject,DestroyDistance);
		InvokeRepeating ("sizer", 0, Scalefq);
	}

	void sizer(){
		transform.localScale += new Vector3(scaleM,scaleM,scaleM);
	}

	void Update () {
		transform.position += transform.rotation * Vector3.up * Random.Range(speed -2f , speed) * Time.deltaTime;
	}
}
