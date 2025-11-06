using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadGame()
    {
        print("Bouton cliqué");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Fermeture");
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
}
