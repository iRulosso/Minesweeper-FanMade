using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boton : MonoBehaviour, IPointerClickHandler
{
    Parcela parcela;
    private void Start()
    {
        parcela = GetComponentInParent<Parcela>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            parcela.Boton();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            parcela.Bandera();
        }
    }
}
