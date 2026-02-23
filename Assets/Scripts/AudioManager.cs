using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour , IaudioManager //i de interfaz
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private List<SoundData> sounds; //Lista de sonidos a configurar en el inspector

    private Dictionary<string, SoundData> soundDictionary;

    private void Awake() // Un paso antes del Start
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Asegurarse de que solo haya una instancia del AudioManager
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Mantener el AudioManager entre escenas

        soundDictionary = new Dictionary<string, SoundData>();

        foreach (var sound in sounds)
        {
            soundDictionary.Add(sound.id, sound); // Agregar cada sonido a un diccionario para acceso rápido
        }
    }

    public void Play2D(string soundID)
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
            return; // Si el sonido no existe, salir

        Play(sound, Vector3.zero, false); // Reproducir el sonido en 2D
    }

    public void Play3D(string soundID, Vector3 position)
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
            return; // Si el sonido no existe, salir

        Play(sound, position, true); // Reproducir el sonido en 3D
    }

    private void Play(SoundData sound, Vector3 position, bool is3D)
    {
        GameObject go = new GameObject("Audio_" + sound.id); // Crear un nuevo GameObject para el sonido
        go.transform.position = position; // Posicionar el GameObject en el mundo

        AudioSource source = go.AddComponent<AudioSource>(); // Agregar un componente AudioSource
        source.clip = sound.clip; // Asignar el clip de audio
        source.volume = sound.volume; // Configurar el volumen
        source.loop = sound.loop; // Configurar si el sonido se repite
        source.spatialBlend = is3D ? 1f : 0f; // Configurar el blend espacial para 2D o 3D

        source.Play(); // Reproducir el sonido

        if (!sound.loop) // Si el sonido no se repite, destruir el GameObject después de que termine de reproducirse
        {
            Destroy(go, sound.clip.length);
        }
    }

}

public interface IaudioManager
{
    void Play2D(string id); // Reproducir un sonido 2D por su ID
    void Play3D(string id, Vector3 location); // Sonido del ambeinte o de un objeto en el mundo
}
