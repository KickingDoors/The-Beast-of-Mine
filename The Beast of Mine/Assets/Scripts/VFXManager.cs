using System;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour{

    public List<string> prefabNames;
    public List<Transform> prefabTransforms;
    public string defaultPrefab;
    private Transform currentEffect;
    private string currentEffectName;

    void Start () {
        loadDefaultEffect();
	}

    private Transform getPrefab(string prefabName)
    {
        return prefabTransforms[prefabNames.IndexOf(prefabName)];
    }
    public void loadEffect(string prefabName)
    {
        Debug.Log("###### Called load effect");
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

    public void handleEffect(string prefabName)
    {
        if(prefabName != "")
        {
            //Debug.Log("1: " + currentEffect.transform + " vs " + prefabs[prefabName].name);
            if(currentEffectName != prefabName)
            {
                loadEffect(prefabName);
            }
        } else if(currentEffectName != defaultPrefab)
        {
            //Debug.Log("2: " + currentEffect.name + " vs " + defaultPrefab);
            loadDefaultEffect();
        }
    }
}
