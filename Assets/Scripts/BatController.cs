using UnityEngine;

public class BatController : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 previousPosition;
    private Vector3 batVelocity;
    private bool isDragging = false;
    private Vector3 dragOffset;

    public GameView gameView;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
            gameView.BatAnimTap();
            transform.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            UpdateBatPosition();
            transform.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
            gameView.BatAnimRelease();
            transform.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

        }
    }

    private void StartDragging()
    {
        Vector3 worldPosition = GetWorldPositionFromInput();

        if (GetComponent<Collider2D>().OverlapPoint(worldPosition))
        {
            isDragging = true;
            dragOffset = transform.position - worldPosition;
        }
    }

    private void StopDragging()
    {
        isDragging = false;
        batVelocity = Vector3.zero;
    }

    private void UpdateBatPosition()
    {
        Vector3 targetPosition = GetWorldPositionFromInput() + dragOffset;

        targetPosition.y = transform.position.y;

        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        batVelocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
    }

    private Vector3 GetWorldPositionFromInput()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public Vector3 GetBatVelocity()
    {
        return batVelocity;
    }
}
