using UnityEngine;

public class ClickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.TryGetComponent(out IClickable clickable))
                {
                    clickable.OnClick();
                }
            }
        }
    }
}
