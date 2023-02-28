using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class Saving
{
    public static void SaveLevel(GameManagerScript gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.lvles";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data data = new Data(gameManager);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(path);
    }

    public static Data LoadUnlocked()
    {
        string path = Application.persistentDataPath + "/level.lvles";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Data data = formatter.Deserialize(stream) as Data;
            Debug.Log(data.levelsUnlocked);
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file dead in " + path);
            return null;
        }
    }
    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/level.lvles";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
