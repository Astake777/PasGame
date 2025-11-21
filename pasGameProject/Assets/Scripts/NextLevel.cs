using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        // Memanggil function NextLevel() dari SceneController
        SceneController.instance.NextLevel();
    }
}
