using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    private static SaveData instance;


    public int cantBombas = 20;
    public int cantParcelas;

    public int test = 0;

    private void Awake()
    {
        Screen.SetResolution(342, 607, FullScreenMode.Windowed);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
    public void ActualizarBombas()
    {
        Slider cantBombasTxt = GameObject.Find("cantBombasTxt").GetComponent<Slider>();
        TextMeshProUGUI bombasTxt = GameObject.Find("bombasTxt").GetComponent<TextMeshProUGUI>();
        bombasTxt.text = cantBombasTxt.value.ToString();
        cantBombas = (int)Mathf.Round(cantBombasTxt.value);
    }
}
