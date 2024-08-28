using UnityEngine;

public class BatController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = Vector2.Lerp(transform.position, mousePosition, speed * Time.deltaTime);
    }
}
