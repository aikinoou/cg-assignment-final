using DialogueEditor;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private NPCConversation[] npcConversations;
    
    private int dialogueIndex;

    private void Start()
    {
        int accepts = GameManager.Instance.acceptCount;
        int cuts = GameManager.Instance.cutCount;
        
        UpdateDialogue(accepts, cuts);
    }
    
    public void StartDialogue()
    {
        player.EnterDialogue();
        
        ConversationManager.Instance.StartConversation(npcConversations[dialogueIndex]);
    }

    public void EndDialogue()
    {
        player.ExitDialogue();
    }

    public void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResetGame()
    {
        GameManager.Instance.acceptCount = 0;
        GameManager.Instance.cutCount = 0;
    }

    public void PlayerChoice(bool accepted)
    {
        if (accepted)
            GameManager.Instance.acceptCount++;
        else
            GameManager.Instance.cutCount++;
    }

    private void UpdateDialogue(int accepts, int cuts)
    {
        if (accepts == 0 && cuts == 0) dialogueIndex = 0;
        if (accepts == 1) dialogueIndex = 1;
        if (cuts == 1) dialogueIndex = 2;
        if (accepts == 2) dialogueIndex = 3;
        if (cuts == 2) dialogueIndex = 4;
        if (accepts == 1 && cuts == 1) dialogueIndex = 5;
        if (accepts == 3) dialogueIndex = 6;
        if (cuts == 3) dialogueIndex = 7;
        if (accepts == 1 && cuts == 2) dialogueIndex = 8;
        if (accepts == 2 && cuts == 1) dialogueIndex = 9;
    }
}
