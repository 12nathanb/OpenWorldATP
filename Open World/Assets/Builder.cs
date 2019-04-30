using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Builder : MonoBehaviour {

	public Dropdown drop;
	public GameObject cubePrefab;
	public GameObject spherePrefab;
	public Animator anim;
	bool canPlace = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
				if(Input.GetKeyDown(KeyCode.F1))
				{
					drop.value = 0;
				}

				if(Input.GetKeyDown(KeyCode.F2))
				{
					drop.value = 1;
				}

				if(Input.GetKeyDown(KeyCode.F3))
				{
					drop.value = 2;
				}

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


			if(drop.value == 2)
			{
				RaycastHit hit;
				Vector3 fwd = transform.TransformDirection(Vector3.forward);
				if(Physics.Raycast(this.transform.position, fwd, out hit, 10))
				{
						if(hit.transform.tag == "Enemy")
							StartCoroutine(Attack(hit.transform.gameObject));
				}
				

        if(drop.value != 2)
				{
					cube.transform.position = new Vector3(Mathf.Round(cube.transform.position.x), cube.transform.position.y,
											  Mathf.Round(cube.transform.position.z));
            Debug.Log("place");
				}   
			
        }	
	}
	}

	void OnTriggerEnter(Collider other)
	{
		
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
IEnumerator Attack(GameObject other)
{
	anim.SetBool("Punch", true);
				
	other.gameObject.GetComponent<WanderAI>().Health -= 1;
					
	yield return new WaitForSeconds(0.5f);
		anim.SetBool("Punch", false);
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
