using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexcidecimalConverter : MonoBehaviour
{
    public int input = 0;
    public Dictionary<int, string> convertString = new Dictionary<int, string>() { { 0, "0" }, { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" }, { 10, "A" }, { 11, "B" }, { 12, "C" }, { 13, "D" }, { 14, "E" }, {15, "F"}};  
    
    int x;

    private void Start()
    {
        
        HexidecimalConvert(input,0);
    }
    
    
    public void HexidecimalConvert(int value, int digit)
    {
        
        if (digit > 0)
        {
            x = value / 16;
        }
        else
        {
            x = value;
        }

 
    }

    void CheckIfDone(int digit, int value)
    {
        if (digit > 0)
        {
            HexidecimalConvert(value % 16, digit - 1);
        }
    }
}

/* switch (Mathf.Abs(x))
{
    case 0:
        // 0
        print("0");
        CheckIfDone(digit, value);
        break;
    case 1:
        // 1
        print("1");

        CheckIfDone(digit, value);
        break;

    case 2:
        // 2
        print("2");
        CheckIfDone(digit, value);
        break;
    case 3:
        // 3
        print("3");
        CheckIfDone(digit, value);
        break;
    case 4:
        // 4
        print("4");
        CheckIfDone(digit, value);
        break;
    case 5:
        // 5
        print("5");
        CheckIfDone(digit, value);
        break;
    case 6:
        // 6
        print("6");
        CheckIfDone(digit, value);
        break;
    case 7:
        // 7
        print("7");
        CheckIfDone(digit, value);
        break;
    case 8:
        // 8
        print("8");
        CheckIfDone(digit, value);
        break;
    case 9:
        // 9
        print("9");
        CheckIfDone(digit, value);
        break;
    case 10:
        // A
        print("A");
        CheckIfDone(digit, value);
        break;
    case 11:
        // B
        print("B");
        CheckIfDone(digit, value);
        break;
    case 12:
        // C
        print("C");
        CheckIfDone(digit, value);
        break;
    case 13:
        // D
        print("D");
        CheckIfDone(digit, value);
        break;
    case 14:
        // E
        print("E");
        CheckIfDone(digit, value);
        break;
    case 15:
        // F
        print("F");
        CheckIfDone(digit, value);
        break;
    default:
        HexidecimalConvert(value, digit + 1);


        break;

}

*/





