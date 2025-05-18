using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorMusica : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI[] _textosBiomas;

    [SerializeField] private TextMeshProUGUI[] _textosSentimientos;

    [SerializeField] private Slider _intensidadSlider;

    [SerializeField] private Slider _volumenSlider;

    [SerializeField] private GameObject _startButton;

    [SerializeField] private bool _pausa = false;


    FMODUnity.StudioEventEmitter _musica;

    private void Start()
    {

        _musica = GetComponent<FMODUnity.StudioEventEmitter>();

        _musica.EventInstance.setPaused(_pausa);

        float intensidadInicio; 
        _musica.EventInstance.getParameterByName("Intensidad", out intensidadInicio);

        _intensidadSlider.value = intensidadInicio;

        float volumenInicio;
        _musica.EventInstance.getVolume(out volumenInicio);

        _volumenSlider.value = volumenInicio;
    }

    public void cambiarBioma(int bioma)
    {

        _musica.EventInstance.setParameterByName("Bioma", bioma);

        for(int i = 0; i < _textosBiomas.Length; i++)
        {

            _textosBiomas[i].color = Color.white;

        }

        _textosBiomas[bioma].color = Color.yellow;

    }

    public void cambiarSentimiento(int sentimiento)
    {

        _musica.EventInstance.setParameterByName("Sentimiento", sentimiento);

        for (int i = 0; i < _textosSentimientos.Length; i++)
        {

            _textosSentimientos[i].color = Color.white;

        }

        _textosSentimientos[sentimiento].color = Color.yellow;

    }

    public void cambiarIntensidad()
    {

        _musica.EventInstance.setParameterByName("Intensidad", _intensidadSlider.value);

    }

    public void cambiarVolumen()
    {

        _musica.EventInstance.setVolume(_volumenSlider.value);

    }

    public void controlPausaMusica()
    {
        _pausa = !_pausa;
        _musica.EventInstance.setPaused(_pausa);

    }

    public void salirAplicaion()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {

            _musica.EventInstance.setPaused(true);

        }
        else
        {
            Application.Quit();
        }

    }

    public void empezarSesion()
    {

        _musica.EventInstance.setPaused(false);
        _startButton.SetActive(false);
        _pausa = false;

    }

}
