using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandling : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneHandling Instance { get; private set; }

	private void Awake()
	{
        if(Instance == null)
        {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}       
        if(Instance != null)
        {
            Destroy(this);
        }
	}
	public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
