using UnityEngine;

public class SonidoFinal : MonoBehaviour
{
    public GameObject post;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            AudioManager.Instance.Play3D("Detectar", post.transform.position); // Reproducir el sonido de detección al entrar en la zona definida
            //AudioManager.Instance.Play2D("Recoger"); // Reproducir el sonido de detección al entrar en la zona definida
        }
    }
}
