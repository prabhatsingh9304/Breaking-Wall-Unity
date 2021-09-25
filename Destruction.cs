using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
	private Collider[] pieces;

	public float radius;
	public float power;
	public LayerMask explosionLayers;
	public void destruction(Vector3 raycastHitPoint)
	{
		pieces = Physics.OverlapSphere(raycastHitPoint, radius, explosionLayers);

		foreach (Collider piece in pieces)
		{
			piece.gameObject.AddComponent<Rigidbody>();
			piece.GetComponent<Rigidbody>().mass = 600;
			piece.GetComponent<Rigidbody>().isKinematic = false;
            piece.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 5;
			piece.GetComponent<Rigidbody>().AddExplosionForce(power, raycastHitPoint, radius, 1, ForceMode.Impulse);
		}
	}
}
