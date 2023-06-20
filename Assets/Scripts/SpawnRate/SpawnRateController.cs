using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnRateController : MonoBehaviour
{
    static List<string> list = new List<string>();
    public static int ReadSpawnRate()
    {
        string path = "Assets/Scripts/SpawnRate/SpawnRate.txt";
        if (File.Exists(path))
        {

            StreamReader reader = new StreamReader(path, true);
            do
            {
                var line = reader.ReadLine();
                list.Add(line);

            } while (reader.ReadLine() == "");
            //var line = reader.ReadToEnd();
            reader.Close();


            return list.Count;
        }
        else
        {
            return 0;
        }
    }
}

