using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Chunk : MonoBehaviour {

	public GameObject point;
  	ChunkData data;
	  
	public List<GameObject> gameobjectList;

	public GameObject cube;
	public GameObject sphere;

	// Use this for initialization
	void Start () 
	{
		string path = Application.persistentDataPath + "/Saved" + point.gameObject.name + ".AT";

		if(File.Exists(path))
		{
			data = SaveSystem.LoadChunk(point.gameObject.name.ToString());
			
			for(int i = 0; i < data.objname.Length; i++)
			{
				if(data.location[i] == "Block")
				{
					GameObject temp = Instantiate(cube, new Vector3(data.x[i],data.y[i],data.z[i]), Quaternion.identity);
					temp.gameObject.tag = "Block";
					temp.gameObject.transform.SetParent(this.gameObject.transform);
				}
				else if(data.location[i] == "Sphere")
				{
					GameObject temp = Instantiate(sphere, new Vector3(data.x[i],data.y[i],data.z[i]), Quaternion.identity);
					temp.gameObject.tag = "Sphere";
					temp.gameObject.transform.SetParent(this.gameObject.transform);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setChunkPoint(GameObject obj)
	{
		point = obj;
	}

	void  OnTriggerStay(Collider  other)
    {
        
    }

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
        {
			foreach (Transform child in transform)
			{
				if(child.tag == "Block" || child.tag == "Sphere")
				{
					gameobjectList.Add(child.gameObject);
				}
			}
			 if(gameobjectList.Count > 0)
			 {
				  SaveSystem.SaveChunk(gameobjectList, point.gameObject.name);
			 }
			
		}
	}
	void OnTriggerEnter(Collider  other)
	{
		if(other.gameObject.tag == "Player")
        {
			Debug.Log("Done");
           other.gameObject.GetComponent<PlayerController>().SavePlayer();
		}

		if(other.gameObject.tag == "Block" || other.gameObject.tag == "Sphere")
        {
			Debug.Log("AHHH BLOCK");
           point.GetComponent<PlayerDetect>().StoreGameObject(other.gameObject);
		   other.gameObject.transform.SetParent(this.gameObject.transform);
        }
	}
}
