using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem  {

    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.AT";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Player Saved");
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.AT";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No file");
            return null;
        }
    }

    public static ChunkData LoadChunk(string name)
    {
        string path = Application.persistentDataPath + "/Saved" + name + ".AT";
        Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            if(stream != null)
            {
                ChunkData data = formatter.Deserialize(stream) as ChunkData;
                stream.Close();
                return data;
            }
            else
            {
                stream.Close();
                return null;
            }
            

            
            Debug.Log("WOOOO");
            
        }
        else
        {
            Debug.Log("No file");
            return null;
        }
    }

    public static void SaveChunk(List<GameObject> obj, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Saved" + name + ".AT";
        FileStream stream = new FileStream(path, FileMode.Create);

        ChunkData data = new ChunkData(obj, name);
       
        formatter.Serialize(stream, data);
        stream.Close();
    }
	
}
