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
    public List<string> ObjectLocation;
    public char[] test;
    public GameObject gm;

    ChunkData data;
   public string filetemp;
    [XmlAttribute("name")]
    public string name;
    // Use this for initialization
    void Start ()
    {
        data = SaveSystem.LoadChunk(this.gameObject.name.ToString());
        Debug.Log(filetemp);
        gm = GameObject.FindGameObjectWithTag("GameController");
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
          
            filetemp = "Assets/Level/" + this.gameObject.name + ".txt";
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
        ObjectLocation.Add(AssetDatabase.GetAssetPath(store));

    }
    
    void LoadLevel()
    {
        for(int i = 0; i < data.objname.Length; i++)
            {
               
                  LoadedInObjects.Add((GameObject)AssetDatabase.LoadAssetAtPath(data.location[i].ToString(), typeof(GameObject)));
            
            }
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
