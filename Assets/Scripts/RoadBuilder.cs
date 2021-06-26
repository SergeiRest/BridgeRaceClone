﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadType
{
	Green,
	Red,
	Yellow
}
public class RoadBuilder : MonoBehaviour
{
	[SerializeField] private Collider _blockCollider;
	[SerializeField] private MeshRenderer _parentRender;
	private string _roadType = null;
	private void OnTriggerEnter(Collider other)
	{
		WorldResumption.GeneratingObjects();
		if (other.gameObject.TryGetComponent(out PlayerView player)) {
			if (player.GetArrayLenght() == 0) {
				return;
			}

			if (_roadType != player.PlayerMaterial.name)
			{
				_roadType = player.PlayerMaterial.name;
				Debug.Log("Penis");
				Debug.Log(_parentRender.material.name);
				Debug.Log($"Скин игрока: {player.PlayerMaterial.name}");
				_blockCollider.enabled = false;
				_parentRender.enabled = true;
				_parentRender.material = player.PlayerMaterial;
				player.TryRemoveBlock();
			}
		}
	}
}
