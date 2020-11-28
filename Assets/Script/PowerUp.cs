using UnityEngine;

public class PowerUp : MonoBehaviour {


	private Transform Slot;
	public Transform Collection;
	public Transform Explode;
	private Transform Player;
	public float threshold = 0.2f;
	private bool canMove = false;
	Vector3 dir;
	public float speed = 5f;


	void Start(){
		Player = GameObject.Find("Player").transform;
		Slot = Player.GetChild(0).transform;
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


		if (other.tag == "Bullet") {
			Instantiate (Explode, transform.position, Quaternion.identity);
			Destroy (other.gameObject);
			Destroy (gameObject);
		} else if (other.tag == "Player") {
			Instantiate (Collection, Player.position, Quaternion.identity);
			Slot.GetComponent<GunSloting>().GunPoint();
			Destroy (gameObject);
		}

	}
}
