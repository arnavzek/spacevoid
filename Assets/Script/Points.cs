using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {


	private Transform ScoreSys;
	public Transform Collecttion;
	public Transform Explode;
	private Transform Player;
	public float threshold = 0.2f;
	private bool canMove = false;
	Vector3 dir;
	public float speed = 5f;
	public float Random1 = 0.5f;
	public float Random2 = 2f;
	public int Health = 2;

	void Start(){
		Player = GameObject.Find("Player").transform;
		ScoreSys = GameObject.Find("GameManager").transform;
		Invoke("StartMoving", Random.Range(1f, 2f));
	}

	void StartMoving()
	{
		canMove = true;
	}


	void Update ()
	{
		dir = (Player.position - transform.position);
		if (dir.magnitude > threshold && canMove == true)
		{
			transform.localPosition += dir.normalized * speed * Random.Range(0.6f, 2.4f) * Time.deltaTime;

		}

	}
	
	private void OnTriggerEnter2D(Collider2D other){

		if(Health > 0 && other.tag == "Bullet"){
			Health -= 1;
			Instantiate (Explode, transform.position, Quaternion.identity);
		}	else if (other.tag == "Bullet" && Health <= 0) {
			Instantiate (Explode, transform.position, Quaternion.identity);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}	else if (other.tag == "Player") {
			Instantiate (Collecttion, Player.position, Quaternion.identity);
			ScoreSys.GetComponent<Scoring> ().scored();
			Destroy (gameObject);
		}



	}
}
