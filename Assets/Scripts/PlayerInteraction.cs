using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float playerReach = 3f;
    private Interactable currentInteractable;
    private Camera m_camera;
    [HideInInspector] public bool canInteract = true;
    
    private void Start()
    {
        m_camera = Camera.main;
    }

    private void Update()
    {
        CheckInteraction();

        if (!canInteract) return;
        
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
    
    private void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(m_camera.transform.position, m_camera.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach) && canInteract)
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                    DisableCurrentInteractable();
            }
            else
                DisableCurrentInteractable();
        }
        else
            DisableCurrentInteractable();
    }

    private void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        
        UIManager.instance.EnableInteractText(currentInteractable.message);
    }

    private void DisableCurrentInteractable()
    {
        UIManager.instance.DisableInteractText();
        
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
