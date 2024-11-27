using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TogglePostProcessing : MonoBehaviour
{
    public PostProcessVolume[] postProcessVolumes; //array of all the post processing
    private bool isPostProcessingActive = true;    //is post processing enabled or not

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) //press 2 to turn off post processing
        {
            TogglePostProcessingEffects();
        }
    }

    public void TogglePostProcessingEffects()
    {
        isPostProcessingActive = !isPostProcessingActive; //toggles the state
        
        foreach (PostProcessVolume volume in postProcessVolumes) //goes through all of them and switches them off
        {
            if (volume != null) //check if volume is valid
            {
                volume.enabled = isPostProcessingActive;
            }
        }
    }
}