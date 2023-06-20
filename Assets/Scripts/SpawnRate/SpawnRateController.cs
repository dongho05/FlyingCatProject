using System.IO;
using UnityEngine;

public class SpawnRateController : MonoBehaviour
{
    public static int ReadSpawnRate()
    {
        string path = "Assets/Resources/data.dat";
        if (File.Exists(path))
        {

            StreamReader reader = new StreamReader(path, true);

            var line = reader.ReadToEnd();
            reader.Close();


            return line.Length;
        }
        else
        {
            return 0;
        }
    }
}

