using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Animator anim;
    public Text scoreText; // Referenz auf die UI-Textkomponente
    private int score = 0;
    public GameObject RestartButton;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Spieler wird deaktiviert
            anim.SetTrigger("Tot");
            Invoke("Stirbt", 2f);
        }
        else if (other.CompareTag("Collect"))
        {
            // Objekt mit dem Tag "Collect" wurde getroffen
            CollectObject(other.gameObject);
        }
    }

    void Stirbt()
    {
        gameObject.SetActive(false);
        RestartButton.SetActive(true);
    }

    void CollectObject(GameObject collectible)
    {
        // Sammle Punkte und deaktiviere das gesammelte Objekt
        score += 10;
        UpdateScoreUI();

        collectible.SetActive(false);
    }

    void UpdateScoreUI()
    {
        // Aktualisiere die UI-Anzeige der Punkte
        if (scoreText != null)
        {
            scoreText.text = "Punkte: " + score.ToString();
        }
    }
}