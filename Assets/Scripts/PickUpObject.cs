using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform ZonadeInteraccion;

    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<AgarrarObjeto>().esAgarrable == true && PickedObject == null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject = ObjectToPickUp; // Asigna el objeto agarrable al objeto recogido
                PickedObject.GetComponent<AgarrarObjeto>().esAgarrable = false; // Marca el objeto como no agarrable
                PickedObject.transform.SetParent(ZonadeInteraccion); // Establece el objeto recogido como hijo de la zona de interacción
                PickedObject.transform.position = ZonadeInteraccion.position; // Mueve el objeto recogido a la posición de la zona de interacción
                PickedObject.GetComponent<Rigidbody>().useGravity = false; // Desactiva la gravedad del objeto recogido
                PickedObject.GetComponent<Rigidbody>().isKinematic = true; // Hace que el objeto recogido sea cinemático para evitar colisiones
            }
        }
        else if (PickedObject != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject.GetComponent<AgarrarObjeto>().esAgarrable = true; // Marca el objeto como agarrable nuevamente
                PickedObject.transform.SetParent(null); // Desvincula el objeto recogido de la zona de interacción
                PickedObject.GetComponent<Rigidbody>().useGravity = true; // Activa la gravedad del objeto recogido
                PickedObject.GetComponent<Rigidbody>().isKinematic = false; // Hace que el objeto recogido no sea cinemático para permitir colisiones
                PickedObject = null; // Limpia la referencia al objeto recogido
            }
        }
    }
}
