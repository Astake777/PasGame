using UnityEngine;

public class Flag : MonoBehaviour
{
    // UI yang muncul atau aktif ketika pemain mencapai bendera
    public GameObject winUI;

    // Dipanggil ketika objek lain memasuki trigger bendera
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah yang menyentuh adalah objek ber tag kan Player
        if (collision.gameObject.tag == "Player")
        {
            // Ambil script PlayerWalk dari player
            PlayerWalk player = collision.gameObject.GetComponent<PlayerWalk>();

            // Pastikan game berjalan normal (tidak ter-pause)
            Time.timeScale = 1;

            // Tampilkan UI kemenangan
            winUI.SetActive(true);

            // Lepaskan kamera dari player agar kamera tidak ikut dihancurkan
            Camera.main.transform.SetParent(null);

            // Hancurkan player setelah menyentuh bendera
            Destroy(collision.gameObject);
        }
    }
}
