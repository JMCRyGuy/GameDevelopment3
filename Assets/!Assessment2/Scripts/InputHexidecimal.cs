using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputHexidecimal : MonoBehaviour
{
    public HexcidecimalConverter aHexcidecimalNumber;
    public HexcidecimalConverter bHexcidecimalNumber;
    public GameObject hexPannelRef;


    public HexcidecimalConverter answerHexcidecimalNumber;
    public List<int> currentIntStorage;
    public List<QuestionObject> questionsToAnswer;
    public TextMeshProUGUI textRef;

    int questionIndex;
    int result;
    bool hexActive = false;
    bool winGameExit = false;
    public SceneManage sceneManageRef;


    void Start()
    {

        UpdateQuestion();
        UpdateNumber();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && winGameExit)
        {
            sceneManageRef.TransitionScene(0);
        }


    }


    public void NumberPress(int x)
    {

        if(currentIntStorage.Count == 1 && currentIntStorage[0] == 0)
        {
            currentIntStorage.RemoveAt(0);
        }
        currentIntStorage.Insert(0, x);

        
        
        UpdateNumber();
    }

    public void DeletePress()
    {
        if (currentIntStorage.Count > 1)
        {
            currentIntStorage.RemoveAt(0);
            
        }
        else
        {
            currentIntStorage.RemoveAt(0);
            currentIntStorage.Insert(0, 0);
        }
        UpdateNumber();

    }

    public void EnterPress()
    {
        int x = aHexcidecimalNumber.input + bHexcidecimalNumber.input;
        print("Result :" + x);
        if(x == result)
        {
            textRef.text = questionsToAnswer[questionIndex].rightAnswerText;
            questionIndex++;
            UpdateQuestion();
            currentIntStorage.Clear();
            UpdateNumber();
            
        }
        else if(!hexActive && x >= 10)
        {
            hexPannelRef.SetActive(true);
            hexActive = true;
            textRef.text = questionsToAnswer[questionIndex].wrongAnswerText;

        }
        else
        {
            textRef.text = questionsToAnswer[questionIndex].wrongAnswerText;
        }
        
        
    }


    void UpdateNumber()
    {
        result = 0;
        for (int i = 0; i < currentIntStorage.Count; i++)
        {

            result += currentIntStorage[i] * ((int)Mathf.Pow(16, i));
            print(i + ":" + currentIntStorage[i] + ":" + currentIntStorage[i] * ((int)Mathf.Pow(16, i)));
        }
        print(result);
        answerHexcidecimalNumber.HexidecimalReset(result, 0);
    }

    void UpdateQuestion()
    {
        if (questionsToAnswer.Count > questionIndex)
        {
            aHexcidecimalNumber.HexidecimalReset(questionsToAnswer[questionIndex].numberA, 0);
            bHexcidecimalNumber.HexidecimalReset(questionsToAnswer[questionIndex].numberB, 0);
        }
        else
        {
            winGameExit = true;
        }

    }



}
