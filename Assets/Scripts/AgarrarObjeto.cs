using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public bool esAgarrable = true; // Indica si el objeto es agarrable

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject; // Asigna el objeto agarrable al script PickUpObject del jugador
            AudioManager.Instance.Play2D("Detectar"); // Reproducir el sonido de detección al entrar en la zona de interacción
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null; // Limpia la referencia al objeto agarrable en el script PickUpObject del jugador
            AudioManager.Instance.Play2D("Salir"); // Reproducir el sonido de perder al salir de la zona de interacción
        }
    }
}
