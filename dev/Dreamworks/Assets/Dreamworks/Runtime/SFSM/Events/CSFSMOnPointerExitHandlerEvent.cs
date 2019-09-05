﻿/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D || PHYSIC_3D

using UnityEngine.EventSystems;

namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>August/8/2019</CreationDate>
    public class CSFSMOnPointerExitHandlerEvent : CSFSMEvent, IPointerExitHandler
    {

        #region Method
        public void OnPointerExit(PointerEventData eventData)
        {
            Owner.OnPointerExitHandlerEvent(eventData);
        }
        #endregion
    }
} 
#endif