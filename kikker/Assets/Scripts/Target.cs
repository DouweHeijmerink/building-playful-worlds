using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject completeLevelUI;

    public void TakeDamage (float amount)
    {

        //Finishes the level whenever a target's health get below zero.
        health -= amount;
        if (health <= 0f)
        {
            CompleteLevel();
        }
    }

    //Plays the end level animation, the actual transition to the new scene happens at the end of the animation.
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
