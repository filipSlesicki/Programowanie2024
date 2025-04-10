using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    public int Team;
    public Tile CurrentTile { get; private set; }
    [field: SerializeField] public bool Moved { get; private set; } = false;
    [SerializeField] private float radius = 1;
    [SerializeField] private int moveRange = 3;
    [SerializeField] public int attackRange = 1;
    [SerializeField] public int attackDamage = 1;
    [SerializeField] private float moveTime = 0.5f;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material movedMaterial;
    [SerializeField] private LayerMask tileLayer;
    private UnitControler unitControler;
    private Map map;
    private float tileScale = 2;

    private void Start()
    {
        map = FindAnyObjectByType<Map>();
        unitControler = FindAnyObjectByType<UnitControler>();
        unitControler.NextTurnEvent.AddListener(OnNewTurn);
        if (map.TryGetTileOnPosition(transform.position, out Tile tile))
        {
            CurrentTile = tile;
            CurrentTile.unit = this;
        }
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

    public void Move(Tile tile)
    {
        if (CurrentTile != null)
        {
            // Wychodzimy z poprzedniego pola
            CurrentTile.unit = null;
        }
        // Wchodzimy na nowe pole
        CurrentTile = tile;
        tile.unit = this;
        StartCoroutine(MoveToPosition(tile.transform.position));
        FinishMove();
    }

    public void Attack(Unit target)
    {
        target.GetComponent<Health>().ModifyHealth(-attackDamage);
        FinishMove();
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time <= moveTime)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / moveTime);
            yield return null;
        }
    }

    public void FinishMove()
    {
        meshRenderer.material = movedMaterial;
        Moved = true;
    }

    public void OnNewTurn(int currentTeam)
    {
        meshRenderer.material = normalMaterial;
        Moved = false;
    }

    public HashSet<Tile> GetTilesInAttackRange()
    {
        HashSet<Tile> tilesInRange = FindAnyObjectByType<Map>().GetTilesInRange(CurrentTile.Position, attackRange);
        return tilesInRange;
    }

    public HashSet<Tile> GetTilesInMoveRange()
    {
        HashSet<Tile> awailableTiles = new HashSet<Tile>();
        List<Tile> checkingTiles = new List<Tile>();
        awailableTiles.Add(CurrentTile);
        checkingTiles.Add(CurrentTile);

        for (int i = 0; i < moveRange; i++)
        {
            List<Tile> nextCheckingTiles = new List<Tile>();
            foreach (Tile tile in checkingTiles)
            {
                foreach (Tile neighbourTile in tile.Neighbours)
                {
                    if (awailableTiles.Contains(neighbourTile) || neighbourTile.IsOccupied)
                    {
                        continue;
                    }
                    nextCheckingTiles.Add(neighbourTile);
                    awailableTiles.Add(neighbourTile);
                }
            }
            checkingTiles = nextCheckingTiles;

        }
        return awailableTiles;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        float scaledMoveRange = tileScale / 2 + moveRange * tileScale;
        Gizmos.DrawWireCube(transform.position, new Vector3(scaledMoveRange * 2, 1, scaledMoveRange * 2));
    }
}
