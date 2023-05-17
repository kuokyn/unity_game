using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float speed = 1.5f;

    void Update()
    {
        transform.Rotate(0, 0, -360 * speed * Time.deltaTime);
    }
}
