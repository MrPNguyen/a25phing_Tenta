using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Animator DoorOpen;
    private AudioSource audioSource;
    [SerializeField] private PlayerManager playerManager;
    public bool InRange;
    [SerializeField] private GameObject InteractKey;
    [SerializeField] private GameObject InteractText;
    [SerializeField] private GameObject OpenDoorObject;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (InRange)
        {
            InteractText.SetActive(true);
            InteractKey.SetActive(true);
        }
        else
        {
            InteractText.SetActive(false);
            InteractKey.SetActive(false);
        }
    }

    public void OpenDoor(InputAction.CallbackContext context)
    {
        if (InRange)
        {
            if (context.performed && playerManager.KeyCount > 0)
            {
                audioSource.Play();
                DoorOpen.SetBool("isOpen", true);
                OpenDoorObject.SetActive(true);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange = false;
        }
    }
    
}
