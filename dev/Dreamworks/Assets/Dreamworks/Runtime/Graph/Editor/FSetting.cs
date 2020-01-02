/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Graph.Editor
{
    [Serializable]
    public class FSetting
    {
        #region Fields
        [SerializeField]
        private float maxZoom = 5.0f;

        [SerializeField]
        private float minZoom = 1.0f;

        [SerializeField]
        private float zoomStep = 0.1f;

        [SerializeField]
        private bool shouldZoomToMouse = true;

        [SerializeField]
        private bool isPortTooltipEnable = true;

        [SerializeField]
        private bool isSnapEnable = true;

        [SerializeField]
        private bool isAutoSaveEnable = true;

        [SerializeField]
        private Color32 gridLineColor = new Color(0.45f, 0.45f, 0.45f);

        [SerializeField]
        private Color32 gridBackgroundColor = new Color(0.18f, 0.18f, 0.18f);

        [SerializeField]
        private Color32 highlightColor = new Color32(255, 255, 255, 255);

        [SerializeField]
        private Texture2D gridTexture;

        [SerializeField]
        private Texture2D crossTexture;
        #endregion

        #region Properties
        public float MaxZoom => maxZoom;

        public float MinZoom => minZoom;

        public float ZoomStep => zoomStep;

        public bool ShouldZoomToMouse => shouldZoomToMouse;

        public bool IsPortTooltipEnable => isPortTooltipEnable;

        public bool IsSnapEnable => isSnapEnable;

        public bool IsAutoSaveEnable => isAutoSaveEnable;

        public Color32 GridLineColor => gridLineColor;

        public Color32 GridBackgroundColor => gridBackgroundColor;

        public Color32 HighlightColor => highlightColor;

        public Texture2D GridTexture
        {
            get
            {
                if (gridTexture == null)
                {
                    gridTexture = FGraphEditorResources.GenerateGridTexture(gridLineColor, gridBackgroundColor);
                }
                return gridTexture;
            }
        }

        public Texture2D CrossTexture
        {
            get
            {
                if (crossTexture == null)
                {
                    crossTexture = FGraphEditorResources.GenerateCrossTexture(gridLineColor);
                }
                return crossTexture;
            }
        }
        #endregion

    }
}