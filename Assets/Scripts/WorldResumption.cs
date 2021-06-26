using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResumption : MonoBehaviour
{
	[SerializeField] BlockChecker[] _blocks;
	private static BlockChecker[] _spawnBlocks;
	private static List<Vector3> _emptySlots = new List<Vector3>();
	private bool _isGenerationStarted = false;
	private static float _timer = 0;

	private void Start()
	{
		_spawnBlocks = _blocks;
	}

	public static void AddObject(Vector3 point) {
		_emptySlots.Add(point);
	}

	public static void GeneratingObjects() {
		foreach (var i in _emptySlots) {
			int randomNum = Random.Range(0, _spawnBlocks.Length);
			Instantiate(_spawnBlocks[randomNum], i, Quaternion.Euler(0, 90, 0));
		}
		_emptySlots.Clear();
	}
}
