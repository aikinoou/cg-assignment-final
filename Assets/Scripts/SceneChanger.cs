using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public enum EndingType
    {
        Default,
        OneAccept,
        TwoAccepts,
        ThreeAccepts,
        OneCut,
        TwoCuts,
        ThreeCuts,
        OneAcceptOneCut,
        TwoAcceptsOneCut,
        OneAcceptTwoCuts
    }
    
    [SerializeField] private GameObject[] scenes;

    private Dictionary<EndingType, GameObject> sceneDictionary;

    private void Start()
    {
        int accepts = GameManager.Instance.acceptCount;
        int cuts = GameManager.Instance.cutCount;
        
        CreateSceneDictionary();
        UpdateScene(accepts, cuts);
    }

    private void UpdateScene(int accepts, int cuts)
    {
        DisableAllScenes();
        EndingType ending = GetEndingType(accepts, cuts);
        
        if (sceneDictionary.ContainsKey(ending))
            sceneDictionary[ending].SetActive(true);
    }

    private void CreateSceneDictionary()
    {
        sceneDictionary = new Dictionary<EndingType, GameObject>
        {
            { EndingType.Default, scenes[0] },
            { EndingType.OneAccept, scenes[1] },
            { EndingType.OneCut, scenes[2] },
            { EndingType.TwoAccepts, scenes[3] },
            { EndingType.TwoCuts, scenes[4] },
            { EndingType.OneAcceptOneCut, scenes[5] },
            { EndingType.ThreeAccepts, scenes[6] },
            { EndingType.ThreeCuts, scenes[7] },
            { EndingType.OneAcceptTwoCuts, scenes[8] },
            { EndingType.TwoAcceptsOneCut, scenes[9] }
        };
    }

    private EndingType GetEndingType(int accepts, int cuts)
    {
        if (accepts == 1 && cuts == 1) return EndingType.OneAcceptOneCut;
        if (accepts == 1 && cuts == 2) return EndingType.OneAcceptTwoCuts;
        if (accepts == 2 && cuts == 1) return EndingType.TwoAcceptsOneCut;
        if (accepts == 3) return EndingType.ThreeAccepts;
        if (accepts == 2) return EndingType.TwoAccepts;
        if (accepts == 1) return EndingType.OneAccept;
        if (cuts == 1) return EndingType.OneCut;
        if (cuts == 2) return EndingType.TwoCuts;
        if (cuts == 3) return EndingType.ThreeCuts;
        
        return EndingType.Default;
    }

    private void DisableAllScenes()
    {
        foreach (var scene in scenes)
        {
            if (scene != null)
                scene.SetActive(false);
        }
    }
}
