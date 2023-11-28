using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;  // El objeto que la cámara seguirá
	public float smoothSpeed = 0.125f;  // La suavidad del seguimiento

	private Vector3 offset;  // Distancia entre la cámara y el objetivo inicial

	private void Start()
	{
		// Calcula la distancia inicial entre la cámara y el objetivo
		offset = transform.position - target.position;
	}

	private void LateUpdate()
	{
		// Calcula la posición deseada de la cámara
		Vector3 desiredPosition = target.position + offset;

		// Suaviza la transición entre la posición actual y la deseada
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

		// Actualiza la posición de la cámara (solo en X y Z)
		transform.position = new Vector3(smoothedPosition.x, transform.position.y, smoothedPosition.z);
	}
}
