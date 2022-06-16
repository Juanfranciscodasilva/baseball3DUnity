using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceletometro : MonoBehaviour
{

    private Rigidbody rb;

    private float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        tilt = Quaternion.Euler(90,0,0)*tilt;

        rb.AddForce(tilt * speed);
    }
}
