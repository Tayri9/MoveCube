using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    private GameObject selectedObject;
    Vector3 mOffset;

    void Update()
    {
        //Condicional de click izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            //Condicional de que el objeto clickado no es nulo
            if (selectedObject == null)
            {
                Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(rayo, out hitInfo))
                {
                    //Condicional de que el collider no es nulo
                    if (hitInfo.collider != null)
                    {
                        //Condicional de que el objeto clickado tiene la tag Clickable
                        if (!hitInfo.collider.CompareTag("Object"))
                        {                           
                            //Si no la tiene sale de la función
                            return;
                        }

                        //Convertimos nuestro objeto clickado en el selectedObject
                        selectedObject = hitInfo.collider.gameObject;
                        selectedObject.SetActive(false);

                        //Desabilitamos la vista del cursor
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
                    mOffset = new Vector3(0f, selectedObject.transform.position.y, -0.75f);
                    var tmpPos = mOffset;

                    selectedObject.SetActive(true);
                    selectedObject.transform.position = hitInfo2.point + tmpPos;
                }
                selectedObject = null;
                Cursor.visible = true;
            }
        }

        //Condicional de que el objeto clickado no es igual a nulo
        if (selectedObject != null)
        {
            Ray rayo2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo2;
            if (Physics.Raycast(rayo2, out hitInfo2))
            {
                //mOffset = new Vector3(0f, selectedObject.transform.position.y, -0.75f);
                //var tmpPos = mOffset;
                
                selectedObject.SetActive(true);
                selectedObject.transform.position = hitInfo2.point;// + tmpPos;
            }

        }
    }
   
}
