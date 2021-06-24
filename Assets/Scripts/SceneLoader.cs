using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private GameObject _sceneObject;
	[SerializeField] private Vector3 _startX, _finishX, _finishZ;
	[SerializeField] private GameObject[] _spawnObjects;
    void Start() {
		GenerateWorld();
    }

    void Update() {
        
    }

	private void GenerateWorld()
	{
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
}
