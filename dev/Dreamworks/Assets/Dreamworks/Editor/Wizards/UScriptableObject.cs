/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Utility;

namespace DreamMachineGameStudio.Dreamworks.Editor
{
    /// <summary>
    /// 
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/24/2019</CreationDate>
    public class UScriptableObject : EditorWindow
    {
        #region Field
        private int selectedIndex;
        private string[] scriptableObjectNames;
        private IEnumerable<Type> scriptableObjectTypes;

        private const string POPUP_LABLE_NAME = "Scriptable Objects";
        private const string CREATE_BUTTON_NAME = "Create";
        #endregion

        #region Static Methods
        [MenuItem(itemName: "Assets/Create/ScriptableObject", priority = 100)]
        private static void OpenWizardWindow()
        {
            UScriptableObject window = GetWindow<UScriptableObject>(false, "Scriptable Object Wizard");
            window.maxSize = window.minSize = new Vector2(400, 40);
            window.Show();
        }
        #endregion

        #region EditorWindow Methods
        private void OnEnable()
        {
            scriptableObjectTypes = FReflectionUtility.GetSubTypesOf<SScriptableObject>().Where(x => FReflectionUtility.HasDefinedAttribute(x, typeof(AScriptableObjectWizard)));

            scriptableObjectNames = scriptableObjectTypes.Select(row => row.Name).ToArray();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            selectedIndex = EditorGUILayout.Popup(POPUP_LABLE_NAME, selectedIndex, scriptableObjectNames);

            if (GUILayout.Button(CREATE_BUTTON_NAME))
            {

                string path = AssetDatabase.GetAssetPath(Selection.activeObject);

                ScriptableObject asset = CreateInstance(scriptableObjectTypes.ElementAt(selectedIndex));

                ProjectWindowUtil.CreateAsset(asset, $"{path}/{scriptableObjectTypes.ElementAt(selectedIndex).Name}.asset");

                Close();
            }

            EditorGUILayout.EndVertical();
        }
        #endregion
    }
}