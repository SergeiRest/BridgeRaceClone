using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    private void TryAddBlock(MeshRenderer playerRender, MeshRenderer obj)
	{
		if (playerRender.material.name != obj.material.name)
			return;
		Debug.Log("True");
	}
}
