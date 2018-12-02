using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    void Start()
    {

    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 2.0f;

        

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
