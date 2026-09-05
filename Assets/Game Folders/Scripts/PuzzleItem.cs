using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleItem : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IPointerClickHandler
{
    [Header("Puzzle Settings")]
    public int puzzleID;

    private Transform originalParent;
    private Vector3 originalPosition;

    private bool isDroppedCorrectly = false;
    private bool isDroppedOnSlot = false;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Simpan parent dan posisi awal
        originalParent = transform.parent;
        originalPosition = transform.position;

        isDroppedCorrectly = false;
        isDroppedOnSlot = false;

        // Supaya puzzle berada paling depan saat drag
        transform.SetParent(canvas.transform);

        Debug.Log("Mulai drag Puzzle ID: " + puzzleID);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Jika tidak masuk ke slot
        if (!isDroppedOnSlot)
        {
            ReturnToContainer();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Select Puzzle ID: " + puzzleID);
    }

    public void CheckSlot(SlotItem slot)
    {
        isDroppedOnSlot = true;

        // Cek ID puzzle dengan ID slot
        if (puzzleID == slot.slotID)
        {
            isDroppedCorrectly = true;

            Debug.Log("BENAR");

            // Tempatkan puzzle di slot
            transform.SetParent(slot.transform);

            RectTransform rect = GetComponent<RectTransform>();
            rect.anchoredPosition = Vector2.zero;

            // Bisa dikunci agar tidak bisa digeser lagi
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            Debug.Log("SALAH");

            // Karena salah, kembalikan ke container
            ReturnToContainer();
        }
    }

    private void ReturnToContainer()
    {
        transform.SetParent(originalParent);
        transform.position = originalPosition;

        Debug.Log("Puzzle kembali ke container");
    }
}