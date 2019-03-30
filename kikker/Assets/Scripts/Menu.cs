using UnityEngine;
using UnityEngine.SceneManagement;


//Opens a new scene when pressing the 'start game' button.
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
