using UnityEngine;
using System.Collections.Generic;

public class ToggleMaterials : MonoBehaviour
{
    private bool materialsDisabled = false; //sees if materials are enabled or disabled
    private Dictionary<Renderer, Material[]> originalMaterials = new Dictionary<Renderer, Material[]>(); //stores original materials for all renderers

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //press 1 to toggle materials
        {
            ToggleMaterialsState();
        }
    }

    void ToggleMaterialsState()
    {
        //finds all renderer components in the scene
        Renderer[] renderers = FindObjectsOfType<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            if (renderer != null)
            {
                if (materialsDisabled)
                {
                    //restores original materials if they were saved
                    if (originalMaterials.ContainsKey(renderer))
                    {
                        renderer.materials = originalMaterials[renderer];
                    }
                }
                else
                {
                    //saves the original materials to come back later
                    if (!originalMaterials.ContainsKey(renderer))
                    {
                        originalMaterials[renderer] = renderer.materials;
                    }

                    //replace materials with a flat gray standard Shader material
                    Material[] litMaterials = new Material[renderer.materials.Length];
                    for (int i = 0; i < litMaterials.Length; i++)
                    {
                        litMaterials[i] = new Material(Shader.Find("Standard"))
                        {
                            color = Color.gray //default nothing color
                        };
                    }
                    renderer.materials = litMaterials;
                }
            }
        }
        materialsDisabled = !materialsDisabled; //toggles state
    }
}
