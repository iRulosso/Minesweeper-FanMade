using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] grilla;
    public Sprite[] caraSpt; //0-jugando 1-perdiste 2-ganaste
    public Image cara;
    public int cantBombas = 30;
    public int parcelasRestantes;
    public TextMeshProUGUI banderasTXt;
    public int banderasRestantes;
    public TextMeshProUGUI bombasTxt;

    int bombasPuestas = 0;

    public SaveData data;
    public Slider cantBombasTxt;
    public Slider tamañoGrillaTxt;

    private void Awake()
    {
        data = GameObject.FindGameObjectWithTag("manager").GetComponent<SaveData>();
        cantBombas = data.cantBombas;
    }

    private void Start()
    {
        grilla = GameObject.FindGameObjectsWithTag("parcela");
        if (bombasPuestas > 0)
        {
            foreach (GameObject obj in grilla)
            {
                obj.GetComponent<Parcela>().bomba = false;
                obj.GetComponent<Parcela>().bombasCerca = 0;
                obj.GetComponent<Parcela>().parcelasCerca = new List<GameObject>();
                obj.GetComponent<Parcela>().banderaPuesta = false;
                obj.GetComponent<Parcela>().botonTocado = false;
                obj.GetComponent<Parcela>().boton.SetActive(true);
            }
        }
        bombasPuestas = 0;
        do
        {
            int numeroRandom = Random.RandomRange(0, grilla.Length - 1);

            if (grilla[numeroRandom].GetComponent<Parcela>().bomba == false)
            {
                grilla[numeroRandom].GetComponent<Parcela>().bomba = true;
                bombasPuestas++;
            }
        } while (bombasPuestas < cantBombas);
        parcelasRestantes = grilla.Length - cantBombas;
        banderasRestantes = cantBombas;
    }

    private void Update()
    {
        if (parcelasRestantes <= 0)
        {
            Debug.Log("GANASTE!");
            cara.sprite = caraSpt[2];
        }

        banderasTXt.text = banderasRestantes.ToString();
    }

   public void IniciarJuego()
    {
        SceneManager.LoadScene("Juego");
    }

   public void ActualizarBombas()
    {
        bombasTxt.text = cantBombasTxt.value.ToString();
        data.cantBombas = (int)Mathf.Round(cantBombasTxt.value);
    }
}
