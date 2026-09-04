using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleItem : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Select");
    }
}
