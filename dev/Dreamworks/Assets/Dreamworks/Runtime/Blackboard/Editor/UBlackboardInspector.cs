/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Utility;

namespace DreamMachineGameStudio.Dreamworks.Blackboard.Editor
{
    [CustomEditor(typeof(SBlackboard))]
    public class UBlackboardInspector : UnityEditor.Editor
    {
        #region Fields
        private const string VALUE = "value";
        private const string BLACKBOARD = "blackboard";
        private const string ADD = "Add";
        private const string SAVE = "Save";
        private const string NAME = "Name";
        private const string DELETE = "Delete";
        private const string IS_READONLY = "IsReadOnly";
        private const string TYPE_SEARCH_CONSTRAINT = "t:";

        private readonly GUILayoutOption LABLE_WIDTH = GUILayout.Width(50);

        private List<FValue> values;

        private Type[] valueTypes;
        private string[] valueTypeNames;

        private int selectedValueType;

        private bool foldout = true;

        private string searchTerm;
        private GenericMenu searchFilterGenericMenu;
        #endregion

        #region Editor Methods
        private void OnEnable()
        {
            FillValues();

            FillValueTypes();

            FillSearchFilterGenericMenu();
        }

        public override void OnInspectorGUI()
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, target);

            if (foldout)
            {
                SearchGUI();

                ValuesGUI();

                AddButtonGUI();

                SaveButtonGUI();
            }
        }
        #endregion

        #region Private Methods
        private void FillValues()
        {
            FieldInfo fieldInfo = FReflectionUtility.GetField(serializedObject.targetObject, BLACKBOARD);
            Dictionary<string, SValue> blackboard = (Dictionary<string, SValue>)fieldInfo.GetValue(serializedObject.targetObject);

            values = new List<FValue>(blackboard.Count);

            foreach (var item in blackboard)
            {
                values.Add(new FValue(item.Value));
            }
        }

        private void FillValueTypes()
        {
            valueTypes = FReflectionUtility.GetSubTypesOf<SValue>().Where(x => x.IsGenericType == false).ToArray();

            valueTypeNames = valueTypes.Select(x => FReflectionUtility.GetAttributeProperty<string>(x, AName.CLASS_TYPE, NAME)).ToArray();
        }

        private void FillSearchFilterGenericMenu()
        {
            searchFilterGenericMenu = new GenericMenu();

            for (int i = 0; i < valueTypeNames.Length; i++)
            {
                string name = valueTypeNames[i];
                searchFilterGenericMenu.AddItem(new GUIContent(valueTypeNames[i]), false, () => searchTerm = $"{TYPE_SEARCH_CONSTRAINT}{name}");
            }
        }

        private void SearchGUI()
        {
            EditorGUILayout.BeginHorizontal(GUI.skin.box);

            if (EditorGUILayout.DropdownButton(EditorGUIUtility.IconContent("FilterByType"), FocusType.Passive, EditorStyles.toolbarButton, GUILayout.Width(40)))
            {
                searchFilterGenericMenu.ShowAsContext();
            }

            searchTerm = EditorGUILayout.TextArea(searchTerm, EditorStyles.toolbarSearchField);
            EditorGUILayout.EndHorizontal();
        }

        private bool ShouldFiltered(FValue value)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return false;

            string typeFilter = null;
            string valueName = null;

            if (searchTerm.Length > TYPE_SEARCH_CONSTRAINT.Length && searchTerm.Substring(0, TYPE_SEARCH_CONSTRAINT.Length) == TYPE_SEARCH_CONSTRAINT)
            {
                string newSearchTerm = searchTerm.Remove(0, TYPE_SEARCH_CONSTRAINT.Length);

                string[] splitedSeachTerm = newSearchTerm.Split(' ');

                typeFilter = splitedSeachTerm[0];

                for (int i = 1; i < splitedSeachTerm.Length; i++)
                {
                    valueName += splitedSeachTerm[i];
                }
            }
            else
            {
                valueName = searchTerm;
            }

            if (string.IsNullOrEmpty(typeFilter) == false && string.IsNullOrEmpty(valueName) == false)
            {
                return value.Type.IndexOf(typeFilter, StringComparison.OrdinalIgnoreCase) == -1 || value.Name.IndexOf(valueName, StringComparison.OrdinalIgnoreCase) == -1;
            }
            else if (string.IsNullOrEmpty(typeFilter) == false)
            {
                return value.Type.IndexOf(typeFilter, StringComparison.OrdinalIgnoreCase) == -1;
            }
            else
            {
                return value.Name.IndexOf(valueName, StringComparison.OrdinalIgnoreCase) == -1;
            }
        }

        private void ValuesGUI()
        {
            EditorGUILayout.BeginVertical();

            for (int i = 0; i < values.Count; i++)
            {
                FValue value = values[i];

                if (ShouldFiltered(value)) continue;

                bool isRichText = EditorStyles.foldout.richText;
                EditorStyles.foldout.richText = true;
                value.IsFold = EditorGUILayout.Foldout(value.IsFold, $"{(value.HasError ? "<color=red>" : string.Empty)}{value.Name}{(value.HasError ? "- Duplicate Name</color>" : string.Empty)}");
                EditorStyles.foldout.richText = isRichText;

                if (value.IsFold)
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.BeginVertical(GUI.skin.box);

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(NAME, LABLE_WIDTH);
                    value.Name = EditorGUILayout.TextField(value.Name);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.PropertyField(value.IsReadOnly);

                    EditorGUILayout.PropertyField(value.Value);

                    if (GUILayout.Button(DELETE))
                    {
                        values.RemoveAt(i);
                    }

                    EditorGUILayout.EndVertical();

                    EditorGUI.indentLevel--;
                }
            }

            EditorGUILayout.EndVertical();
        }

        private void AddButtonGUI()
        {
            EditorGUILayout.BeginHorizontal(GUI.skin.box);

            selectedValueType = EditorGUILayout.Popup(string.Empty, selectedValueType, valueTypeNames);
            if (GUILayout.Button(ADD))
            {
                SValue value = (SValue)CreateInstance(valueTypes[selectedValueType]);

                value.name = $"{valueTypeNames[selectedValueType]}{values.Count}";

                values.Add(new FValue(value));
            }
            EditorGUILayout.EndHorizontal();
        }

        private void SaveButtonGUI()
        {
            EditorGUILayout.BeginHorizontal(GUI.skin.box);

            if (GUILayout.Button(SAVE))
            {
                var hasDuplicatedName = HasDuplicateName();

                if (hasDuplicatedName == false)
                {
                    Save();
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        private bool HasDuplicateName()
        {
            bool result = false;

            for (int i = 0; i < values.Count; i++)
            {
                for (int j = i + 1; j < values.Count; j++)
                {
                    if (values[i].Name == values[j].Name)
                    {
                        values[i].HasError = true;
                        values[j].HasError = true;

                        result = true;

                        break;
                    }
                    else
                    {
                        values[i].HasError = false;
                    }
                }
            }

            return result;
        }

        private void Save()
        {
            UnityEngine.Object[] oldObjects = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(serializedObject.targetObject));
            for (int i = 0; i < oldObjects.Length; i++)
            {
                if (oldObjects[i] == serializedObject.targetObject) continue;

                AssetDatabase.RemoveObjectFromAsset(oldObjects[i]);
            }

            FieldInfo fieldInfo = FReflectionUtility.GetField(serializedObject.targetObject, BLACKBOARD);
            Dictionary<string, SValue> blackboard = (Dictionary<string, SValue>)fieldInfo.GetValue(serializedObject.targetObject);
            blackboard.Clear();

            for (int i = 0; i < values.Count; i++)
            {
                FValue value = values[i];

                value.ApplyChanges();

                blackboard.Add(value.Name, value.ValueObject);

                AssetDatabase.AddObjectToAsset(value.ValueObject, serializedObject.targetObject);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        #endregion

        #region Nested Type
        private class FValue
        {
            #region Fields
            public bool IsFold;

            public bool HasError;

            private readonly SerializedObject serializedObject;
            #endregion

            #region Properties
            public SerializedProperty Value => serializedObject.FindProperty(VALUE);

            public SerializedProperty IsReadOnly => serializedObject.FindProperty(IS_READONLY);

            public string Name { get => ValueObject.name; set => ValueObject.name = value; }

            public SValue ValueObject { get; }

            public string Type { get; }
            #endregion

            #region Constructors
            public FValue(SValue value)
            {
                ValueObject = value;
                Type = FReflectionUtility.GetAttributeProperty<string>(value.GetType(), AName.CLASS_TYPE, nameof(AName.Name));
                serializedObject = new SerializedObject(value);
            }
            #endregion

            #region Methods
            public void ApplyChanges()
            {
                serializedObject.ApplyModifiedProperties();
            }
            #endregion
        }
        #endregion
    }
}