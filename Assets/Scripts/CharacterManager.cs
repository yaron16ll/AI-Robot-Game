using UnityEngine;

public enum CharacterTypes
{
    Aggressive,
    Careful
}

public class CharacterManager : MonoBehaviour
{
    private static bool isCarefulTaken = false;
    private static int whiteAggressiveCount = 0;
    private static int blackAggressiveCount = 0;

    public static CharacterTypes ChooseCharacter(string tag)
    {
        ref int aggressiveCount = ref (tag == "WhiteRobot") ? ref whiteAggressiveCount : ref blackAggressiveCount;

        if (Random.Range(0, 2) == 0 && !isCarefulTaken)
        {
            isCarefulTaken = true;
            return CharacterTypes.Careful;
        }

        aggressiveCount++;
        if (aggressiveCount == 3)
        {
            return CharacterTypes.Careful;
        }

        return CharacterTypes.Aggressive;
    }
}
