using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    //method untuk merestart ulang game dengan cara memuat ulang scene Level1
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
}
