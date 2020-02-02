using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameRunning = true;

    public static void EndGame()
    {
        GameRunning = false;
    }
}
