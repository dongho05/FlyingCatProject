using Assets.Scripts.Flappy;
using Assets.Scripts.Obstacles;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    private List<Obstacle> list = new List<Obstacle>();
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
    public void Save()
    {
        GameObject[] shortObject = GameObject.FindGameObjectsWithTag("shortPipe");
        GameObject[] mediumObject = GameObject.FindGameObjectsWithTag("mediumPipe");
        GameObject[] longObject = GameObject.FindGameObjectsWithTag("longPipe");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        string pathPipe = "Assets/Scripts/Obstacles/data.dat";
        File.WriteAllText(pathPipe, "");
        foreach (var item in shortObject)
        {
            list.Add(new Obstacle
            {
                xPipe = item.transform.position.x,
                yPipe = item.transform.position.y,
                speed = ObstacleMove.speed,
                phase = ObstacleGenerate.phaseNow
            });
        }
        foreach (var item in mediumObject)
        {
            list.Add(new Obstacle
            {
                xPipe = item.transform.position.x,
                yPipe = item.transform.position.y,
                speed = ObstacleMove.speed,
                phase = ObstacleGenerate.phaseNow
            });
        }
        foreach (var item in longObject)
        {
            list.Add(new Obstacle
            {
                xPipe = item.transform.position.x,
                yPipe = item.transform.position.y,
                speed = ObstacleMove.speed,
                phase = ObstacleGenerate.phaseNow
            });
        }
        string resultP = JsonConvert.SerializeObject(list, Formatting.Indented);
        Debug.Log(resultP);
        File.WriteAllText(pathPipe, resultP);

        string pathPlayer = "Assets/Scripts/Flappy/player.dat";
        File.WriteAllText(pathPlayer, "");
        var cat = new Cat
        {
            xPlayer = player.transform.position.x,
            yPlayer = player.transform.position.y
        };
        string resultC = JsonConvert.SerializeObject(cat, Formatting.Indented);
        File.WriteAllText(pathPlayer, resultC);

        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        float score = hud.GetPoints();
        PlayerPrefs.SetString("Score", score.ToString());
    }
}
