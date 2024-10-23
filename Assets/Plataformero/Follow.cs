using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{  
	public Transform target;   //player
	public float smooth = 4f;   // velocidad del movimiento
	Vector3 newdist; 
	void Start () {
	newdist = transform.position - target.position;
	}
	void FixedUpdate () { 
	Vector3 posobj = target.position + newdist;
	transform.position = Vector3.Lerp    //lerp = interpolar
	(transform.position, posobj, smooth * Time.deltaTime);
	} }