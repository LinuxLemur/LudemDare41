using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField] private string scentoload;
    [SerializeField] private Loadout loadout;

    // called first
    void OnEnable ()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        //  var loadout = gameObject.GetComponent<Loadout>();
        if (loadout == null)
        {
            return;
        }
        loadout.setCards ();
    }

    // called when the game is terminated
    void OnDisable ()
    {
        Debug.Log ("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadTheScene ()
    {
        SceneManager.LoadScene (scentoload);
    }
}