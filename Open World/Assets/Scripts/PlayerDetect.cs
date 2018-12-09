using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
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
    public GameObject gm;
   public string filetemp;
    [XmlAttribute("name")]
    public string name;
    // Use this for initialization
    void Start ()
    {
        Debug.Log(filetemp);
        gm = GameObject.FindGameObjectWithTag("GameController");
        SaveChunk save = gm.GetComponent<SaveChunk>();
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
            CheckForFile();
            
        }

        if (dis > range && isActive == true)
        {
            Destroy(chunk);
            isActive = false;
        }
    }

    private float Distance()
    {
        return Vector3.Distance(point.position, player.position);
    }

    void CheckForFile()
    {
        

        if (File.Exists(filetemp))
        {
            loadChunk(filetemp);
            populateLevel();
            Debug.Log("fileExists");
        }
        else
        {
            File.Create(filetemp);
            loadChunk(filetemp);
            populateLevel();
            Debug.Log("newFile");
        }
    }


    private void loadChunk(string file_path)
    {
        string save;
        
    StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadToEnd();
            save = inp_ln;
            test = save.ToCharArray();

            for (int i = 0; i < test.Length; i++)
            {
                if(test[i].ToString() == "1")
                {
                    oneCount++;
                    testArray.Add(1);

                }
                else if (test[i].ToString() == "0")
                {
                    testArray.Add(0);
                }
                else if (test[i].ToString() == "3")
                {
                    testArray.Add(3);
                }
            }
        }

        inp_stm.Close();
       
    }

    void populateLevel()
    {
        chunk = Instantiate(plane, point.position, Quaternion.identity);
        chunk.name = this.gameObject.name + " Chunk";
        chunk.transform.SetParent(gm.transform);
        name = chunk.name;
        //chunk.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        isActive = true;

        int cant = 0;

        for (int i = 0; i < 10; i++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (testArray[cant] == 1)
                {
                    float posx = this.transform.position.x / 2;
                    float posy = this.transform.position.y / 2;

                    LoadedInObjects.Add(Instantiate(cube, this.transform.position - new Vector3(i- 4.5f , -0.5f, y - 4.5f ), Quaternion.identity));
                    LoadedInObjects[cant].name = this.gameObject.name + "wall " + cant;
                    LoadedInObjects[cant].transform.SetParent(chunk.transform);
                }
                else
                {
                    LoadedInObjects.Add(null);
                }
                if ((testArray[cant] == 3))
                {
                    LoadedInObjects.Add(Instantiate(enemy, this.transform.position - new Vector3(i - 4.5f, -1f, y - 4.5f), Quaternion.identity));
                }


                cant++;
            }
        }

        for(int s = 0; s < LoadedInObjects.Count; s++)
        {
            
        }
    }
}
