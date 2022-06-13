using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockEvaluator : MonoBehaviour
{
    public HourClock randomClockHand;
    public HourClock playerClockHand;
    public RandomRotation randomRotationRef;
    public float range;

    public float ranZ;
    public float plaz;
    public float dif;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(randomClockHand.transform.rotation.eulerAngles.z - playerClockHand.transform.rotation.eulerAngles.z) < range/*randomClockHand.transform.rotation.z == playerClockHand.transform.position.z*/)
        {
            print(randomClockHand.transform.rotation.eulerAngles.z - playerClockHand.transform.rotation.eulerAngles.z);
        }
        ranZ = randomClockHand.transform.rotation.eulerAngles.z;
        plaz = playerClockHand.transform.rotation.eulerAngles.z;
        dif = randomClockHand.transform.rotation.eulerAngles.z - playerClockHand.transform.rotation.eulerAngles.z;

    }
}
