using UnityEngine;

public class Unit : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material selectedMaterial;
    public Material normalMaterial;
    public Material movedMaterial;
    public bool moved;

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
        moved = true;
    }
}
