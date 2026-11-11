using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OscProcess : MonoBehaviour
{
    public OSCReceiver oscReceiver;
    public OSCTransmitter oscTransmitter;
    public int betaInMin = 0;
    public int betaInMax = 1023;
    public float betaOutMin = 0.0f;
    public float betaOutMax = 1.0f;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        oscReceiver.Bind("/enc/rot", TraiterMessageEncRot);
        oscReceiver.Bind("/enc/but", TraiterMessageEncBut);
    }

    void TraiterMessageEncRot(OSCMessage message)
    {
        // Traiter un entier et l’appliquer à une propriété (flux continu)

        // Récupérer la valeur du premier argument en taant qu’entier :
        int valeur = message.Values[0].IntValue;

        // Deboguer
        // Debug.Log("Reçu : " + message.Address + " " + valeur);

        // Ajustement de la valeur
        float ajustee = (
            ((float)valeur - betaInMin) / (betaInMax - betaInMin) * (betaOutMax - betaOutMin) + betaOutMin
        );

        // DESTINATION
        player.AddTorque(ajustee);
    }

    void TraiterMessageEncBut(OSCMessage message)
    {

        // Traiter un entier booléen (évènement discret)

        // Récupérer la valeur du premier argument en taant qu’entier :
        int valeur = message.Values[0].IntValue;

        // Deboguer
        // Debug.Log("Reçu : " + message.Address + " " + valeur);

        // Traiter la valeur
        if (valeur == 0)
        {
            // Si nécéssaire, appeler une fonction ici
        }
        else
        {
            // Si nécéssaire, appeler une fonction ici
            player.Jump();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
