using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {
	[SerializeField] private Material[] _availableMaterials;
	private MeshRenderer _playerMaterial;
	[SerializeField] private Transform _playerBack;
	private float _endPoint; // Спина
	private float _step = 0.3f; // Расстояние между объектами
	private float _pointOnBack; // Точка, на которую добавится объект
	private List<BlockChecker> _blocksOnPlayer = new List<BlockChecker>();
	public Transform PlayerBack {
		get {
			return _playerBack;
		}
	}

	public Vector3 Points {
		get {
			_playerBack.transform.position = new Vector3(_playerBack.transform.position.x, _endPoint + _pointOnBack, _playerBack.transform.position.z);
			return new Vector3(_playerBack.transform.position.x, _endPoint + _pointOnBack, _playerBack.transform.position.z);
		}
	}

	public void AddArray(BlockChecker block) {
		_blocksOnPlayer.Add(block);
		_pointOnBack = _step * _blocksOnPlayer.Count;
	}
	public Material PlayerMaterial {
		get { return _playerMaterial.material; }
		private set { }
	}
    private void Start() {
		Init();
		_endPoint = _playerBack.transform.position.y;
	}

	private void Init() {
		_playerMaterial = GetComponent<MeshRenderer>();
		var randomMaterial = Random.Range(0, _availableMaterials.Length);
		_playerMaterial.material = _availableMaterials[randomMaterial];
	}

	public int GetBlockArrayLenght()
	{
		return _blocksOnPlayer.Count;
	}
}
