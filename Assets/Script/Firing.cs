using UnityEngine;

public class Firing : MonoBehaviour {

	public GameObject Bullet;
	public float Timer = 0.3f;
	public float CountDown = 0.3f;
	public float offset = 0.5f;


	void Update () {

		Timer -= Time.deltaTime;

		if (Timer <= 0) {
			Timer = CountDown;
			Instantiate ( Bullet, transform.position + (transform.up * offset), transform.rotation );
		}
		
	}
}
