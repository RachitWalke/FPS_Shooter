using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerHealth = 100.0f;
    public HealthBar healthbar;

    public AudioSource audiosrc;
    public AudioClip clip;

    private void Start()
    {
        healthbar.setMaxHealth(playerHealth);
        audiosrc = GetComponent<AudioSource>();
    }
    public void PlayerTakeDamage(float damage)
    {
        playerHealth -= damage;
        healthbar.setHealth(playerHealth);
        audiosrc.PlayOneShot(clip);

        if (playerHealth <= 0)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
