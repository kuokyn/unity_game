using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

	public GameObject gameObjectImage;
	public Sprite NewSprite;

	public void StartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ChangeImage()
	{
		gameObjectImage.GetComponent<Image>().sprite = NewSprite;
	}
}
