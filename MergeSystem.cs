
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Merges;

/// <summary>
/// It is more correct to divide this class into three classes: Oncollisions, DragAndDrop and ItemMerge. 
/// But at this point, all the merge logic is here.
/// </summary>
public class MergeSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Type itemType; // Enum type of draggable object.
    private GameObject draggbleObject; // Object that will be drag.
    private GameObject collisionGameObject; // Object that will be destroyed and in its place will be a new object.
    private GameObject newGameObject; // Object that create from merger.
    private RectTransform objectRectTransform; // Draggable object RectTransform.
    private Vector3 originalPosition; // Draggable object original position.
    private bool isMergePossible;
    private bool isMergeFinished;


    /// <summary>
    /// Objects that will be result of merge.
    /// </summary>
    [SerializeField] private GameObject IceCrystal;
    [SerializeField] private GameObject FireCrystal;
    [SerializeField] private GameObject ElectricCrystal;
    [SerializeField] private GameObject EarthCrystal;
    [SerializeField] private GameObject GiantIceCrystal;
    [SerializeField] private GameObject GiantFireCrystal;
    [SerializeField] private GameObject GiantElectricCrystal;
    [SerializeField] private GameObject GiantEarthCrystal;

    private void Awake()
    {
        // Get enum type of draggable object.
        EnumItems enumItems = GetComponent<EnumItems>();
        if (enumItems != null)
        {
            itemType = enumItems.itemType;
        }
        // Get RectTransform of draggable object.
        objectRectTransform = GetComponent<RectTransform>();
        draggbleObject = objectRectTransform.gameObject;
        // Make a new object usable.
        if (isMergeFinished)
        {
            draggbleObject = newGameObject;
            isMergeFinished = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Get start position
        originalPosition = objectRectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Get current position that equals pointer position.
        objectRectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Get a new object and destroy olds.
        if (isMergePossible)
        {
            MergeAction();
            Destroy(objectRectTransform.gameObject);
            Destroy(collisionGameObject);
            isMergePossible = false;
            isMergeFinished = true;
            Awake();
        }
        // Comeback to start position if it wasn't merge.
        else
        {
            objectRectTransform.position = originalPosition;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check the enum of the collision object and if it is equal to the dragged object, set the flag to true.
        EnumItems enumCollisionObject = collision.gameObject.GetComponent<EnumItems>();
        // Check equalty of objects.
        if (enumCollisionObject != null && enumCollisionObject.itemType == itemType)
        {
            collisionGameObject = collision.gameObject;
            isMergePossible = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isMergePossible = false;
    }

    private GameObject MergeAction()
    {
        // switch happens...
        switch (itemType)
        {
            case Type.MiniIceCrystal:
                newGameObject = Clonemaker(IceCrystal);
                break;

            case Type.MiniFireCrystal:
                newGameObject = Clonemaker(FireCrystal);
                break;

            case Type.MiniElectricCrystal:
                newGameObject = Clonemaker(ElectricCrystal);
                break;

            case Type.MiniEarthCrystal:
                newGameObject = Clonemaker(EarthCrystal);
                break;

            case Type.IceCrystal:
                newGameObject = Clonemaker(GiantIceCrystal);
                break;

            case Type.FireCrystal:
                newGameObject = Clonemaker(GiantFireCrystal);
                break;

            case Type.ElectricCrystal:
                newGameObject = Clonemaker(GiantElectricCrystal);
                break;

            case Type.EarthCrystal:
                newGameObject = Clonemaker(GiantEarthCrystal);
                break;

            case Type.GiantIceCrystal:
                break;

            case Type.GiantFireCrystal:
                break;

            case Type.GiantElectricCrystal:
                break;

            case Type.GiantEarthCrystal:
                break;
        }
        return newGameObject;
    }

    private GameObject Clonemaker(GameObject crystalToClone)
    {
        GameObject clone = Instantiate(crystalToClone, Vector3.zero, Quaternion.identity, collisionGameObject.GetComponentInParent<Transform>());
        clone.transform.localPosition = Vector3.zero;
        clone.transform.SetParent(collisionGameObject.transform.parent);
        clone.transform.localScale = collisionGameObject.transform.localScale;
        return clone;
    }
}

