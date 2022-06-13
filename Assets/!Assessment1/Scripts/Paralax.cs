using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private Vector3 startPos;
    public float distanceOffset;
    public float multiplyOffsetCheck;
    public GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x <= playerRef.transform.position.x - distanceOffset / multiplyOffsetCheck)
        {
            transform.position = startPos + new Vector3(distanceOffset, 0, 0);
            startPos = transform.position;

        }

    }
}
