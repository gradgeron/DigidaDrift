using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Gaming()
    {
        SceneManager.LoadScene(1);
    }
}
