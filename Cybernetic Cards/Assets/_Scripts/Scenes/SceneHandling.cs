using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scene Handling")]
public class SceneHandling : ScriptableObject
{
	public event Action onBattleSceneLoaded;
	public event Action onSandboxSceneLoaded;


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
		if (scene.name == "Sandbox")
		{
			SandboxSceneLoadActions();
		}
		if (scene.name == "Battle")
		{
			BattleSceneLoadActions();
		}
	}

	private void BattleSceneLoadActions()
	{
		onBattleSceneLoaded();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Debug.Log("Scene1 load");
	}

	private void SandboxSceneLoadActions()
	{
		onSandboxSceneLoaded();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Debug.Log("Scene0 load");
	}
}
