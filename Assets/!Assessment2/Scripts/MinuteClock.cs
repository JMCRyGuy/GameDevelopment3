using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinuteClock : MonoBehaviour
{
    float horizontal;
    public HourClock firstClockHand;
    public float speed = 1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        MoveHand();
    }

    void MoveHand()
    {
        horizontal = Input.GetAxis("Horizontal");
        //float total = gameObject.transform.rotation.z + horizontal * Time.deltaTime;

        transform.Rotate(0f, 0f, horizontal * speed /* * Time.deltaTime*/);
        firstClockHand.MoveSmallHand(horizontal * speed);
        /* if (total >= 360)
        {
            transform.Rotate(0f,0f, total - 360);
        }
        else if (total < 0)
        {
            transform.Rotate(0f, 0f, total + 360);
        }
        else
        {
            
        } */


    }

}
