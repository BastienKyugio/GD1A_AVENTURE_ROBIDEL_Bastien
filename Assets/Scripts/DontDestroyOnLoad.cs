using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject[] objects;
    public static DontDestroyOnLoad instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DontDestroyOnLpas dans la sc�ne");
            return;
        }

        instance = this;
    
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
    public void RemoveFromDontDestroyOnLoad()
    {
        foreach(var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
