using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int livesNum = 3;
    public bool ifPlay = true;
    public bool ifWin = false;
    public Text livesText;
    public Text degreesText;
    public Text powerText;
    public Text resultText;
    public Text continueText;    

    public void SubtractLives()
    {
        livesNum = livesNum - 1;
        livesText.text = "Lives: " + livesNum.ToString();
        if (livesNum < 1)
        {
            ifPlay = false;
        }
    }
    public void UpdateDegrees(int degree)
    {
        degreesText.text = "Degrees: " + degree.ToString();
    }
    public void UpdatePower(float power)
    {
        powerText.text = "Power: " + power.ToString();
    }
    public void UpdateResult(string result, string instruct)
    {
        resultText.text = result;
        continueText.text = "\t\t\t\t" + instruct;
    }
}
