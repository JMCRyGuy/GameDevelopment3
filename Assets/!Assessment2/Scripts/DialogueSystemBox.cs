using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystemBox : MonoBehaviour
{
    public DialogueObject currentDialogue;
    public Text textRef;
    
    private int index;
    private bool isChoice;

    public GameObject choiceBox;
    public GameObject[] choiceButtons;





    // Start is called before the first frame update
    void Start()
    {
        NextDialogue();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            index++;
            NextDialogue();
        }



    }




    void NextDialogue()
    {
        if(index < currentDialogue.dialogue.Length)
        {
            textRef.text = currentDialogue.dialogue[index];
        }
        else if (!isChoice)
        {
            index--;
            ChoiceSetup();
        }
        else
        {
            index--;
        }


    }

    void ChoiceSetup()
    {
        isChoice = true;
        choiceBox.SetActive(true);
        // foreach (DialogueObject x in currentDialogue.choices)
        for (int i = 0; i < currentDialogue.choices.Length; i++)
        {
            
            choiceButtons[i].SetActive(true);
            choiceButtons[i].GetComponentInChildren<Text>().text = currentDialogue.choices[i].choiceName;
            



        }
    }

    public void ChoiceSelect(int x)
    {
        currentDialogue = currentDialogue.choices[x];
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActive(false);

        }
        choiceBox.SetActive(false);
        index = 0;
        isChoice = false;
        NextDialogue();

    }


}
