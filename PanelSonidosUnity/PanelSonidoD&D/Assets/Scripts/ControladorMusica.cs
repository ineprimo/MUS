using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMusica : MonoBehaviour
{

    [SerializeField] private Slider _intensidadSlider;

    FMODUnity.StudioEventEmitter _musica;

    private void Start()
    {

        _musica = GetComponent<FMODUnity.StudioEventEmitter>();

        float intensidadInicio; 
        _musica.EventInstance.getParameterByName("Intensidad", out intensidadInicio);

        _intensidadSlider.value = intensidadInicio;
    }

    public void cambiarBioma(int bioma)
    {

        _musica.EventInstance.setParameterByName("Bioma", bioma);

    }

    public void cambiarSentimiento(int sentimiento)
    {

        _musica.EventInstance.setParameterByName("Sentimiento", sentimiento);

    }

    public void cambiarIntensidad()
    {

        _musica.EventInstance.setParameterByName("Intensidad", _intensidadSlider.value);

    }


}
