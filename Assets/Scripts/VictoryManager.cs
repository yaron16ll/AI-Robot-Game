using System.Collections.Generic;
using UnityEngine;
 
public class VictoryManager : MonoBehaviour
{
    private static int whiteRobotAmount = 0;
    private static int blackRobotAmount = 0;
    public static GameObject text;


    public static int GetWhiteRobotAmount()
    {

        return whiteRobotAmount;

    }
    public static int GetBlackRobotAmount()
    {
        return blackRobotAmount;

    }

    public static void IncrementWhiteRobot(GameObject text)
    {

        whiteRobotAmount++;
        if (whiteRobotAmount == 3)
        {
            text.GetComponent<TextMesh>().color = Color.black;
            text.GetComponent<TextMesh>().text = "The Black Robots have won!";
            text.SetActive(true);
        }
    }
    public static void IncrementBlackRobot(GameObject text)
    {
        blackRobotAmount++;
        if (blackRobotAmount == 3)
        {
            text.GetComponent<TextMesh>().color = Color.white;
            text.GetComponent<TextMesh>().text = "The White Robots have won!";
            text.SetActive(true);
        }

    }
}
