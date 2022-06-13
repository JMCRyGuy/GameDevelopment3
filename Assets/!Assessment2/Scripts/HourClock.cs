using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourClock : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject secondClockHand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveSmallHand(float x)
    {
        transform.Rotate(0, 0, x / 12);

    }
}
