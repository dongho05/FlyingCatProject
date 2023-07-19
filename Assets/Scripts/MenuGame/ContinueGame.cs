using Assets.Scripts.Obstacles;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueGame : MonoBehaviour
{
    public Button btnContinue;

    public static ContinueGame instance;
    public static bool IsEnter = false;

    private static string GetFilePath(string FolderName, string FileName = "")
    {
        string filePath;
        filePath = Path.Combine(Application.persistentDataPath, "data", FolderName);
        if (FileName != "")
            filePath = Path.Combine(filePath, FileName + ".json");
        return filePath;
    }

    public static List<Obstacle> GetInstance()
    {
        List<Obstacle> list = new List<Obstacle>();
        string enemyFilePath = "";
        enemyFilePath = GetFilePath("data", "dataObstacle");

        if (!Directory.Exists(Path.GetDirectoryName(enemyFilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(enemyFilePath));
        }
        else
        {
            StreamReader reader = new StreamReader(enemyFilePath, true);

            var line = reader.ReadToEnd();
            reader.Close();

            list = JsonConvert.DeserializeObject<List<Obstacle>>(line);

            return list;
        }

        return null;
        //    string path = "Assets/Scripts/Obstacles/data.dat";
        //List<Obstacle> list = new List<Obstacle>();
        //if (File.Exists(path))
        //{

        //    StreamReader reader = new StreamReader(path, true);

        //    var line = reader.ReadToEnd();
        //    reader.Close();

        //    list = JsonConvert.DeserializeObject<List<Obstacle>>(line);

        //    return list;
        //}
        //else
        //{
        //    return null;
        //}
    }
    //public static float LoadScore()
    //{
    //    var score = ActionWithFile.LoadScore();
    //    return float.Parse(score);
    //}
    public void LoadGameObject()
    {
        List<GameObject> listShort = new List<GameObject>();
        List<GameObject> listMedium = new List<GameObject>();
        List<GameObject> listLong = new List<GameObject>();

        var listObjectInFile = GetInstance();
        ObjectPool.instance.Loadfile(listObjectInFile);


    }

    public static float LoadScore()
    {
        var score = PauseMenu.LoadScore();
        return float.Parse(score);
    }
    public void HandleContinueButtonOnClickEvent()
    {
        List<Obstacle> list = new List<Obstacle>();
        if (list != null)
        {
            IsEnter = true;
            SceneManager.LoadScene("Flappy");

        }
        else
        {
            btnContinue.interactable = false;
            Debug.Log("File does not exist!");
        }

    }
}
