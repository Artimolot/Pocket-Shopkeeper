using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
	public int sceneID;
	public Button start;
	public bool check = false;
	public GameObject Load;
	public Image FillImg;
	private SaveLoadScene saveLoadScene = new SaveLoadScene();

	public void Awake()
	{
		if (PlayerPrefs.HasKey("SaveLoadScene"))
		{
			saveLoadScene = JsonUtility.FromJson<SaveLoadScene>(PlayerPrefs.GetString("SaveLoadScene"));
			check = saveLoadScene.check;
		}
		if(check == true)
		{
			check = false;
			Load.SetActive(false);
			saveLoadScene.check = check;
			PlayerPrefs.SetString("SaveLoadScene", JsonUtility.ToJson(saveLoadScene));
		}
		else
		{
			StartCoroutine(AsyncLoad());
		}
	}

	public void StartNewScene()
	{
		start.interactable = false;
		SceneManager.LoadSceneAsync(sceneID);
	}

	IEnumerator AsyncLoad()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
		while (!operation.isDone)
		{
			float progress = operation.progress / 0.9f;
			FillImg.fillAmount = progress;
			yield return null;
		}
	}
}

[SerializeField]
public class SaveLoadScene
{
	public bool check;
}
