using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Class for transitioning between scenes
 */
public class TransitionManager : MonoBehaviour
{
    /*
     * Transitions to the MainScene
     */
    public static void ToMainScene()
    {
        Gem.totalscore = 0; //reset score
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    /*
     * Transitions to the EndScene
     */
    public static void ToEndScene()
    {
        SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
    }

    /*
     * Quits the game
     */
    public static void QuitGame()
    {
        Application.Quit();
    }
}
