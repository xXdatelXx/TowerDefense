using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Switch(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void SwitchNext()
    {
        Switch(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Switch(SceneManager.GetActiveScene().buildIndex);
    }
}
