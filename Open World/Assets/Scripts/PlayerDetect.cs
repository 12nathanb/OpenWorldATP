using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
public class PlayerDetect : MonoBehaviour {

    public float range;

    private Transform point;
    private Transform player;
    public GameObject cube;
    public GameObject enemy;
    public GameObject plane;
    public int oneCount;
    public GameObject chunk;
    public const string sfloor_obstacle = "1";
    private bool isActive = false;
    public List <int> testArray;
    public List<GameObject> LoadedInObjects;
    public char[] test;
    ChunkData data;

    // Use this for initialization
    void Start ()
    {
        data = SaveSystem.LoadChunk(this.gameObject.name.ToString());
        point = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        float dis = Distance();
       // 
		if (dis <= range && isActive == false)
        {
            populateLevel();
            
             isActive = true;
            if(data != null)
            {
               LoadLevel();
            }
             
        }

        if (dis > range && isActive == true)
        {
            Destroy(chunk);
            isActive = false;
        }

        if(LoadedInObjects.Count >= 1)
        {
            SaveSystem.SaveChunk(LoadedInObjects, this.gameObject.name.ToString());
        }
    }

    private float Distance()
    {
        return Vector3.Distance(point.position, player.position);
    }

  
    public void StoreGameObject(GameObject store)
    {
        LoadedInObjects.Add(store);
    }
    
    void LoadLevel()
    {
       
        for(int i = 0; i < data.objname.Length; i++)
        {
            

            if(data.location[i] == "Block")
            {
                GameObject temp = Instantiate(cube, new Vector3(data.x[i],data.y[i],data.z[i]), Quaternion.identity);
                temp.gameObject.tag = "Block";
                temp.gameObject.transform.SetParent(chunk.gameObject.transform);
                LoadedInObjects.Add(temp);

            }
            

       }
        
        
    }


    public void addChunk(GameObject c)
    {
        chunk = c;
    }
    void populateLevel()
    {
        if(isActive == false)
        {
            chunk = Instantiate(plane, point.position, Quaternion.identity);
            chunk.GetComponent<Chunk>().setChunkPoint(this.gameObject);
        }     
    }
}
