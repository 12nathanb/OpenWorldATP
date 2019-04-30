using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class ChunkData{

    public float[] x;
    public float[] y;
    public float[] z;
    public string[] objname;

    public string[] location;
    public string Name;

    public bool enemyHasBeenmade;

    public ChunkData(List<GameObject> obj, string name, bool enemyMade)
    {
        z = new float[obj.Count];
        x = new float[obj.Count];
        y = new float[obj.Count];
        location = new string[obj.Count];

        objname = new string[obj.Count];

       for(int i = 0; i < obj.Count; i++)
       {
           x[i] = obj[i].transform.position.x;
           z[i] = obj[i].transform.position.z;
           y[i] = obj[i].transform.position.y;
           objname[i] = obj[i].gameObject.name;
           
           location[i] = obj[i].gameObject.tag;
        
       }

       Name = name;
       enemyHasBeenmade = enemyMade;
       Debug.Log(x[0]);
       Debug.Log(y[0]);
       Debug.Log(z[0]);
       Debug.Log(objname[0]);
    }


}

