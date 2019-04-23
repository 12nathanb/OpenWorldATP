using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Builder : MonoBehaviour {

	public Dropdown drop;
	public GameObject cubePrefab;
	public GameObject spherePrefab;

	bool canPlace = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
        if(Input.GetButtonDown("Fire1") && canPlace == true)
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
			
        if(drop.value != 2)
				{
					cube.transform.position = new Vector3(Mathf.Round(cube.transform.position.x), cube.transform.position.y,
											  Mathf.Round(cube.transform.position.z));
            Debug.Log("place");
				}   
			
        }	
	}

	void OnTriggerEnter(Collider other)
	{
		if(drop.value == 2)
		{
			if(other.gameObject.tag == "Enemy")
			{
					float rand = Random.Range(1f, 3f);
					other.gameObject.GetComponent<WanderAI>().Health -= rand;
			}
		}

		if(other.gameObject.tag == "Block" || other.gameObject.tag == "Sphere")
		{
				canPlace = false;
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Block" || other.gameObject.tag == "Sphere")
		{
				canPlace = true;
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
