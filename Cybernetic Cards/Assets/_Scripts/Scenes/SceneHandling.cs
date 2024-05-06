using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scene Handling")]
public class SceneHandling : ScriptableObject
{
	public event Action onBattleSceneLoaded;

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(scene.name == "Battle")
		{
			onBattleSceneLoaded();
		}		
	}
}
