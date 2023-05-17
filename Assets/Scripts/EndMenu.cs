using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
   public void ExitGame()
	{
		Application.Quit();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("Level_1");
	}
}
