using UnityEngine;
using System.Collections;

public class LoadChoices : MonoBehaviour
{

    public Choices TargetChoicesNoAction, TargetChoicesWithAction;
    public string ActionName;

    public void OpenChoices()
    {
        if (ActionName != "")
        {
        
            if (PlayerPrefs.GetInt(ActionName) == 1)
            {

                TargetChoicesWithAction.enabled = true;
                

            }
            else {

                TargetChoicesNoAction.enabled = true;
            }
        }
        else
        {
            TargetChoicesNoAction.enabled = true;
        }
    }
}