using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class snake : MonoBehaviour
{
	private snake next;
	static public Action<String> hit;
	
	public void Setnext(snake IN)
	{
		next = IN;
	}
	
	public snake Getnext()
	{
		return next;
	}
	
	public void RemoveTail()
	{
		Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(hit != null)
		{
			hit(other.transform.tag);
		}
		if(other.tag == "food")
		{
			Destroy(other.gameObject);
		}
		if(other.tag == "food2")
		{
			Destroy(other.gameObject);
		}
	}
    
}
