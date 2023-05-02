using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceTower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    Camera camera;
    public Vector3 big = new Vector3(1.1f, 1.1f, 1.1f);
    public Vector3 normal = new Vector3(1, 1, 1);
    public Image towerCard;
    public bool hover;

    public GameObject towerType;
    public GameObject currentDrag;


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
        //Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); < I dont think I need this anymore.

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); // or 5f for z axis.
        currentDrag = Instantiate(towerType, worldMousePosition, Quaternion.identity);

        towerCard.raycastTarget = false;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        towerCard.raycastTarget = true;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        currentDrag.transform.position = worldMousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            //Check if object hit is a node box thingy
            Vector3 position = hit.transform.position;
            currentDrag.transform.position = position;
        }

    }
}
