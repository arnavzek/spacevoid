using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseCanvas;
	public Sprite Mute;
	public Sprite MuteOff;
	public Button AudioButton;
	public Animator ResetMenu;

	void Start() {
		if (AudioListener.volume == 0) {
			AudioButton.GetComponent<Image> ().sprite = Mute;
		} else {
			AudioButton.GetComponent<Image> ().sprite = MuteOff;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause ();
		}
	}
		

	public void Pause(){
		PauseCanvas.SetActive(true);
	}

	public void Resume(){
		ResetMenu.Play ("PauseMenu",-1, 0);
		PauseCanvas.SetActive(false);
		Time.timeScale = 1;
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	public void TheBegining(){
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
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


}
