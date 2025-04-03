using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;

public class UnitControler : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<int> NextTurnEvent { get; private set; } = new UnityEvent<int>();
    private Unit selectedUnit;
    private HashSet<Tile> tilesInRange;
    private Map map;
    [SerializeField] private List<int> teams;
    public int activeTeamIndex;

    private void Awake()
    {
        map = FindAnyObjectByType<Map>();
        NextTurnEvent?.Invoke(teams[activeTeamIndex]);
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
                    if(unit.Team != teams[activeTeamIndex])
                    {
                        return;
                    }

                    if (unit.Moved)
                    {
                        return;
                    }

                    if (selectedUnit != null)
                    {
                        selectedUnit.Deselect();
                        ClearTilesInRange();
                    }

                    selectedUnit = unit;
                    selectedUnit.Select();
                    tilesInRange = selectedUnit.GetTilesInRange2();
                    foreach (Tile tile in tilesInRange)
                    {
                        tile.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }
                }
                else if (mouseHit.transform.TryGetComponent(out Tile tile) 
                    && !tile.IsOccupied 
                    && selectedUnit != null)
                {
                    if(tilesInRange.Contains(tile))
                    {
                        selectedUnit.Move(tile);
                        selectedUnit = null;
                        ClearTilesInRange();
                    }
                }
            }
            else
            {
                if (selectedUnit != null)
                {
                    selectedUnit.Deselect();
                    selectedUnit = null;
                    ClearTilesInRange();
                }
            }
        }
    }

    private void ClearTilesInRange()
    {
        foreach (Tile tile in tilesInRange)
        {
            tile.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        tilesInRange.Clear();
    }

    public void EndTurn()
    {
        activeTeamIndex = (activeTeamIndex + 1) % teams.Count;
        NextTurnEvent?.Invoke(teams[activeTeamIndex]);
    }

    public void ShowAttackTiles()
    {
        if(selectedUnit == null)
        {
            return;
        }
        List<Tile> attackTiles = map.GetTilesInRange(selectedUnit.currentTile.Position, selectedUnit.attackRange);
        foreach (Tile tile in attackTiles)
        {
            tile.GetComponent<MeshRenderer>().material.color = Color.red;
        }
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
