using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadScene(string which)
    {
        SceneManager.LoadScene(which);
    }

    public void Quit()
    {
        Application.Quit();
    }
}