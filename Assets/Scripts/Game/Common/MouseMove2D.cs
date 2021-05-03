using UnityEngine;
using System.Collections;

public class MouseMove2D : MonoBehaviour
{

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 tmp = Vector2.Lerp(new Vector2(transform.position.x, transform.position.z), new Vector2(mousePosition.x, mousePosition.z), moveSpeed);
        transform.position = new Vector3(tmp.x, transform.position.y, tmp.y);
    }
}
