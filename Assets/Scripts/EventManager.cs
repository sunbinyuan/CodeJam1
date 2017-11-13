using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

    public delegate void WinGameDelegate();
    public static WinGameDelegate onWinGame;

    public delegate void LoseGameDelegate();
    public static LoseGameDelegate onLoseGame;

    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;

    public delegate void PositionChangeDelegate(Vector3 position);
    public static PositionChangeDelegate onPositionChange;

    public static bool GameActive;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public static void UpdatePlayerPosition(Vector3 position)
    {
        onPositionChange(position);
    }

    public static void WinGame()
    {
        Debug.Log("Game Won!");
        GameActive = false;
        if (onWinGame != null)
        {

            onWinGame();
        }
    }

    public static void StartGame()
    {
        Debug.Log("Game started");
        GameActive = true;
        if (onStartGame != null)
        {
            onStartGame();
        }
    }

    public static void LoseGame()
    {
        if (!GameActive)
        {
            return;
        }
        Debug.Log("Game lost");
        GameActive = false;
        if (onStartGame != null)
        {
            onLoseGame();
        }
    }

}
