using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

	[SerializeField] private GameObject _controlsDialogue;
	[SerializeField] private GameObject _historyDialogue;
	[SerializeField] private GameObject _resourcesDialogue;
	
	public void Exit()
	{
		Application.Quit();
	}

	public void ShowControls()
	{
		_controlsDialogue.SetActive(true);
	}

	public void HideControls()
	{
		_controlsDialogue.SetActive(false);
	}

	public void ShowHistory()
	{
		_historyDialogue.SetActive(true);
	}

	public void HideHistory()
	{
		_historyDialogue.SetActive(false);
	}
	
	public void ShowResources()
	{
		_resourcesDialogue.SetActive(true);
	}

	public void HideResources()
	{
		_resourcesDialogue.SetActive(false);
	}

	public void OpenGamin()
	{
		Application.OpenURL("https://gamin.me");
	}

	public void StartHame()
	{
		SceneManager.LoadSceneAsync("Main");
	}
}
