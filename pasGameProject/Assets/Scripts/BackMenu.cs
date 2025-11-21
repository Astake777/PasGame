using UnityEngine;

public class BackMenu : MonoBehaviour
{
    public void Menu()
    //method untuk kembali ke scene menu utama
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
