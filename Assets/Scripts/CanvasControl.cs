using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface iMisEventosCanvas : IEventSystemHandler
{
    // Esta funcion se puede invocar via messaging system
    void MostrarPuntuacion(int valor, int player);
}

public class CanvasControl : MonoBehaviour, iMisEventosCanvas
{
    public Text p1Texto;
    public Text p2Texto;

    public void MostrarPuntuacion(int valor, int player)
    {
        if (player == 1)
        {
            p1Texto.text = "PUNTOS: " + valor;
        }
        else if (player == 2)
        {
            p2Texto.text = "PUNTOS: " + valor;
        }

    }



    // Use this for initialization
    // void Start () { }

    // Update is called once per frame
    // void Update () { }

}
