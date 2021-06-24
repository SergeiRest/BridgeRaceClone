using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed;
	private float _deltaX;
	private float _deltaZ;
	private float _gravity = -9.8f;
	private CharacterController _characterController;
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
		_deltaX = Input.GetAxis("Horizontal") * _speed;
		_deltaZ = Input.GetAxis("Vertical") * _speed;

		Vector3 movement = new Vector3(_deltaX, _gravity, _deltaZ);
		movement = Vector3.ClampMagnitude(movement, _speed);
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_characterController.Move(movement);
	}
}
