using UnityEngine;

public class BatController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        UpdateGame();
    }
    void UpdateGame()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        targetPosition.z = 0;
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
