using UnityEngine;
using DialogueEditor;

public class DialogueInteract : MonoBehaviour
{
    [SerializeField] private NPCConversation npcConversation;
    [SerializeField] private PlayerController player;

    public void EnterDialogue()
    {
        player.EnterDialogue();
        ConversationManager.Instance.StartConversation(npcConversation);
    }
}
