using UnityEngine;

public class BatController : MonoBehaviour
{
    public float speed = 10f;
    public float maxY = -1f;

    private Vector3 previousPosition;
    private Vector3 batVelocity;
    private bool isDragging = false;
    private Vector3 dragOffset;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            
            if (GetComponent<Collider2D>().OverlapPoint(worldPosition))
            {
                isDragging = true;
                dragOffset = transform.position - worldPosition;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            UpdateBatPosition();
            CalculateBatVelocity();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            batVelocity = Vector3.zero;
        }
    }

    private void UpdateBatPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition) + dragOffset;
        targetPosition.z = 0;

        if (targetPosition.y > maxY)
        {
            targetPosition.y = maxY;
        }

        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void CalculateBatVelocity()
    {
        batVelocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
    }

    public Vector3 GetBatVelocity()
    {
        return batVelocity;
    }
}
