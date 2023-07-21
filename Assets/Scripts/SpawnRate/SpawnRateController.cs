using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnRateController : MonoBehaviour
{
    public static List<SpawnRatioObject> listSpawnRates = new List<SpawnRatioObject>();

    private static string GetFilePath(string FolderName, string FileName = "")
    {
        string filePath;
        filePath = Path.Combine(Application.persistentDataPath, "SpawnRate", FolderName);
        if (FileName != "")
            filePath = Path.Combine(filePath, FileName + ".json");
        return filePath;
    }

    public static List<SpawnRatioObject> ReadSpawnRate()
    {

        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 80, MediumPipe = 20, LongPipe = 0 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 70, MediumPipe = 30, LongPipe = 0 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 60, MediumPipe = 40, LongPipe = 0 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 50, MediumPipe = 50, LongPipe = 0 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 45, MediumPipe = 45, LongPipe = 5 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 45, MediumPipe = 45, LongPipe = 10 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 40, MediumPipe = 50, LongPipe = 10 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 40, MediumPipe = 45, LongPipe = 15 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 40, MediumPipe = 45, LongPipe = 15 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 35, MediumPipe = 50, LongPipe = 15 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 30, MediumPipe = 50, LongPipe = 20 }
        );
        listSpawnRates.Add(
            new SpawnRatioObject { ShortPipe = 30, MediumPipe = 50, LongPipe = 20 }
        );


        string path = GetFilePath("data", "SpawnRate");
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);

            var line = reader.ReadToEnd();

            reader.Close();
            listSpawnRates = JsonConvert.DeserializeObject<List<SpawnRatioObject>>(line);
            Debug.Log("Game:" + listSpawnRates[0].MediumPipe);
            return listSpawnRates;
        }
        else
        {
            Debug.Log("Game: 123" + listSpawnRates[0].MediumPipe);
            return null;
        }
    }
    private void Awake()
    {
        ReadSpawnRate();
    }
}

