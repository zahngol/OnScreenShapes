using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleShape : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	public enum Corner
	{
		topRight,
		topLeft,
		bottomRight,
		bottomLeft
	}

	public Corner corner;
	
	private bool isPointerDown;

	private RectTransform shapeRectTransform;

	private Vector2 originalPosition;
	
	private void Start()
	{
		shapeRectTransform = transform.parent.parent.GetComponent<RectTransform>();
		Debug.Log(shapeRectTransform.rect);
		Debug.Log(shapeRectTransform.position);
		Debug.Log(shapeRectTransform.anchoredPosition);
	}

	public void OnPointerDown(PointerEventData data)
	{
		isPointerDown = true;
		originalPosition = shapeRectTransform.anchoredPosition;
		switch (corner)
		{
			case Corner.topLeft:
				shapeRectTransform.pivot = new Vector2(1f,0f);
				shapeRectTransform.anchoredPosition = new Vector2(
					shapeRectTransform.anchoredPosition.x + shapeRectTransform.rect.width / 2, 
					shapeRectTransform.anchoredPosition.y - shapeRectTransform.rect.height / 2);
				break;
			case Corner.topRight:
				shapeRectTransform.pivot = new Vector2(1f,1f);
				shapeRectTransform.anchoredPosition = new Vector2(
					shapeRectTransform.anchoredPosition.x + shapeRectTransform.rect.width / 2, 
					shapeRectTransform.anchoredPosition.y + shapeRectTransform.rect.height / 2);
				break;
			case Corner.bottomLeft:
				shapeRectTransform.pivot = new Vector2(0,0);
				shapeRectTransform.anchoredPosition = new Vector2(
					shapeRectTransform.anchoredPosition.x - shapeRectTransform.rect.width / 2, 
					shapeRectTransform.anchoredPosition.y - shapeRectTransform.rect.height / 2);
				break;
			case Corner.bottomRight:
				shapeRectTransform.pivot = new Vector2(0f, 1f);
				shapeRectTransform.anchoredPosition = new Vector2(
					shapeRectTransform.anchoredPosition.x - shapeRectTransform.rect.width / 2, 
					shapeRectTransform.anchoredPosition.y + shapeRectTransform.rect.height / 2);
				break;
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		shapeRectTransform.pivot = new Vector2(0.5f, 0.5f);
		shapeRectTransform.anchoredPosition = originalPosition;
		isPointerDown = false;
	}

	public void OnDrag(PointerEventData data)
	{
		if (isPointerDown)
		{
			
		}
	}
}
