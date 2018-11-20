using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointGen : MonoBehaviour {

    public int MapWidth;
    public int MapHeight;
    public Transform plane;

    public List<Transform> pointList;

	// Use this for initialization
	void Start ()
    {
      
		for(int x = 0; x < MapWidth; x++)
        {
            for(int y = 0; y < MapHeight; y++)
            {
                pointList.Add (Instantiate(plane, new Vector3(x * 10, 0 , y * 10), Quaternion.identity));
                pointList[x * y].name = "Point" + (x * y);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
