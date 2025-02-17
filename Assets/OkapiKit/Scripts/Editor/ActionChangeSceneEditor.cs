using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActionChangeScene))]
public class ActionChangeSceneEditor : ActionEditor
{
    SerializedProperty propSceneName;

    protected override void OnEnable()
    {
        base.OnEnable();

        propSceneName = serializedObject.FindProperty("sceneName");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (WriteTitle())
        {
            StdEditor(false);

            var action = (target as ActionChangeScene);
            if (action == null) return;

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(propSceneName, new GUIContent("Scene"));

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                (target as Action).UpdateExplanation();
            }
        }
    }
}
