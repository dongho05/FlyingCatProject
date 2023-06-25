using Assets.Scripts.MenuGame;
using UnityEngine;

public enum MenuName
{
    MainScene,
    InGame
}
public class MenuGame : MonoBehaviour
{
    public void HandlePlayButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.InGame);
    }
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
