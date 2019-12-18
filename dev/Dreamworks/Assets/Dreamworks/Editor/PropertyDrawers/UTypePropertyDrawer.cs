/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEditor;
using System.Linq;
using UnityEngine;
using System.Reflection;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Utility;

namespace DreamMachineGameStudio.Dreamworks.Editor
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>December/18/2019</CreationDate>
    [CustomPropertyDrawer(typeof(FType))]
    public class UTypePropertyDrawer : PropertyDrawer
    {
        #region Fields
        private string[] typeNames;
        private int selectedIndex;
        #endregion

        #region Editor Methods
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var nameProperty = property.FindPropertyRelative("fullName");

            if (typeNames == null)
            {
                CacheTypeNames();

                if (typeNames != null && typeNames.Length > 0)
                {
                    selectedIndex = Array.IndexOf(typeNames, nameProperty.stringValue);
                }
            }

            Vector2 lableSize = GUI.skin.label.CalcSize(label);

            EditorGUI.LabelField(new Rect(position.x, position.y, lableSize.x, position.height), label);
            selectedIndex = EditorGUI.Popup(new Rect(position.x + lableSize.x + 5, position.y, position.width - lableSize.x - 5, position.height), selectedIndex, typeNames);

            if (typeNames != null && typeNames.Length > 0)
            {
                nameProperty.stringValue = typeNames[selectedIndex];
            }
        }
        #endregion

        #region Private Methods
        private void CacheTypeNames()
        {
            if (fieldInfo.IsDefined(ATypeFilter.CLASS_TYPE))
            {
                Attribute attribute = fieldInfo.GetCustomAttribute(ATypeFilter.CLASS_TYPE);
                PropertyInfo typePropertyInfo = attribute.GetType().GetProperty(nameof(ATypeFilter.Type));
                Type typeFilter = (Type)typePropertyInfo.GetValue(attribute);
                typeNames = FReflectionUtility.GetSubTypesOf(typeFilter)?.Select(x => x.FullName).ToArray();
            }
        }

        #endregion
    }
}