using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    private static readonly int Transition = Animator.StringToHash("Transition");
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void ChangeScene(int index)
    {
        animator.SetTrigger(Transition);
        
        GameManager.Instance.sceneIndex = index;
    }
    
    public void TriggerLevelChange()
    {
        GameManager.Instance.OnTransitionComplete();
    }
}
