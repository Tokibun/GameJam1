using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    float factor = 0.1f;
    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(-Input.GetAxisRaw("Vertical"), 0,  Input.GetAxisRaw("Horizontal"));
        input = input*factor;
        transform.Rotate(input,Space.World);
    }
}
