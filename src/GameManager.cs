using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class GameManager : MonoBehaviour
{
    void Start()
    {
        if (ScoreManager.Instance != null) ScoreManager.Instance.ResetAll();
    }

    void Update()
    {
        bool restart =
        #if ENABLE_INPUT_SYSTEM
            (Keyboard.current != null && (Keyboard.current.rKey.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame));
        #else
            Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return);
        #endif

        if (restart)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
