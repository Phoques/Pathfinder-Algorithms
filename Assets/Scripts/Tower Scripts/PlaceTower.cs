using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceTower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Camera camera;
    public Vector3 big = new Vector3(1.1f, 1.1f, 1.1f);
    public Vector3 normal = new Vector3(1, 1, 1);
    public Image towerCard;
    public bool hover;

    public GameObject towerType;


    private void Start()
    {
        camera = Camera.main;
    }


    private void Update()
    {
        /*if (towerType != null)
        {
            towerType = target;
            target.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 1f);
        }*/
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        this.transform.localScale = big;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
        this.transform.localScale = normal;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //towerType = gameObject; < this brings the UI card with it, not the instantiated tower.
        Instantiate(towerType, pos, Quaternion.identity);


        towerCard.raycastTarget = false;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        towerCard.raycastTarget = true;
    }
}
