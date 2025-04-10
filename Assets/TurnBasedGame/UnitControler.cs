using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UnitControler : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<int> NextTurnEvent { get; private set; } = new UnityEvent<int>();
    private Unit selectedUnit;
    private HashSet<Tile> tilesInRange = new HashSet<Tile>();
    private Map map;
    [SerializeField] private List<int> teams;
    public int activeTeamIndex;
    private ControlState controlState;


    private void Awake()
    {
        map = FindAnyObjectByType<Map>();
        NextTurnEvent?.Invoke(teams[activeTeamIndex]);
    }

    void Update()
    {
        // EventSystem.current.IsPointerOverGameObject() sprawdza czy myszka jest nad UI
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            OnMouseClick();
        }
    }

    private void OnMouseClick()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
        {
            if (mouseHit.transform.TryGetComponent(out Unit unit)) // To dzia³a je¿eli parent ma rigidbody
            {
                OnClickOnUnit(unit);
            }
            else if (mouseHit.transform.TryGetComponent(out Tile tile))
            {
                OnClickOnTile(tile);
            }
        }
        else
        {
            OnClickOnNothing();
        }
    }

    private void OnClickOnNothing()
    {
        if (selectedUnit != null)
        {
            selectedUnit.Deselect();
            selectedUnit = null;
            ChangeState(ControlState.None);
        }
    }

    private void OnClickOnTile(Tile tile)
    {
        if(selectedUnit == null || !tilesInRange.Contains(tile))
        {
            return;
        }

        if(controlState == ControlState.Move)
        {
            if (!tile.IsOccupied)
            {
                selectedUnit.Move(tile);
                selectedUnit = null;
                ChangeState(ControlState.None);
            }
        }
        else if(controlState == ControlState.Attack)
        {
            if(tile.IsOccupied)
            {
                Unit unitOnTile = tile.unit;
                if (unitOnTile.Team != teams[activeTeamIndex])
                {
                    selectedUnit.Attack(unitOnTile);
                    ChangeState(ControlState.None);
                    Debug.Log("Attack unit " + unitOnTile.gameObject.name);
                }
            }
        }
    }

    private void OnClickOnUnit(Unit clickedUnit)
    {
        if (controlState == ControlState.Move || controlState == ControlState.None)
        {
            if (selectedUnit != null)
            {
                selectedUnit.Deselect();
                ClearTilesInRange();
            }

            if (clickedUnit.Team == teams[activeTeamIndex] && !clickedUnit.Moved)
            {
                selectedUnit = clickedUnit;
                ChangeState(ControlState.Move);
            }
        }
        else if (controlState == ControlState.Attack)
        {
            if(clickedUnit.Team != teams[activeTeamIndex])
            {
                if(tilesInRange.Contains(clickedUnit.CurrentTile))
                {
                    selectedUnit.Attack(clickedUnit);
                    ChangeState(ControlState.None);
                    Debug.Log("Attack unit " + clickedUnit.gameObject.name);
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

    public void ChangeState(ControlState nextState)
    {
        ClearTilesInRange();
        controlState = nextState;

        if (selectedUnit == null)
        {
            return;
        }

        Color tileColor = Color.white;
        if(controlState == ControlState.Attack)
        {
            tileColor = Color.red;
            tilesInRange = map.GetTilesInRange(selectedUnit.CurrentTile.Position, selectedUnit.attackRange);
        }
        else if(controlState == ControlState.Move)
        {
            tileColor = Color.blue;
            tilesInRange = selectedUnit.GetTilesInMoveRange();
        }

        foreach (Tile tile in tilesInRange)
        {
            tile.GetComponent<MeshRenderer>().material.color = tileColor;
        }
    }

    // UI
    public void EndTurn()
    {
        activeTeamIndex = (activeTeamIndex + 1) % teams.Count;
        NextTurnEvent?.Invoke(teams[activeTeamIndex]);
        ChangeState(ControlState.None);
        selectedUnit = null;
    }

    public void GoToAttackState()
    {
        ChangeState(ControlState.Attack);
    }

    public void GoToMoveState()
    {
        ChangeState(ControlState.Move);
    }
}
