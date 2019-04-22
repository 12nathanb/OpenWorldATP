﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Builder : MonoBehaviour {

	public Dropdown drop;
	public GameObject cubePrefab;
	public GameObject spherePrefab;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
        if(Input.GetButtonDown("Fire1"))
        {
			GameObject cube = null;
			switch(drop.value)
			{
				case 0:
				cube = Instantiate(cubePrefab, this.transform.position, Quaternion.identity);
				break;
				case 1:
				cube = Instantiate(spherePrefab, this.transform.position, Quaternion.identity);
				break;
				case 2:
				break;
			}
			
            
			cube.transform.position = new Vector3(Mathf.Round(cube.transform.position.x), cube.transform.position.y,
											  Mathf.Round(cube.transform.position.z));
            Debug.Log("place");
        }	
	}

	void  OnTriggerStay(Collider  other)
    {
		if(Input.GetButtonDown("Fire2"))
        {
			if(other.gameObject.tag == "Block" || other.gameObject.tag == "Sphere" )
			{
				Destroy(other.gameObject);
			}
		}
    }
}
