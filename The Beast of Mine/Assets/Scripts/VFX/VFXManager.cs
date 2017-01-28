using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handle the VFX backgrounds in the game
 */
public class VFXManager : MonoBehaviour{

    // list of user-friendly name of the prefabs
    public List<string> prefabNames;
    // list of the transforms
    public List<Transform> prefabTransforms;
    // the default user-friendly prefab name
    public string defaultPrefab;
    // the user-friendly name of the current prefab used
    private string currentEffectName;
    private List<Transform> instantiedPrefabTransforms = new List<Transform>();

    void Awake()
    {
        loadAllEffects();
    }

    /**
     * Loads all effects into the scene for CPU performance
     */
    private void loadAllEffects()
    {
        Transform vfx;
        String vfxName;
        int prefabTransformsLength = prefabTransforms.Count;

        for (var i = 0; i < prefabTransformsLength; i++)
        {
            vfxName = prefabNames[i];
            // instantiate the vfx
            vfx = (Transform)Instantiate((UnityEngine.Object)prefabTransforms[i]);
            vfx.gameObject.name = vfxName;
            if (vfxName == defaultPrefab) // default prefab
            {
                vfx.gameObject.SetActive(true);
                currentEffectName = vfxName;
            }
            else // other prefabs
            {
                vfx.gameObject.SetActive(false);
            }
            instantiedPrefabTransforms.Add(vfx);
        }
    }

    /**
     * Change the currently displayed effect
     */
    public void changeEffect(string prefabName)
    {
        // deactivate current effect
        int currentEffectIndex = instantiedPrefabTransforms.IndexOf(getInstantiatedPrefab(currentEffectName));
        instantiedPrefabTransforms[currentEffectIndex].gameObject.SetActive(false);
        // activate next effect and save it as the new current effect
        int nextEffectIndex = instantiedPrefabTransforms.IndexOf(getInstantiatedPrefab(prefabName));
        instantiedPrefabTransforms[nextEffectIndex].gameObject.SetActive(true);
        currentEffectName = prefabName;
    }

    /**
     * Given a prefabName :
     *  - if the prefab name is not empty or if the current prefab is not the default prefab, then we change the effect accordingly
     */
    public void handleEffect(string prefabName)
    {
        if(prefabName != "") // if we have a specific effect
        {
            if(currentEffectName != prefabName) // if the specific effect is not already the current effect
            {
                changeEffect(prefabName);
            }
        } else if(currentEffectName != defaultPrefab) // else if the current effect is not the default one
        {
            // change current effect to the default one
            changeEffect(defaultPrefab);
        }
    }

    /**
     * Utility to easily get an instantiated prefab transform based on a prefab name
     */
    private Transform getInstantiatedPrefab(string prefabName)
    {
        var prefabIndex = prefabNames.IndexOf(prefabName);
        return instantiedPrefabTransforms[prefabIndex];
    }
}
