using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MapPointGen : MonoBehaviour {

    public int MapWidth;
    public int MapHeight;
    public int ChunkWidth;
    public int ChunkHeight;
    public Transform plane;

    public List<Transform> pointList;
    public NavMeshSurface surface;
    // Use this for initialization
    void Start ()
    {


		for(int x = 0; x < MapWidth; x++)
        {
            for(int y = 0; y < MapHeight; y++)
            {
              
                pointList.Add (Instantiate(plane, new Vector3(x * ChunkWidth, 0 , y * ChunkHeight), Quaternion.identity));

            }
        }

        for(int i = 0; i < pointList.Count; i++)
        {
            pointList[i].name = "Point" + i;
            pointList[i].SetParent(this.transform);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
