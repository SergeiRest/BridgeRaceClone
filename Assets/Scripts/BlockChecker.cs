using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
	private Material _material;
	private void Start()
	{
		_material = GetComponent<Material>();
	}
	private void TryAddBlock(MeshRenderer playerRender, MeshRenderer obj)
	{
		if (playerRender.material.name != obj.material.name)
			return;
		Debug.Log("True");
	}

	private void OnTriggerEnter(Collider other)
	{
		if(TryGetComponent(out PlayerView playerView))
		{
			if (playerView.PlayerMaterial == _material)
				Debug.Log("True");
			else
				Debug.Log("False");
		}
	}
}
