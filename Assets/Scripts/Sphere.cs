using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    float movementfactor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float factor = 0.1f;
        //float factor = 0.25;
        Vector3 input = new Vector3(-Input.GetAxisRaw("Vertical"), 0,  Input.GetAxisRaw("Horizontal"));
        //input = input.normalized;
        input = input*factor;

        //print(Vector3.Scale(new Vector3(0.5f, 0.5f, 0.5f), input));
        //transform.Rotation = Quaternion.Euler();
                //transform.localRotation = Quaternion.Euler();
        transform.Rotate(input,Space.World);
    }
}
