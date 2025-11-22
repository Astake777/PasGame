using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public AudioClip coinClip;
    // UI teks tempat menampilkan jumlah coin
    private TextMeshProUGUI coinText;

    private void Start()
    {
        // cari UI yang memiliki tag "CoinText"
        // lalu ambil komponen TextMeshProUGUI-nya
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // jika objek yang menabrak coin adalah objek dengan tag Player
        if (collision.gameObject.tag == "Player")
        {
            // ambil script PlayerWalk dari player
            PlayerWalk player = collision.gameObject.GetComponent<PlayerWalk>();

            // tambahkan jumlah coin milik player sebanyak 1
            player.coins += 1;

            player.PlaySFX(coinClip);

            // update teks UI agar menampilkan total coin terbaru
            coinText.text = player.coins.ToString();

            // coin dihancurkan setelah diambil
            Destroy(gameObject);
        }
    }
}
