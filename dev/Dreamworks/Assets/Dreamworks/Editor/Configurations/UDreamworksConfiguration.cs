/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using UnityEditor;
using DreamMachineGameStudio.Dreamworks.Core;

using UEditor = UnityEditor.Editor;

namespace DreamMachineGameStudio.Dreamworks.Editor
{
    [CustomEditor(typeof(SDreamworksConfiguration))]
    public class UDreamworksConfiguration : UEditor
    {
        #region Field
        private SerializedProperty startupClassProperty;
        private SerializedProperty dontLoadFrameworkProperty;

        private bool foldout = true;
        #endregion

        #region Static Methods
        [MenuItem(itemName: "DreamMachineGameStudio/DreamWork/Configuration", priority = 0)]
        private static void OpenConfigurationFile()
        {
            Selection.activeObject = Resources.Load(nameof(SDreamworksConfiguration));
        }
        #endregion

        #region Method
        private void OnEnable()
        {
            dontLoadFrameworkProperty = serializedObject.FindProperty("dontLoadFramework");

            startupClassProperty = serializedObject.FindProperty("startupClass");
        }

        public override void OnInspectorGUI()
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, target);

            if (foldout)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);

                EditorGUILayout.PropertyField(dontLoadFrameworkProperty);

                EditorGUILayout.PropertyField(startupClassProperty);

                serializedObject.ApplyModifiedProperties();

                EditorGUILayout.EndVertical();
            }
        }
        #endregion
    }
}