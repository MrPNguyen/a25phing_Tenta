using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractEvent : MonoBehaviour
{
    public GameObject interactText;
    public bool isInRange;
    public UnityEvent interactAction;

    public void Interact(InputAction.CallbackContext context)
    {
        if (isInRange)
        {
            interactText.SetActive(true);
            if (context.performed)
            {
                interactAction.Invoke();
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
