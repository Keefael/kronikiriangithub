using UnityEngine;
using UnityEngine.EventSystems;

public class SlotItem : MonoBehaviour, IDropHandler
{
    [Header("Slot Settings")]
    public int slotID;

    public void OnDrop(PointerEventData eventData)
    {
        PuzzleItem puzzle = eventData.pointerDrag.GetComponent<PuzzleItem>();

        if (puzzle != null)
        {
            puzzle.CheckSlot(this);
        }
    }
}