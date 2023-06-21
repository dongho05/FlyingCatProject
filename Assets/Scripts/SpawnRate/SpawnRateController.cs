using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnRateController : MonoBehaviour
{
    public static List<SpawnRatioObject> ReadSpawnRate()
    {
        var list = new List<SpawnRatioObject>();
        string path = "Assets/Scripts/SpawnRate/SpawnRate.txt";
        if (File.Exists(path))
        {

            StreamReader reader = new StreamReader(path, true);

            var line = reader.ReadToEnd();

            reader.Close();
            list = JsonConvert.DeserializeObject<List<SpawnRatioObject>>(line);
            Debug.Log(list.Count);
            return list;
        }
        else
        {
            return null;
        }
    }
    private void Start()
    {
        var list = ReadSpawnRate();
    }
}

