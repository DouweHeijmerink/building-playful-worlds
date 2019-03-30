using UnityEngine;


//Makes the 'quit' button at the end of the game work.
public class Credits : MonoBehaviour
{
    public void Quit ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
