using UnityEngine.SceneManagement;

namespace Assets.Scripts.MenuGame
{
    public static class MenuManager
    {
        public static void GoToMenu(MenuName name)
        {
            switch (name)
            {
                case MenuName.InGame:

                    // go to MainMenu scene
                    SceneManager.LoadScene("Flappy");
                    break;

                case MenuName.MainScene:
                    SceneManager.LoadScene("MenuGame");
                    break;
            }

        }
    }
}
