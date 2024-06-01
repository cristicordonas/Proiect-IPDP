using UnityEngine;
using UnityEngine.SceneManagement; // reincarca o scena in cazul nostru, dupa ce murim

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public static bool isDead = false;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource respawnSound;
    [SerializeField] private AudioSource backgroundSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        deathSound.Play();
        rb.bodyType = RigidbodyType2D.Static; // stop player from moving, convert from dynamic to static
        anim.SetTrigger("death");
        backgroundSound.Stop(); // stop the background sound when player dies

    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the scene
    }
    private void RespawnSound()
    {
        respawnSound.Play();
    }
}