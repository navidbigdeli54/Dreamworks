/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;

using UEditor = UnityEditor.Editor;
using DreamMachineGameStudio.Dreamworks.Utility;

namespace DreamMachineGameStudio.Dreamworks.Editor
{
    [CustomEditor(typeof(SFrameworkConfiguration))]
    public class ULoaderConfiguration : UEditor
    {
        #region Field
        private SerializedProperty startupClassProperty;
        private SerializedProperty dontLoadFrameworkProperty;

        private bool foldout = true;
        #endregion

        #region Static Methods
        [MenuItem(itemName: "DreamMachineGameStudio/DreamWork/Configuration")]
        private static void OpenConfigurationFile()
        {
            Selection.activeObject = Resources.Load(nameof(SFrameworkConfiguration));
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