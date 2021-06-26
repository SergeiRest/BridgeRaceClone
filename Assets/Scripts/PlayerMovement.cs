using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed;
	private float _gravity = -9.8f;
	private Vector3 _moveVector = Vector3.zero;
	private CharacterController _characterController;
	[SerializeField] private TouchMovement _touch;
    void Start()
    {
		_characterController = GetComponent<CharacterController>();   
    }

    void Update()
    {
		Movement();
    }

	private void Movement()
	{
		
		
		var dir = _touch.GetDirection();
		_moveVector.x = dir.x * _speed;
		_moveVector.z = dir.y * _speed;
		_moveVector.y = _gravity;

		Vector3 movement = new Vector3(_moveVector.x, _gravity, _moveVector.z);
		movement = Vector3.ClampMagnitude(movement, _speed);
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_characterController.Move(_moveVector * Time.deltaTime);
		transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
		
	}
}
