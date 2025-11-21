using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    // fungsi ini terpanggil otomatis saat GameObject bersentuhan (collision) dengan collider lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mengecek apakah objek yang ditabrak memiliki tag "Damage"
        if (collision.gameObject.tag == "Damage")
        {
            //  jika benar, maka reload scene yang sedang aktif (restart level)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
