using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	private Camera _camera;
	[SerializeField] private float _speed;
	private float _gravity = -9.8f;
	private Vector3 _moveVector = Vector3.zero;
	private CharacterController _characterController;
	[SerializeField] private TouchMovement _touch;
	private Animator _animator;
    void Start()
    {
		_camera = Camera.main;
		_camera.transform.rotation = Quaternion.Euler(50, 0, 0);
		_animator = GetComponent<Animator>();
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
		_animator.SetFloat("Run", Mathf.Abs(dir.x) + Mathf.Abs(dir.y));
		_camera.transform.position = gameObject.transform.position + new Vector3(0, 10f, -4f);
	}
}
