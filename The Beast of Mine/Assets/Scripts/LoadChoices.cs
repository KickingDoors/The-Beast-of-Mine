using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class LoadChoices : MonoBehaviour
{

    public Choices TargetChoicesNoAction, TargetChoicesWithAction;
    public string ActionName;
    private string jsonString;
    private JsonData ActionData;

    public void OpenChoices()
    {
        if (ActionName != "")
        {

            jsonString = File.ReadAllText(Application.dataPath + "/Resources/ActionTracker.json");
            ActionData = JsonMapper.ToObject(jsonString);

        
            if (ActionData[ActionName].ToString() == "true")
            {

                TargetChoicesNoAction.enabled = true;

            }
            else {

                TargetChoicesWithAction.enabled = true;
            }
        }
        else
        {
            TargetChoicesNoAction.enabled = true;
        }
    }
}