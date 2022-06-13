using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDialogue", menuName = "Dialogue")]
public class DialogueObject : ScriptableObject
{
    public string choiceName;
    public string[] dialogue;
    public Color[] colorDialogue;

    public DialogueObject[] choices;








}
