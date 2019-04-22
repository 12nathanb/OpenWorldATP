using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Chunk : MonoBehaviour {

	public GameObject point;
  	ChunkData data;
	
	public Transform GM;
	public List<GameObject> gameobjectList;

	public GameObject cube;
	public GameObject sphere;

	public GameObject enemy;

	bool canSpawn = true;

	// Use this for initialization
	void Start () 
	{
		GM = GameObject.FindGameObjectWithTag("GameController").transform;

		enemyCanSpawn();

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
				else if(data.location[i] == "Enemy")
				{
					GameObject temp = Instantiate(enemy, new Vector3(data.x[i],data.y[i],data.z[i]), Quaternion.identity);
					temp.gameObject.tag = "Enemy";
					temp.gameObject.transform.SetParent(this.gameObject.transform);
				}
			}
		}
		float num = Random.Range(0f, 100f);
		if(num >= 80 && canSpawn == true)
		{
			Vector3 position = new Vector3(point.transform.position.x, 3, point.transform.position.z);
			Instantiate(enemy, position, Quaternion.identity);
		}
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemyCanSpawn();
	}

	void enemyCanSpawn()
	{
		if(GM.GetComponent<MapPointGen>().enemyCount >= 20)
		{
			canSpawn = false;
		}
		else
		{
			canSpawn = true;
		}
	}

	public void setChunkPoint(GameObject obj)
	{
		point = obj;
	}

	void  OnTriggerStay(Collider  other)
    {
        
    }

	void OnDestroy()
	{
		
			foreach (Transform child in transform)
			{
				if(child.tag == "Block" || child.tag == "Sphere" || child.tag == "Enemy")
				{
					gameobjectList.Add(child.gameObject);
				}
			}
			 if(gameobjectList.Count > 0)
			 {
				  SaveSystem.SaveChunk(gameobjectList, point.gameObject.name);
			 }
			
		
	}
	void OnTriggerEnter(Collider  other)
	{
	

		if(other.gameObject.tag == "Block" || other.gameObject.tag == "Sphere"  || other.gameObject.tag == "Enemy")
        {
			Debug.Log("AHHH BLOCK");
           point.GetComponent<PlayerDetect>().StoreGameObject(other.gameObject);
		   other.gameObject.transform.SetParent(this.gameObject.transform);
        }
	}
}
