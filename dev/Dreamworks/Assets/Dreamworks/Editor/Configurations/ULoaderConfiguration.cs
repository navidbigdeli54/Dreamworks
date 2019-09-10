/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

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
        private SerializedProperty startupClass;
        private SerializedProperty dontLoadFramework;

        private IEnumerable<Type> startupSubClasses;
        private string[] startupSubClassesNames;

        private int selectedIndex = 0;

        private bool foldout = true;

        private readonly string SAVE_BUTTON_LABLE = "Save";
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
            startupSubClasses = FReflectionUtility.GetSubTypesOf<SStartup>();
            startupSubClassesNames = startupSubClasses?.Select(x => x.FullName).ToArray();

            dontLoadFramework = serializedObject.FindProperty("dontLoadFramework");

            startupClass = serializedObject.FindProperty("startupClass");
            selectedIndex = Array.IndexOf(startupSubClassesNames, startupClass.stringValue);
        }

        public override void OnInspectorGUI()
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, target);

            if (foldout)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);

                EditorGUILayout.PropertyField(dontLoadFramework);

                selectedIndex = EditorGUILayout.Popup(startupClass.displayName, selectedIndex, startupSubClassesNames);

                EditorGUILayout.Space();

                if (GUILayout.Button(SAVE_BUTTON_LABLE, GUILayout.Height(20)))
                {
                    startupClass.stringValue = startupSubClassesNames[selectedIndex];

                    serializedObject.ApplyModifiedProperties();
                }

                EditorGUILayout.EndVertical();
            }

        }
        #endregion
    }
}