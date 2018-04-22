using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas MainMenuCanvas;
    [SerializeField] private Canvas OptionsCanvas;
    [SerializeField] private Canvas LoadoutCanvas;

    [SerializeField] private string SceneToLoad;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void ShowMainMenuCanvas()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        OptionsCanvas.gameObject.SetActive(false);       
        LoadoutCanvas.gameObject.SetActive(false);
    }

    public void ShowOptionsCanvas()
    { 
        OptionsCanvas.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(false);
        LoadoutCanvas.gameObject.SetActive(false);
    }

    public void ShowLoadoutCanvas()
    {     
        LoadoutCanvas.gameObject.SetActive(true);
        OptionsCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(false);       
    }   
}
