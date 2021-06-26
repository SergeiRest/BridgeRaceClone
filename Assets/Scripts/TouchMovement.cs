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
		//Debug.Log(currentPosition);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//OnDrag(eventData);
		_origin = eventData.position;
		//Debug.Log(_origin);
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
