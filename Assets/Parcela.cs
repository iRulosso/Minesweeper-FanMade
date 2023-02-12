using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parcela : MonoBehaviour
{
    public bool bomba;
    public Sprite parcelaSpt;
    public Sprite bombaSpt;
    public Sprite[] numeroSpt;
    public Sprite bandera;
    public int bombasCerca;
    public GameManager manager;
    public bool botonTocado;
    public GameObject boton;
    public List<GameObject> parcelasCerca;
    public bool banderaPuesta;

    private void Inicio()
    {
        parcelasCerca = new List<GameObject>();
    }
    private void Update()
    {
        if (bomba)
            gameObject.GetComponent<Image>().sprite = bombaSpt;

        switch(bombasCerca)
        {
            case 0:
                if(!bomba)
                    gameObject.GetComponent<Image>().sprite = numeroSpt[8];
                break;
            case 1:
                gameObject.GetComponent<Image>().sprite = numeroSpt[0];
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = numeroSpt[1];
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = numeroSpt[2];
                break;
            case 4:
                gameObject.GetComponent<Image>().sprite = numeroSpt[3];
                break;
            case 5:
                gameObject.GetComponent<Image>().sprite = numeroSpt[4];
                break;
            case 6:
                gameObject.GetComponent<Image>().sprite = numeroSpt[5];
                break;
            case 7:
                gameObject.GetComponent<Image>().sprite = numeroSpt[6];
                break;
            case 8:
                gameObject.GetComponent<Image>().sprite = numeroSpt[7];
                break;
        }
    }

    public void Bandera()
    {
        if (!banderaPuesta)
        {
            banderaPuesta = true;
            manager.banderasRestantes--;
            boton.gameObject.GetComponent<Image>().sprite = bandera;
        }
        else
        {
            manager.banderasRestantes++;
            banderaPuesta = false;
            boton.gameObject.GetComponent<Image>().sprite = parcelaSpt;
        }
    }

    public void LimpiarVacias()
    {
        if (bombasCerca == 0)
        {
            foreach (GameObject obj in parcelasCerca)
            {
                if (!obj.GetComponent<Parcela>().botonTocado)
                    obj.GetComponent<Parcela>().manager.parcelasRestantes--;
                obj.GetComponent<Parcela>().parcelasCerca.Remove(gameObject);
                obj.GetComponent<Parcela>().botonTocado = true;
                obj.GetComponent<Parcela>().boton.SetActive(false);
            }
            foreach (GameObject obj in parcelasCerca)
            {
                if (obj.GetComponent<Parcela>().bombasCerca == 0)
                {
                    obj.GetComponent<Parcela>().LimpiarVacias();
                }
            }
        }

    }
    public void Boton()
    {
        if (!banderaPuesta)
        {
            boton.SetActive(false);
            botonTocado = true;
            if (bomba)
                Perder();
            else
                manager.parcelasRestantes--;
            LimpiarVacias();
        }
    }

    public void Perder()
    {
        GameObject[] botones = GameObject.FindGameObjectsWithTag("boton");

        foreach (GameObject obj in botones)
            obj.SetActive(false);

        manager.cara.sprite = manager.caraSpt[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bomba)
            parcelasCerca.Add(collision.gameObject);
        if (collision.gameObject.GetComponent<Parcela>().bomba == true && bomba == false)
        {
            bombasCerca++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!bomba)
            parcelasCerca.Remove(collision.gameObject);
        if (collision.gameObject.CompareTag("parcela") && collision.gameObject.GetComponent<Parcela>().bomba == true && bomba == false)
        {
            bombasCerca--;
        }
    }
}
