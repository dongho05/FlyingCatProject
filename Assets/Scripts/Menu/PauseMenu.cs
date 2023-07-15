
using UnityEngine;

public class PausedMenu : MonoBehaviour
{

    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    /// <summary>
    /// Handles the on click event from the Resume button
    /// </summary>
    public void HandleResumeButtonOnClickEvent()
    {
        //AudioManager.Play(AudioClipName.ButtonClick);

        // unpause game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public void HandleMainMenuButtonOnClickEvent()
    {
        //AudioManager.Play(AudioClipName.ExitClick);

        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManagers.GoMenu(MenuNames.Main);
    }

    public void HandleReplayButtonOnClickEvent()
    {
        //AudioManager.Play(AudioClipName.ButtonClick);

        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManagers.GoMenu(MenuNames.GamePlay);
    }

}
