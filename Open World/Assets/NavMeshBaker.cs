using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour {

    public GameObject[] chunks;
    public List<NavMeshSurface> surfaces;
    // Use this for initialization
    void Start ()
    {
        chunks = GameObject.FindGameObjectsWithTag("Chunk");

        for (int i = 0; i < surfaces.Count; i++)
        {
            surfaces.Add(chunks[i].GetComponent<NavMeshSurface>());
            //surfaces[i].BuildNavMesh();
        }



    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < surfaces.Count; i++)
        {
           // surfaces.Add(chunks[i].GetComponent<NavMeshSurface>());
            surfaces[i].BuildNavMesh();
        }

    }
}
