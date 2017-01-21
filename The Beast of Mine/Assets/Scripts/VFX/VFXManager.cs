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
    // the current prefab transform used
    public Transform currentEffect;
    // the user-friendly name of the current prefab used
    private string currentEffectName;

    /**
     * Load the default background when we launch the scene
     */
    void Start () {
        loadDefaultEffect();
	}

    /**
     * Load a new effect into the scene
     */
    public void loadEffect(string prefabName)
    {
        if(currentEffect)
        {
            Destroy(currentEffect.gameObject);
        }
        currentEffect = (Transform) Instantiate((UnityEngine.Object)getPrefab(prefabName));
        currentEffectName = prefabName;
    }

    public void loadDefaultEffect()
    {
        loadEffect(defaultPrefab);
    }

    /**
     * Given a prefabName :
     *  - if the prefab name is not empty or if the current prefab is not the default prefab, then we load a new effect accordingly
     */
    public void handleEffect(string prefabName)
    {
        if(prefabName != "")
        {
            if(currentEffectName != prefabName)
            {
                loadEffect(prefabName);
            }
        } else if(currentEffectName != defaultPrefab)
        {
            loadDefaultEffect();
        }
    }

    /**
     * Utility to easily get a prefab transform based on a prefab name
     */
    private Transform getPrefab(string prefabName)
    {
        if (!prefabNames.Contains(prefabName))
        {
            throw new Exception("Error, the prefab name" + prefabName + " is not is the array of prefabNames. Check the array on the game manager object, in the VXFManager section.");
        }
        var prefabIndex = prefabNames.IndexOf(prefabName);
        if (prefabIndex > prefabTransforms.Count)
        {
            throw new Exception("Error, there is no element at index " + prefabIndex + " in the array of prefabTransforms. Check the array on the game manager object, in the VXFManager section.");
        }
        return prefabTransforms[prefabIndex];
    }
}
