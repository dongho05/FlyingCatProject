
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void HandlePlayButtonOnClickEvent()
    {
        //AudioManager.Play(AudioClipName.PlayClick);
        MenuManagers.GoMenu(MenuNames.GamePlay);
    }


    public void HandleQuitButtonOnClickEvent()
    {
        //AudioManager.Play(AudioClipName.ExitClick);
        Application.Quit();
    }












    ///// <summary>
    ///// Handles the on click event from the high score button
    ///// </summary>
    //public void HandleHighScoreButtonOnClickEvent()
    //{
    //    AudioManager.Play(AudioClipName.MenuButtonClick);
    //    MenuManager.GoToMenu(MenuName.HighScore);
    //}

    /// <summary>
    /// Handles the on click event from the quit button
    /// </summary>
    /// 

    //public void HandlePauseButtonOnClickEvent()
    //{
    //    AudioManager.Play(AudioClipName.ExitClick);
    //    MenuManager.GoToMenu(MenuName.Pause);
    //}



    //public void HandleVolumeButtonOnClickEvent()
    //{
    //    if (AudioListener.volume == 0)
    //    {
    //        AudioListener.volume = 1f;
    //        volBtn.image.color = Color.white;
    //        Debug.Log("On");
    //    }
    //    else if (AudioListener.volume == 1f)
    //    {
    //        AudioListener.volume = 0;
    //        volBtn.image.color = Color.gray;
    //        Debug.Log("Off");
    //    }
    //    Debug.Log(AudioListener.volume);
    //}


}
