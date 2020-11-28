using UnityEngine;

public class Enemy : MonoBehaviour {

	private Transform Player;
	public Transform Explode;
	private Transform slots;
	private Transform Main;
	public float speed = 5f;
	public float threshold = 0.2f;
	public int healthEnemy= 1 ;
	Vector3 dir;
	private bool canMove = false;
	private float randomscale;
	public float Random1 = 0.5f;
	public float Random2 = 2f;
	public Transform RedExplode;

	void Start(){
		Player = GameObject.Find("Player").transform;
		Main = GameObject.Find("GameManager").transform;
		slots = Player.GetChild(0).transform;
		Invoke("StartMoving", Random.Range(1f, 2f));
		randomscale = Random.Range (Random1,Random2);
		//transform.localScale = new Vector3 (randomscale,randomscale,randomscale);
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
			transform.localPosition += dir.normalized *   Random.Range(0, speed) * Time.deltaTime;

		}

	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Bullet") {

			if (healthEnemy > 0 ) {
				
				healthEnemy -= 1;
				Instantiate (Explode,transform.position,Quaternion.identity);

			}else if(healthEnemy <= 0 ){
				
				Instantiate (Explode,transform.position,Quaternion.identity);
				Destroy (other.gameObject);
				Destroy (gameObject);
			}


		} else if (other.tag == "Player") {
			
			Instantiate (RedExplode,Player.position,Quaternion.identity);
			Main.GetComponent<Health> ().Damage ();
			slots.GetComponent<GunSloting>().ResetSlot ();
			Destroy (gameObject);

		}



	}



}
