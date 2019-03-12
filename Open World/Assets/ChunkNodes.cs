using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkNodes : MonoBehaviour {

    GameObject gm;
    MapPointGen pg;
    public List<GameObject> points;
	// Use this for initialization
	void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        pg = gm.GetComponent<MapPointGen>();

        int count = 0;

        for(int x = 0; x < pg.ChunkWidth; x++)
        {
            for (int y = 0; y < pg.ChunkHeight; y++)
            {
                count++;
                points.Add(Instantiate(new GameObject(), this.transform.position - new Vector3(x  - 4.5f, 0.5f, y  - 4.5f), Quaternion.identity));
            }
        }

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
