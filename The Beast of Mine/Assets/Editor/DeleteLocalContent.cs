using UnityEngine;
using UnityEditor;

class DeleteLocalContent : EditorWindow{

	[MenuItem("Content/Content Manager")]

	public static void  ShowMenu(){

		EditorWindow.GetWindow (typeof(DeleteLocalContent));
	}

    public void OnGUI()
    {
		if(GUILayout.Button("Delete Local Content"))
		{
			PlayerPrefs.DeleteAll ();
		}
    }
}