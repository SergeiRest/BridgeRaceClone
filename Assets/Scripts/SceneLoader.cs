using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private GameObject _sceneObject;
	[SerializeField] private Vector3 _startX, _finishX, _finishZ;
	[SerializeField] private BlockChecker[] _spawnObjects;
	[SerializeField] private GameObject _road;
    private void Awake() {
		GenerateWorld();
		GenerateRoad();
    }

	private void GenerateWorld() {
		Instantiate(_sceneObject, Vector3.zero, Quaternion.identity);
		for (float currentPositionZ = _startX.x; currentPositionZ < _finishZ.z; currentPositionZ += 1.5f)
		{
			for (float currentPositionX = _startX.x; currentPositionX < _finishX.x; currentPositionX += 1.25f)
			{
				int randomObj = Random.Range(0, _spawnObjects.Length);
				Instantiate(_spawnObjects[randomObj], new Vector3(currentPositionX, 0.25f, currentPositionZ), Quaternion.Euler(0, 90, 0));
			}
		}
	}

	private void GenerateRoad() {
		int num = Random.Range(15, 25);
		int count = 0;
		Vector3 spawn = new Vector3(-1, 0.125f, 7.76f);
		while(count <= num) {
			Instantiate(_road, spawn, Quaternion.Euler(0, 90, 0));
			spawn += new Vector3(0, 0.20f, 0.5f);
			count++;
		}
		Instantiate(_sceneObject, spawn += new Vector3(0, 0, _sceneObject.transform.localScale.z / 2), Quaternion.identity);
	}
}
