using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public int sideMoveSpeed;
    
    public float horizontal;
    
    Vector3 lastTransition;
    Vector3 lastRotation;
    bool crashed = false;

    [HideInInspector] public Vector3 initPos = Vector3.zero;

    private void OnEnable()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -10f)
        {
            transform.position = initPos;
        }
        if (!crashed)
        {
            SideMovement();
        }
    }
    void SideMovement()
    {
        
        horizontal = Input.GetAxis("Horizontal");


        

        //put this in an if statement if not touching block
        Vector3 newPosition = new Vector3(0.0f, 0.0f, -horizontal);
        Vector3 newRotation = new Vector3((newPosition.x + lastTransition.x) / 2, 0.0f, (newPosition.z + lastTransition.z) / 2);
         //so the player looks in the direction it is moving in
        transform.Translate(newPosition * sideMoveSpeed * Time.deltaTime, Space.World);
        lastTransition = newRotation;
    }

    public void CrashSide()
    {
        crashed = true;
    }

}
