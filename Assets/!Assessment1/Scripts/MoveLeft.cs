using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 5;

    void Start()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
