using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldResumption : MonoBehaviour
{
	[SerializeField] private BlockChecker[] _blocks;
	private static BlockChecker[] _spawnBlocks;
	private static List<Vector3> _emptySlots = new List<Vector3>();
	private static float _timer = 0;

	private void Start()
	{
		_spawnBlocks = _blocks;
		
	}

	public static void AddObject(Vector3 point) {
		_emptySlots.Add(point);
	}

	public static void GeneratingObjects(string mat) {
		foreach (var i in _emptySlots) {
			int randomNum = Random.Range(0, _spawnBlocks.Length);
			Instantiate(_spawnBlocks[randomNum], i, Quaternion.Euler(0, 90, 0));
		}
		_emptySlots.Clear();
	}
}
