using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUFINAL : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(1); 

    }

    public void Quit()
    {
       Debug.Log("Quit!!!!!");
       Application.Quit();

    }
}
