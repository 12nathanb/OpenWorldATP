using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour {

    public string currentScene = null;
    public string nextScene = null;
    public string PreviousScene = null;

    
	// Use this for initialization
	void Start ()
    {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
        }
        
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.UnloadSceneAsync(PreviousScene);
        }

    }
}
