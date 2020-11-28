using System.IO;
using UnityEngine.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GoPlay : MonoBehaviour {

	private float Timing;
	public Sprite Mute;
	public Sprite MuteOff;
	public Button AudioButton;
	public Text HighScored;
	public GameObject Info;

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	void Start() {
		
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		Time.timeScale = 1;

		HighScored.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

		if (AudioListener.volume == 0) {
			AudioButton.GetComponent<Image> ().sprite = Mute;
		} else {
			AudioButton.GetComponent<Image> ().sprite = MuteOff;
		}
	}

	public void StartGame(){
		Timing = transform.GetComponent<Fading>().fader();
		Invoke ("LoadNextScene",Timing - 0.2f);
	}

	public void About(){
		
		Info.SetActive (true);
	}

	public void CloseAbout(){
		
		Info.SetActive (false);
	}

	void LoadNextScene(){
		SceneManager.LoadScene(1);
	}

	public void SoundOff(){
		if (AudioListener.volume == 1) {
			AudioButton.GetComponent<Image> ().sprite = Mute;
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
			AudioButton.GetComponent<Image> ().sprite = MuteOff;
		}

	}

	public void Rating(){
		Application.OpenURL ("market://details?id="+Application.identifier);
	}

	public Texture2D PosterTexture;


	public void Share ()
	{
		byte[] dataToSave = PosterTexture.EncodeToPNG();

		string destination = Path.Combine(Application.persistentDataPath,"Poster.png");

		File.WriteAllBytes(destination, dataToSave);

		if(!Application.isEditor)
		{
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Woah! this game is quite cool.you should give it a try, it's on play store. https://play.google.com/store/apps/details?id="+Application.identifier);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Space Void");
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");


			currentActivity.Call("startActivity", intentObject);



		}
	}


}
