using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockEvaluator : MonoBehaviour
{
    public HourClock randomClockHand;
    public HourClock playerClockHand;
    public RandomRotation randomRotationRef;
    public float range;
    public int countTillWin = 1000;
    public TextMeshPro textRef;
    public SceneManage sceneManageRef;

    public float ranZ;
    public float plaz;
    public float dif;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = counter / 10;
        if (Mathf.Abs(randomClockHand.transform.rotation.eulerAngles.z - playerClockHand.transform.rotation.eulerAngles.z) < range/*randomClockHand.transform.rotation.z == playerClockHand.transform.position.z*/)
        {
            
            if(counter >= countTillWin)
            {
                textRef.text = "Winner!!  Click to Exit Game";
                
            }
            else
            {
                counter++;
                x = counter / 10;
                print(counter);
                textRef.text = x + "%";
            }
            
        }
        else if(counter < countTillWin)
        {

            counter = 0;
            textRef.text = x + "%";
        }
        ranZ = randomClockHand.transform.rotation.eulerAngles.z;
        plaz = playerClockHand.transform.rotation.eulerAngles.z;
        dif = randomClockHand.transform.rotation.eulerAngles.z - playerClockHand.transform.rotation.eulerAngles.z;
        
        if(Input.GetMouseButtonDown(0) && counter >= countTillWin)
        {
            sceneManageRef.TransitionScene(0);
        }

        
    }





    
}
