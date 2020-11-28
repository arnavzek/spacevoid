using UnityEngine.UI;
using UnityEngine;

public class Scoring : MonoBehaviour {

	private int Points;
	public Text score;
	public Text HighScored;
	private GameObject player;
	public Text EndScore;
	public Text EndBest;
	private int increaser;
	public GameObject EndMenu;
	public GameObject Century;
	public GameObject ScoreCheerUp;
	public Font Baloo;
	private bool cheer = false;
	public GameObject ScoreMark;

	void Start(){
		Time.timeScale = 1;
		HighScored.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
		player = GameObject.Find("Player");

	}

	public void scored(){
		Points += 5;
		HighScore ();
		score.text = Points.ToString();
		if (Points / 100 == 1 && Points % 100 == 0) {
			Century.SetActive(true);
			Century.GetComponent<Text>().font = Baloo;
		}else if(Points / 100 == 2 && Points % 100 == 0){
			Century.SetActive(true);
			Century.GetComponent<Text> ().text = "!DOUBLE CENTURY!";
			Century.GetComponent<Text>().font = Baloo;
		}else if(Points / 100 == 3 && Points % 100 == 0){
			Century.SetActive(true);
			Century.GetComponent<Text> ().text = "!TRIPLE CENTURY!";
			Century.GetComponent<Text>().font = Baloo;
		}else if(Points / 100 > 3 && Points % 100 == 0){
			Century.SetActive(true);
			Century.GetComponent<Text> ().text = "HURRAY "+Points.ToString()+" POINTS";
			Century.GetComponent<Text>().font = Baloo;
		}
	}

	void HighScore(){

		if (Points > PlayerPrefs.GetInt("HighScore", 0) && Points > 50f) {
				
			if (cheer == false ) {
					ScoreCheerUp.SetActive(true);
					ScoreCheerUp.GetComponent<Text>().font = Baloo;
					cheer = true;
					ScoreMark.SetActive(true);
				}

			PlayerPrefs.SetInt ("HighScore" , Points);
		}
	}

	public void EndGame(){
		player.GetComponent<CircleCollider2D>().enabled = false;
		player.transform.localScale = new Vector3 (0,0,0);
		Invoke ("EndPortion",0.5f);

	}

	void EndPortion(){
		increaser = 0;
		EndMenu.SetActive(true);
		InvokeRepeating ("CoinEffect",0,0.001f);
		EndBest.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}

	public void CoinEffect(){
		if (increaser < Points) {
			increaser += 1;
			EndScore.text = increaser.ToString ();
		} else if(increaser == Points){
			Invoke ("invoketime",2f);
		}

	}

	void invoketime(){
		Time.timeScale = 0;
	}

}
