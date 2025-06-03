﻿#if UNITY_EDITOR
using UnityEngine;

namespace VladislavTsurikov.IMGUIUtility.Editor
{
    public class DragAndDrop
	{
        private enum State
		{
			None,
			Dragging,
			DragPerform
		}
        
        private object _dragData;
		private Vector2 _mouseDownPosition;
		private State _state = State.None;
		private const float DragStartDistance = 14.0f;

        public void OnBeginGUI()
        {
            Event e = Event.current;

            if (e.type == EventType.MouseDown && e.button == 0)
            {
                _mouseDownPosition = e.mousePosition;
            }

            if(_state == State.Dragging)
            {
                if (e.type == EventType.MouseUp && e.button == 0)
                {                        
                    _state = State.DragPerform;
                }  
            }
        }

        public void OnEndGUI()
        {
            Event e = Event.current;

            if(_state == State.DragPerform)
            {
                _dragData = null;
                _state = State.None;
            }

            if(_dragData != null)
            {
                if(_state == State.None)
                {
                    if (e.type == EventType.MouseDrag &&
                        (_mouseDownPosition - e.mousePosition).magnitude > DragStartDistance)
                    {
                        _state = State.Dragging;
                    }
                }
            }
        }

        public void AddDragObject(object data)
        {
            if (data == null && _dragData != null)
			{
				return;
			}

            if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                _dragData = data;
            }
        }

        public bool IsDragging()
        {
            return _state == State.Dragging;
        }

        public bool IsDragPerform()
        {
            return _state == State.DragPerform;
        }

        public object GetData()
        {
            return _dragData;
        }
    }
}
#endif