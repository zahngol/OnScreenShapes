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
				shapeRectTransform.pivot = new Vector2(0f,0f);
				shapeRectTransform.anchoredPosition = new Vector2(
					shapeRectTransform.anchoredPosition.x - shapeRectTransform.rect.width / 2, 
					shapeRectTransform.anchoredPosition.y - shapeRectTransform.rect.height / 2);
				break;
			case Corner.bottomLeft:
				shapeRectTransform.pivot = new Vector2(1f,1f);
				shapeRectTransform.anchoredPosition = new Vector2(
					shapeRectTransform.anchoredPosition.x + shapeRectTransform.rect.width / 2, 
					shapeRectTransform.anchoredPosition.y + shapeRectTransform.rect.height / 2);
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
			switch (corner)
			{
				case Corner.topLeft:
					shapeRectTransform.sizeDelta = new Vector2(
						shapeRectTransform.position.x - data.position.x,
						data.position.y - shapeRectTransform.position.y);
					break;
				case Corner.topRight:
					shapeRectTransform.sizeDelta = new Vector2(
						data.position.x - shapeRectTransform.position.x,
						data.position.y - shapeRectTransform.position.y);
					break;
				case Corner.bottomLeft:
					shapeRectTransform.sizeDelta = new Vector2(
						shapeRectTransform.position.x - data.position.x,
						shapeRectTransform.position.y - data.position.y);
					break;
				case Corner.bottomRight:
					shapeRectTransform.sizeDelta = new Vector2(
						data.position.x - shapeRectTransform.position.x,
						shapeRectTransform.position.y - data.position.y);
					break;
			}
		}
	}
}
