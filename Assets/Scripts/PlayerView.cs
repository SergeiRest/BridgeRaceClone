using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {
	[SerializeField] Material[] _availableMaterials;
	private MeshRenderer _playerMaterial;
    void Start() {
		Init();
    }

	private void Init() {
		_playerMaterial = GetComponent<MeshRenderer>();
		var randomMaterial = Random.Range(0, _availableMaterials.Length);
		_playerMaterial.material = _availableMaterials[randomMaterial];
	}
}
