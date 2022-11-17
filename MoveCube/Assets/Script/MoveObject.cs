using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public enum EstadosSelector
    {
        EnEspera,
        ObjetoSeleccionado,
        Soltar,
        Mover,
        Escalar,
        Rotar,
        //Los estados que necesitemos
    }

    [SerializeField]
    EstadosSelector estadoActual = EstadosSelector.EnEspera;

    GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (estadoActual)
        {
            case EstadosSelector.EnEspera:
                estadoActual = EstadosSelector.ObjetoSeleccionado;
                break;

            case EstadosSelector.ObjetoSeleccionado:
                SeleccionarObjeto();
                break;

            case EstadosSelector.Mover:
                MoverObjeto();
                break;

            case EstadosSelector.Soltar:
                SoltarObjeto();
                break;
        }


        /*
        //if (Input.GetMouseButtonUp(0))
        //{
            if(selectedObject == null)
            {
                SeleccionarObjeto();
                /*
                Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;                
                if (Physics.Raycast(rayo, out hitInfo))
                {
                    if (hitInfo.collider.CompareTag("Object"))
                    {
                        selectedObject = hitInfo.collider.gameObject;
                        estadoActual = EstadosSelector.Mover;
                        selectedObject.SetActive(false);
                        Cursor.visible = false;
                    }                    
                }
            } else
            {
                SoltarObjeto();
            }
        //}

        if(selectedObject != null)
        {
            MoverObjeto();
        }*/
    }
    
    void SeleccionarObjeto()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Object"))
                {
                    selectedObject = hitInfo.collider.gameObject;
                    estadoActual = EstadosSelector.Mover;
                    selectedObject.SetActive(false);
                    Cursor.visible = false;
                }
            }
        }
    }

    void MoverObjeto()
    {
        selectedObject.SetActive(false);

        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(rayo, out hitInfo))
        {
            selectedObject.SetActive(true);
            selectedObject.transform.position = hitInfo.point + Vector3.up * selectedObject.transform.localScale.y / 2; 
        }
        selectedObject.SetActive(true);
        
        if (Input.GetMouseButtonUp(0))
        {
            estadoActual = EstadosSelector.Soltar;
        }
    }

    void SoltarObjeto()
    {
        selectedObject = null;
        estadoActual = EstadosSelector.EnEspera;
        Cursor.visible = true;
    }
}
