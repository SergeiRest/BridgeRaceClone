using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResumption : MonoBehaviour
{
	private static List<Vector3> _emptySlots = new List<Vector3>();

	public static void AddObject(Vector3 point) {
		_emptySlots.Add(point);
	}

	public static void GeneratingObjects(params GameObject[] blocks) {
		if (_emptySlots.Count == 0)
			return;

		foreach(var obj in _emptySlots) {
			int num = Random.Range(0, blocks.Length);
			Instantiate(blocks[num], obj, Quaternion.identity);
			_emptySlots.Remove(obj);
		}
	}
}
