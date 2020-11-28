using UnityEngine;

public class NewLife : MonoBehaviour {

	private Transform Healthsys;
	public Transform Collection;
	public Transform Explode;
	private Transform Player;
	public float threshold = 0.2f;
	private bool canMove = false;
	Vector3 dir;
	public float speed = 5f;
	private float randomscale;

	void Start(){
		Player = GameObject.Find("Player").transform;
		Healthsys = GameObject.Find("GameManager").transform;
		Invoke("StartMoving", Random.Range(1f, 2f));
		randomscale = Random.Range (0.5f,2f);
		transform.localScale = new Vector3 (randomscale,randomscale,randomscale);
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


		if (other.tag == "Bullet") {
			Instantiate (Explode, transform.position, Quaternion.identity);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}else if (other.tag == "Player") {
			Instantiate (Collection, Player.position, Quaternion.identity);
			Healthsys.GetComponent<Health> ().Increase();
			Destroy (gameObject);
		}



	}

}
