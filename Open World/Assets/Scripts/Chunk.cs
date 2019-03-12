using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

	public GameObject point;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setChunkPoint(GameObject obj)
	{
		point = obj;
	}

	void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Block")
        {
           point.GetComponent<PlayerDetect>().StoreGameObject(other.gameObject);
		   other.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }
}
