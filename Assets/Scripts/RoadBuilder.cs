using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
	[SerializeField] Collider _blockCollider;
	[SerializeField] MeshRenderer _parentRender;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out PlayerView player)) {
			//Debug.Log("True");
			//Debug.Log(player.GetBlockArrayLenght());
			if(player.GetBlockArrayLenght() > 0) {
				_blockCollider.enabled = false;
				_parentRender.enabled = true;
			}
		}
	}
}
