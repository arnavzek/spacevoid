using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class Health : MonoBehaviour {

	public float health = 1f;
	public Image Life;
	public Transform BigExplosion;


	public void Damage(){

		Life.GetComponent<Image> ().fillAmount -= 0.1f;
		health -= 0.1f;
		if (health <= 0) {
			transform.GetComponent<Scoring>().EndGame();
			Instantiate (BigExplosion, Vector3.zero, Quaternion.identity);
		}
	}



	public void Increase(){
		if (health < 1f) {
			health += 0.1f;
			Life.GetComponent<Image>().fillAmount += 0.1f;
		}
	}
		
}
