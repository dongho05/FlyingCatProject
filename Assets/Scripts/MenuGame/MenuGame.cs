using Assets.Scripts.MenuGame;
using UnityEngine;

public enum MenuName
{
    MainScene,
    Continue,
    InGame
}
public class MenuGame : MonoBehaviour
{
    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu(MenuName.InGame);
    }
    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ExitClick);
        Application.Quit();
    }
}
