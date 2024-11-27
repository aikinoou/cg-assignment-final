using UnityEngine;

public class CollisionDialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueManager.StartDialogue();
            
            Destroy(gameObject);
        }
    }
}
