using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Additional : MonoBehaviour {

	public Texture2D PosterTexture;
	public Text Points;

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
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Look at this! I just got " + Points.text + " Stars in SPACE VOID https://play.google.com/store/apps/details?id="+Application.identifier);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Space Void" );
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");


			currentActivity.Call("startActivity", intentObject);



		}
	}
}
