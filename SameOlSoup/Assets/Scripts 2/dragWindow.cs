using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragWindow : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Vector2 offset;

    public RectTransform myRectTransform;

    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = myRectTransform.anchoredPosition - (Vector2)Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        myRectTransform.anchoredPosition = (Vector2)Input.mousePosition + offset;
    }
    
}
