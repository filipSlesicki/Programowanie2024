using UnityEngine;

public class UnitControler : MonoBehaviour
{
    private Unit selectedUnit;

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
                    if(unit.moved)
                    {
                        return;
                    }

                    if (selectedUnit != null)
                    {
                        selectedUnit.Deselect();
                    }

                    selectedUnit = unit;
                    selectedUnit.Select();
                }
                else if (mouseHit.transform.TryGetComponent(out Tile tile) && selectedUnit != null)
                {
                    selectedUnit.transform.position = tile.transform.position;
                    selectedUnit.FinishMove();
                    selectedUnit = null;
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



    public Vector3 rayStart;
    public Vector3 rayDirection;
    public float rayDistance = 5;

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
