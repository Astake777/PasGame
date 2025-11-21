using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Menyimpan instance tunggal SceneController (Singleton)
    public static SceneController instance;

    private void Awake()
    {
        // Jika belum ada instance...
        if (instance == null)
        {
            // Jadikan object ini sebagai instance utama
            instance = this;

            // Jangan hancurkan object ini ketika pindah scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika sudah ada instance lain, hancurkan object ini
            // Tujuannya agar hanya ada satu SceneController
            Destroy(gameObject);

            // Menghentikan eksekusi sisa kode
            return;
        }
    }

    public void NextLevel()
    {
        // Mendapatkan index scene aktif, lalu memuat index berikutnya
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
