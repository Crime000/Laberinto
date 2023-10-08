using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{

    Rigidbody2D fisicas;

    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(85 * Vector3.forward * Time.deltaTime);
    }
}
