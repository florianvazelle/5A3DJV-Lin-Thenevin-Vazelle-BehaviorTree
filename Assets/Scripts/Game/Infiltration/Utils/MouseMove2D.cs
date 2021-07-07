using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour que le GameObject attaché suive les mouvement de la souris
/// </summary>
public class MouseMove2D : MonoBehaviour
{
	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;

	void Update()
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 tmp = Vector2.Lerp(new Vector2(transform.position.x, transform.position.z), new Vector2(mousePosition.x, mousePosition.z), moveSpeed);
		transform.position = new Vector3(tmp.x, transform.position.y, tmp.y);
	}
}
