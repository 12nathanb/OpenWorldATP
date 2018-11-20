using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class PlayerDetect : MonoBehaviour {

    public float range;

    private Transform point;
    private Transform player;

    public GameObject plane;

    public GameObject chunk;

    private bool isActive = false;

    public SaveChunk save;

    private GameObject gm;

    [XmlAttribute("name")]
    public string name;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        SaveChunk save = gm.GetComponent<SaveChunk>();
        point = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dis = Distance();

		if (dis <= range && isActive == false)
        {
           chunk = Instantiate(plane, point.position, Quaternion.identity);
            chunk.name = this.gameObject.name + " Chunk";
            name = chunk.name;
            chunk.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            save.chunks.Add(chunk);
            save.Save("D:/OpenWorldATP/Open World/Assets/chunks.txt");
            isActive = true;
        }

        if (dis > range && isActive == true)
        {
            Destroy(chunk);
            isActive = false;
        }
    }

    private float Distance()
    {
        return Vector3.Distance(point.position, player.position);
    }
}
