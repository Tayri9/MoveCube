using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public enum EstadosSelector
    {
        EnEspera,
        ObjetoSeleccionadoMover,
        ObjetoSeleccionadoRotar,
        ObjetoSeleccionadoEscalar,
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
            /*case EstadosSelector.EnEspera:
                estadoActual = EstadosSelector.ObjetoSeleccionadoMover;
                break;*/

            case EstadosSelector.ObjetoSeleccionadoMover:
                SeleccionarObjeto();
                break;

            case EstadosSelector.ObjetoSeleccionadoEscalar:
                SeleccionarObjeto();
                break;

            case EstadosSelector.ObjetoSeleccionadoRotar:
                SeleccionarObjeto();
                break;

            case EstadosSelector.Mover:
                MoverObjeto();
                break;

            case EstadosSelector.Rotar:
                RotarObjeto();
                break;

            case EstadosSelector.Escalar:
                EscalarObjeto();
                break;

            case EstadosSelector.Soltar:
                SoltarObjeto();
                break;
        }
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
                    

                    switch (estadoActual)
                    {
                        case EstadosSelector.ObjetoSeleccionadoMover:
                            estadoActual = EstadosSelector.Mover;
                            break;

                        case EstadosSelector.ObjetoSeleccionadoRotar:
                            estadoActual = EstadosSelector.Rotar;
                            break;

                        case EstadosSelector.ObjetoSeleccionadoEscalar:
                            estadoActual = EstadosSelector.Escalar;
                            break;
                    }
                    
                }
            }
        }
    }

    void MoverObjeto()
    {
        selectedObject.SetActive(false);
        //Cursor.visible = false;

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
        //Cursor.visible = true;
    }

    void RotarObjeto()
    {
        selectedObject.SetActive(false);

        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(rayo, out hitInfo))
        {
            selectedObject.SetActive(true);
            Vector2 posicionRaton = Input.mousePosition;
            Vector2 posicionModificada = posicionRaton - Input.mousePosition;
            posicionRaton = Input.mousePosition;

            selectedObject.transform.position = hitInfo.point; //+ Vector3.up * selectedObject.transform.localScale.y / 2;
        }
        selectedObject.SetActive(true);

        if (Input.GetMouseButtonUp(0))
        {
            estadoActual = EstadosSelector.Soltar;
        }
    }

    void EscalarObjeto()
    {
        if (Input.GetMouseButtonUp(1))
        {
            selectedObject.transform.localScale = selectedObject.transform.localScale * Input.mouseScrollDelta;
        }

        if (Input.GetMouseButtonUp(0))
        {
            estadoActual = EstadosSelector.Soltar;
        }
    }

    public void BotonMover()
    {
        estadoActual = EstadosSelector.ObjetoSeleccionadoMover;
    }

    public void BotonRotar()
    {
        estadoActual = EstadosSelector.ObjetoSeleccionadoRotar;
    }

    public void BotonEscalar()
    {
        estadoActual = EstadosSelector.ObjetoSeleccionadoEscalar;
    }
}
