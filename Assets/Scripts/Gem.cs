using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for allowing the Gem to be collected and add to the total score
 */
public class Gem : MonoBehaviour
{
    [SerializeField]
    private int value = 1; //how much the gem adds to the score when collected
    public static int totalscore = 0; //globally accessable variable for score
  
    /*
     * Called when gem is collected (touched by player)
     */
    public void Collect()
    {
        IncrementScore(value);
        Debug.Log("Collecting " + name + " Total score is now: " + totalscore);
        Destroy(gameObject);
    }

    /*
     * Adds amount to total score 
     */
    private void IncrementScore(int amount)
    {
        totalscore += amount;
    }
}
