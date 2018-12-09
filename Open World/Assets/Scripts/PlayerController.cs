using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anim;


    void Start()
    {
        LoadPlayer();
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 2.0f;
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SaveSystem.SavePlayer(this);
        }
        anim.SetFloat("Horizontal", (x * 10));
        anim.SetFloat("Vertical", (z * 10));
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (x <= 0.1 || z <= 0.1)
        {
            
        }
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];
        transform.position = pos;
    }
}
