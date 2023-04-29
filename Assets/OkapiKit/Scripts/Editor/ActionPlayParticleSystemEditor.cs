using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActionPlayParticleSystem))]
public class ActionPlayParticleSystemEditor : ActionEditor
{
    SerializedProperty propTarget;
    SerializedProperty propState;

    protected override void OnEnable()
    {
        base.OnEnable();

        propTarget = serializedObject.FindProperty("target");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (WriteTitle())
        {
            StdEditor(false);

            var action = (target as ActionPlayParticleSystem);
            if (action == null) return;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(propTarget, new GUIContent("Particle System"));

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                (target as Action).UpdateExplanation();
            }
        }
    }
}
