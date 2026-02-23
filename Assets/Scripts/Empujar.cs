using UnityEngine;

public class Empujar : MonoBehaviour
{
    public float Empuje = 5.0f; // Fuerza de empuje aplicada al jugador
    private float obtenerMasa; // Variable para almacenar la masa del objeto con el que se choca


    private void OnControllerColliderHit(ControllerColliderHit hit) // cuando el jugador choca con un objeto colaider hace esta funcion
    {
        Rigidbody objeto = hit.collider.attachedRigidbody; // Obtiene el Rigidbody del objeto con el que se ha chocado

        if (objeto == null || objeto.isKinematic) // Verifica si el objeto tiene un Rigidbody y no es cinem�tico, Estos || significan o
        {
            return; // Si el objeto no tiene un Rigidbody o es cinem�tico, no se aplica ninguna fuerza
        }
        if(hit.moveDirection.y < -0.3) // Verifica si el jugador est� cayendo sobre el objeto, Si el jugador est� cayendo sobre el objeto, no se aplica ninguna fuerza para evitar que el jugador sea empujado hacia arriba al caer sobre �l
        {
            return;
        }

        obtenerMasa = objeto.mass; // Obtiene

        Vector3 empujeDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z); // Calcula la direcci�n de empuje basada en la direcci�n del movimiento del jugador, pero solo en el plano horizontal (x y z)

        objeto.linearVelocity = empujeDir * Empuje/obtenerMasa; // Aplica una fuerza de empuje al objeto multiplicando la direcci�n de empuje por la fuerza de empuje y dividi�ndola por la masa del objeto para obtener una aceleraci�n proporcional a su masa

    }
}
