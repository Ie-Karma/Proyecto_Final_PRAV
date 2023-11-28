using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;  // El objeto que la c�mara seguir�
	public float smoothSpeed = 0.125f;  // La suavidad del seguimiento

	private Vector3 offset;  // Distancia entre la c�mara y el objetivo inicial

	private void Start()
	{
		// Calcula la distancia inicial entre la c�mara y el objetivo
		offset = transform.position - target.position;
	}

	private void LateUpdate()
	{
		// Calcula la posici�n deseada de la c�mara
		Vector3 desiredPosition = target.position + offset;

		// Suaviza la transici�n entre la posici�n actual y la deseada
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

		// Actualiza la posici�n de la c�mara (solo en X y Z)
		transform.position = new Vector3(smoothedPosition.x, transform.position.y, smoothedPosition.z);
	}
}
