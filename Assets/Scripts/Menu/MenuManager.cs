
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages navigation through the menu system
/// </summary>
public static class MenuManagers
{
    /// <summary>
    /// Goes to the menu with the given name
    /// </summary>
    /// <param name="name">name of the menu to go to</param>
    public static void GoMenu(MenuNames name)
    {
        switch (name)
        {
            //case MenuName.Difficulty:

            //    // go to DifficultyMenu scene
            //    SceneManager.LoadScene("DifficultyMenu");
            //    break;
            //case MenuName.HighScore:

            //    // deactivate MainMenuCanvas and instantiate prefab
            //    GameObject mainMenuCanvas = GameObject.Find("MainMenuCanvas");
            //    if (mainMenuCanvas != null)
            //    {
            //        mainMenuCanvas.SetActive(false);
            //    }
            //    Object.Instantiate(Resources.Load("HighScoreMenu"));
            //    break;
            case MenuNames.Main:

                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuNames.Pause:

                // instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuNames.GamePlay:
                SceneManager.LoadScene("SampleScene");
                break;
        }

    }
}
