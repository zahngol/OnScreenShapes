using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateShape : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	private bool isPointerDown;

	public void OnPointerDown(PointerEventData data)
	{
		isPointerDown = true;
	}

	public void OnPointerUp(PointerEventData data)
	{
		isPointerDown = false;
	}

	public void OnDrag(PointerEventData data)
	{
		if (isPointerDown)
		{
			float angle = Mathf.Atan2(data.position.y-transform.parent.position.y, data.position.x-transform.parent.position.x) * Mathf.Rad2Deg;
			Vector3 temp = new Vector3 (
				transform.parent.rotation.eulerAngles.x, 
				transform.parent.rotation.eulerAngles.y, 
				angle-90);
			transform.parent.rotation = Quaternion.Euler(temp);
		}
	}
}
