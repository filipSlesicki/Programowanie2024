using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;

public class UnitControler : MonoBehaviour
{
    public UnityEvent NextTurnEvent { get; private set; } = new UnityEvent();
    private Unit selectedUnit;
    private List<Tile> tilesInRange;
    private Map map;

    private void Awake()
    {
        map = FindAnyObjectByType<Map>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
            {
                //Unit unit = mouseHit.transform.GetComponentInParent<Unit>();
                //if(unit != null)
                if (mouseHit.transform.TryGetComponent(out Unit unit)) // To dzia³a je¿eli parent ma rigidbody
                {
                    if (unit.Moved)
                    {
                        return;
                    }

                    if (selectedUnit != null)
                    {
                        selectedUnit.Deselect();
                        tilesInRange.Clear();
                    }

                    selectedUnit = unit;
                    selectedUnit.Select();
                    tilesInRange = selectedUnit.GetTilesInRange();
                }
                else if (mouseHit.transform.TryGetComponent(out Tile tile) 
                    && !tile.IsOccupied 
                    && selectedUnit != null)
                {
                    if(tilesInRange.Contains(tile))
                    {
                        selectedUnit.Move(tile);
                        selectedUnit = null;
                        tilesInRange.Clear();
                    }
                }
            }
            else
            {
                if (selectedUnit != null)
                {
                    selectedUnit.Deselect();
                    selectedUnit = null;
                }
            }
        }
    }

    public void EndTurn()
    {
        NextTurnEvent?.Invoke();
    }

    [SerializeField]
    private Vector3 rayStart;
    [SerializeField] private Vector3 rayDirection;
    [Range(0f, 10f)]
    [Tooltip("Zasiêg raycasta gizmo ")]
    [SerializeField] private float rayDistance = 5;

    void DoSomething(out float cos)
    {
        cos = 5324f;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rayStart, 0.1f);

        if (Physics.Raycast(rayStart, rayDirection, out RaycastHit hit, rayDistance))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, hit.normal);
            Gizmos.color = Color.yellow;
            Debug.Log(hit.transform.gameObject.name);
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(rayStart, rayDirection.normalized * rayDistance);
    }
}
