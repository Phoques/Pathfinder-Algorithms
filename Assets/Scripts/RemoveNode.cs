using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveNode : MonoBehaviour
{
    public GameObject clickedCube;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickToDestroy();

        }
    }


    public void ClickToDestroy()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            clickedCube = hit.collider.gameObject;
            clickedCube.transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("I hit the Cube");
        }
    }
}
