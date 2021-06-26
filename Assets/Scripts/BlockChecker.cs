using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
	private PlayerView _player;
	private Material _material;
	[SerializeField] private ParticleSystem _trail;
	private void TryAddBlock(Material playerRender, Material obj, Transform parent, Vector3 backPoints)
	{
		if (playerRender.name != obj.name)
			return;
		WorldResumption.AddObject(gameObject.transform.position);
		_trail.Play();
		TryMoveBlock();
	}

	private void OnTriggerEnter(Collider other)
	{
		_material = GetComponent<MeshRenderer>().material;
		if(other.gameObject.TryGetComponent(out PlayerView playerView))
		{
			_player = playerView;
			gameObject.GetComponent<Collider>().enabled = false;
			TryAddBlock(_player.PlayerMaterial, _material, _player.transform, _player.Points);
		}
	}

	private async void TryMoveBlock()
	{
		var step = 0.15f;
		float progress = 0;
		float currentPointY = _player.Points.y;
		
		while (transform.position != _player.Points) {
			gameObject.transform.parent = _player.transform;
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.Points.x, currentPointY, _player.Points.z), step);
			progress += step;
			await Task.Delay(2);
		}
		_trail.Stop();
		_player.AddArray(this);
		transform.localEulerAngles = new Vector3(0, 90, 0);
		Debug.Log(transform.localEulerAngles.y);
		Debug.Log("Перенёс");
	}
}
