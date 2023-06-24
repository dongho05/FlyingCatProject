using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnRateController : MonoBehaviour
{
    public static List<SpawnRatioObject> listSpawnRates = new List<SpawnRatioObject>();
    public static List<SpawnRatioObject> ReadSpawnRate()
    {
       
        string path = "Assets/Scripts/SpawnRate/SpawnRate.txt";
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);

            var line = reader.ReadToEnd();

            reader.Close();
            listSpawnRates = JsonConvert.DeserializeObject<List<SpawnRatioObject>>(line);
            Debug.Log(listSpawnRates[0].MediumPipe);
            return listSpawnRates;
        }
        else
        {
            return null;
        }
    }
    private void Awake()
    {
        ReadSpawnRate();
    }
}

