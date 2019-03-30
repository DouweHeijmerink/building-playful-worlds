using UnityEngine;
using UnityEngine.SceneManagement;


//Loads the next level. This script is used at the end of the end level animation.
public class LevelComplete : MonoBehaviour {

    public void LoadNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
    }
}
