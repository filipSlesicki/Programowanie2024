using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
    [SerializeField] private int moveRange = 3;
    [SerializeField] private float moveTime = 0.5f;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material movedMaterial;
    [SerializeField] private LayerMask tileLayer;

    public Tile currentTile;
    private UnitControler unitControler;
    Map map;
    private float tileScale = 2;
    private void Start()
    {
        map = FindAnyObjectByType<Map>();
        unitControler = FindAnyObjectByType<UnitControler>();
        unitControler.NextTurnEvent.AddListener(OnNewTurn);
        if (map.TryGetTileOnPosition(transform.position, out currentTile))
        {
            currentTile.IsOccupied = true;
        }
    }

    [ContextMenu("Select")]
    public void Select()
    {
        meshRenderer.material = selectedMaterial;
        GetTilesInRange();
    }

    public void Deselect()
    {
        meshRenderer.material = normalMaterial;
    }

    public void Move(Tile tile)
    {
        if (currentTile != null)
        {
            currentTile.IsOccupied = false;
        }
        currentTile = tile;
        tile.IsOccupied = true;
        StartCoroutine(MoveToPosition(tile.transform.position));
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

    public void OnNewTurn()
    {
        meshRenderer.material = normalMaterial;
        Moved = false;
    }

    public List<Tile> GetTilesInRange()
    {
        Vector2Int position = Vector2Int.RoundToInt(new Vector2(transform.position.x, transform.position.z) / tileScale);
        List<Tile> tilesInRange = FindAnyObjectByType<Map>().GetTilesInRange(position, moveRange);

        //float scaledMoveRange = tileScale / 2 + moveRange * tileScale;
        //Collider[] tilesInRange = Physics.OverlapBox(transform.position,
        //    new Vector3(scaledMoveRange, 1, scaledMoveRange), Quaternion.identity, tileLayer);

        for (int i = 0; i < tilesInRange.Count; i++)
        {
            Debug.Log(tilesInRange[i].gameObject.name);
        }
        return tilesInRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        float scaledMoveRange = tileScale / 2 + moveRange * tileScale;
        Gizmos.DrawWireCube(transform.position, new Vector3(scaledMoveRange * 2, 1, scaledMoveRange * 2));
    }
}
