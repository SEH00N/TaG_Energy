using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;
    private static GameManager instance = null;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InputManager.ChangeInput(InputType.Play);
    }
}
