using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Sound Data")]

public class SoundData : ScriptableObject
{
    public string id; // Identificador único para el sonido
    public AudioClip clip; // Clip de audio a reproducir
    public float volume = 1f; // Volumen del sonido
    public bool loop = false; // Indica si el sonido se debe repetir
    [Range(0f, 1f)] public float spatialBlend = 1f; // Controla la mezcla espacial para sonidos 2D (0) o 3D (1)
}