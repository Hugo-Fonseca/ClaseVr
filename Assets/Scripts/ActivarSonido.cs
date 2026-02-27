using UnityEngine;

public class ActivarSonido : MonoBehaviour
{
    public GameObject post;
    public GameObject post1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            //AudioManager.Instance.Play3D("Recoger", post.transform.position); // Reproducir el sonido de detección al entrar en la zona definida
            AudioManager.Instance.Play2D("Recoger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            //AudioManager.Instance.Play3D("Salir", post1.transform.position); // Reproducir el sonido de perder al salir de la zona definida
            AudioManager.Instance.Play2D("Salir");
        }
    }
}
