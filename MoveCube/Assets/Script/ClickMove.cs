using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    private GameObject selectedObject;

    void Update()
    {
        if (Input.touchCount>=1 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
        {
            if (selectedObject == null)
            {
                Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(rayo, out hitInfo))
                {                    
                    if (hitInfo.collider != null)
                    {                        
                        if (!hitInfo.collider.CompareTag("Object"))
                        {                       
                            return;
                        }
                                                
                        selectedObject = hitInfo.collider.gameObject;
                        selectedObject.SetActive(false);
                        
                        Cursor.visible = false;
                    }
                }
            }
            else
            {
                Ray rayo2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo2;
                if (Physics.Raycast(rayo2, out hitInfo2))
                {
                    selectedObject.SetActive(true);
                    selectedObject.transform.position = hitInfo2.point * selectedObject.transform.localScale.y/2;
                }
                selectedObject = null;
                Cursor.visible = true;
            }
        }
        
        if (selectedObject != null)
        {
            selectedObject.SetActive(false);
            Ray rayo2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo2;
            if (Physics.Raycast(rayo2, out hitInfo2))
            {                
                selectedObject.SetActive(true);
                selectedObject.transform.position = hitInfo2.point + Vector3.up * selectedObject.transform.localScale.y/2;
            }
            selectedObject.SetActive(true);
        }
    }
   
}
