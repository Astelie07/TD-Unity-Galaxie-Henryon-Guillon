using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _endMenu;

    void Start()
    {
        _pauseMenu.gameObject.SetActive(false);
        _endMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            GamePause(true);
        }
    }

    public void GamePause(bool state)
    {
        _pauseMenu.gameObject.SetActive(state);
        int boolInt = state ? 1 : 0;
        Time.timeScale = boolInt;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        Debug.Log("end game !");
        _endMenu.gameObject.SetActive(true);
        _pauseMenu.gameObject.SetActive(true);
    }

}
