using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Car1 : MonoBehaviour {

    string Frase = "Sin frames ";
    int Contador = 0;
    int posiciconInt = 0;
    int metaInt = 150;
    int puntos = 0;
    float metaPos = 21.0f;
    bool end = false;
    Vector3 PosInicial;
    Quaternion oriInicial;
    public int Player;
    public string PlayerName;
    public float Velocidad = 0.1f;
    public KeyCode TeclaEntrada = KeyCode.Space;
    public KeyCode TeclaLeft = KeyCode.LeftArrow;
    public KeyCode TeclaRight = KeyCode.RightArrow;
    public GameObject Coche1;
    public GameObject Rival;
    public GameObject Canvas;
    public Text TextSalida;
    public Text TextParrilla;
    public Text TextMeta;
    

	// Use this for initialization
	void Start () {
        //Debug.Log("Se ha llamado al metodo Start");
        posiciconInt = 0;
        PosInicial = this.gameObject.transform.localPosition;
        oriInicial = this.gameObject.transform.localRotation;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 Desplazamiento = new Vector3(Velocidad,0,0);
        Vector3 Retroceso = new Vector3(-Velocidad,0,0);

// TEST
        Vector3 GiroL = new Vector3(0, 0, 5f);
        Vector3 GiroR = new Vector3(0, 0, -5f);

        //Coche1.GetComponent<Transform>().position

        if (Contador == 30) {
            TextSalida.text = "3";
        }
        if (Contador == 60)
        {
            TextSalida.text = "2";
        }
        if (Contador == 90)
        {
            TextSalida.text = "1";
        }
        if (Contador == 120)
        {
            TextSalida.text = "START";
        }
        if (Contador == 150)
        {
            TextSalida.text = "";
        }

        if (end == true && Velocidad > 0.00f)
        {
            Rival.GetComponent<Car1>().Velocidad = 0.0f;
            this.GetComponent<Car1>().Velocidad = 0.0f;
        } else
        {
            if (Rival.GetComponent<Transform>().position.y < this.GetComponent<Transform>().position.y)
            {
                TextParrilla.text = "1. " + PlayerName + " \n 2. " + Rival.GetComponent<Car1>().PlayerName;

            }

            if (Input.GetKeyDown(TeclaEntrada) && Contador > 150)
            {

                if (Input.GetKey(TeclaLeft))
                {
                    transform.Rotate(GiroL);
                }
                if (Input.GetKey(TeclaRight))
                {
                    transform.Rotate(GiroR);
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Retroceso);
                    posiciconInt--;
                    puntos--;
                }
                else
                {
                    transform.Translate(Desplazamiento);
                    posiciconInt++;
                    puntos++;
                }


            }

            // TEST

        }



//  META POR PULSACIONES
        /*
               if (posiciconInt >= metaInt)
               {
                   Debug.Log("El jugador " + Player + " ha llegado a la Meta!");
               }
        */

// META POR POSICION

        // MENSAJE DE VICTORIA
        /*

         if (GetComponent<Transform>().position.y >= metaPos)
         {
             TextMeta.text = "¡VICTORIA! El jugador " + PlayerName + " ha ganado";
             Rival.GetComponent<Car1>().Velocidad = 0.00f;
             Debug.Log("El jugador " + PlayerName + " ha llegado a la Meta!");
         }

         */

        //Debug.Log(GetComponent<Transform>().position);

        Contador = Contador + 1;

            ExecuteEvents.Execute<iMisEventosCanvas>(Canvas, null, (x, y) => x.MostrarPuntuacion(puntos, Player));

    }


    // META POR COLISION (TRIGGER)

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Meta")
        {
            TextMeta.text = "¡VICTORIA! El jugador " + PlayerName + " ha ganado";
            Debug.Log("El objeto " + PlayerName + "ha colisionado con " + collision.gameObject.name);
            Debug.Log("El jugador " + PlayerName + " ha llegado a la Meta!");
            end = true; 
        }

        if (collision.gameObject.tag == "Margen")
        {
            transform.position = PosInicial;
            transform.localRotation = oriInicial;
            puntos = 0;
        }

    }



}
