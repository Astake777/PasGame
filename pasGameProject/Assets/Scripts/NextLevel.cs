using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneController.instance.NextLevel();
    }
}
