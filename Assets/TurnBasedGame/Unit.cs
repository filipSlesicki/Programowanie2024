using UnityEngine;
using UnityEngineInternal;

[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    //private bool moved;
    //public bool Moved 
    //{ 
    //    get
    //    {
    //        return moved;
    //    }
    //    private set
    //    {
    //        //Debug.Log("Setting value to " + value);
    //        moved = value;
    //    }
    //}

    [field: SerializeField] public bool Moved { get; private set; } = false;

    private float diameter { get { return radius * 2; } set { radius = value / 2; } }
    float d => diameter;// {get {return diameter;}}
    [SerializeField] private float radius = 1;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material movedMaterial;
    private UnitControler unitControler;

    private void Start()
    {
        unitControler = FindAnyObjectByType<UnitControler>();
        unitControler.NextTurnEvent.AddListener(OnNewTurn);
    }

    [ContextMenu("Select")]
    public void Select()
    {
        meshRenderer.material = selectedMaterial;
    }

    public void Deselect()
    {
        meshRenderer.material = normalMaterial;
    }

    public void FinishMove()
    {
        meshRenderer.material = movedMaterial;
        Moved = true;
    }

    public void OnNewTurn()
    {
        meshRenderer.material = normalMaterial;
        Moved = false;
    }
}
