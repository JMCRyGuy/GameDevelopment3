using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    

    public void TransitionScene(int index)
    {
        SceneManager.LoadScene(index);

    }



}
