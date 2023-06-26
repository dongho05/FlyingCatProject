using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        SceneManager.LoadScene("MenuGame");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Flappy");
        Time.timeScale = 1f;
    }
}
