using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public HourClock firstHandRef;
    public MinuteClock secondHandRef;
    // Start is called before the first frame update
    void Start()
    {
        UpdateRandomRotation();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRandomRotation()
    {
        firstHandRef.transform.Rotate(0, 0, Random.Range(0, 360));
        secondHandRef.transform.Rotate(0, 0, firstHandRef.transform.rotation.z * 12);
    }


}
