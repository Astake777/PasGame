using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
} 
