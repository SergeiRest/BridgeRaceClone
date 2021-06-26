using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMovement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
	private Vector3 _direction = Vector3.zero;
	private Vector3 _origin;

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 currentPosition = eventData.position;
		Vector3 directionRaw = currentPosition - _origin;
		_direction = directionRaw.normalized;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_origin = eventData.position;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_direction = Vector3.zero;
	}

	public Vector3 GetDirection()
	{
		return _direction;
	}
}
