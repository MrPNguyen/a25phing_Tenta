using System;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioSource audioSource;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Debug.Log("Hit");
            gameObject.SetActive(false);
            scoreManager.AddPoint();
        }
    }
}
