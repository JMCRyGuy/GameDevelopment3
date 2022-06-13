using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CarLookAt playerCar = collision.gameObject.GetComponent<CarLookAt>();

            playerCar.CrashParticleSystems();
            playerCar.playerRef.Crash();
            playerCar.playerMovementRef.CrashSide();
        }

        

    }
}
