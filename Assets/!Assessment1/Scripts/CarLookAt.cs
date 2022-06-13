using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLookAt : MonoBehaviour
{
    public Transform lookAt;
    public Vector3 cameraOffset;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public Player playerRef;
    public PlayerMovement playerMovementRef;
    public GameObject[] crashParticles;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookAt.position);
        


        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, lookAt.position - cameraOffset, ref velocity, smoothTime);
        
    }

    public void CrashParticleSystems()
    {
        foreach(GameObject particleRef in crashParticles)
        {
            particleRef.SetActive(true);
            if (particleRef.GetComponent<ParticleSystem>() != null)
            {
                gameObject.GetComponent<ParticleSystem>().Play();
            }
        }

    }

}
