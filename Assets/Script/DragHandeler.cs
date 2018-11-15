using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeginDrag;
    Vector3 startPosition;
    Transform startParent;
    private Vector3 newPos;


    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeginDrag = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.GetComponent<RectTransform>(), eventData.position, eventData.enterEventCamera, out newPos);
        transform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeginDrag = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }
}

internal class GetComponent<T>
{
    }

    
