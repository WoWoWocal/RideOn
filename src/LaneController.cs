using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class LaneController : MonoBehaviour
{
    [Header("Forward")]
    public float forwardSpeed = 12f;

    [Header("Lanes")]
    public float laneWidth = 3f;     // Abstand zwischen Spuren
    public float laneChangeTime = 0.12f; // Dauer des Wechsel-Lerps
    public int minLane = -1;         // -1 / 0 / +1 = drei Spuren
    public int maxLane =  1;

    int currentLane = 0;
    int targetLane = 0;
    float laneLerpT = 1f; // 1 = am Ziel
    float startX, targetX;

    void Start()
    {
        currentLane = Mathf.Clamp(0, minLane, maxLane);
        targetLane  = currentLane;
        startX = targetX = LaneToX(currentLane);

        var p = transform.position;
        p.x = targetX;
        transform.position = p;
    }

    void Update()
    {
        HandleInput();

        // Vortrieb
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        // Sanfter Spurwechsel
        if (laneLerpT < 1f)
        {
            laneLerpT += Time.deltaTime / laneChangeTime;
            float x = Mathf.Lerp(startX, targetX, Mathf.SmoothStep(0f, 1f, laneLerpT));
            var pos = transform.position; pos.x = x; transform.position = pos;
        }
    }

    void HandleInput()
    {
        bool left = false, right = false;

        #if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            left  = Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame;
            right = Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame;
        }
        #else
        left  = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        #endif

        if (left)  TryChangeLane(-1);
        if (right) TryChangeLane(+1);
    }

    void TryChangeLane(int dir)
    {
        int next = Mathf.Clamp(targetLane + dir, minLane, maxLane);
        if (next == targetLane) return;

        // neuen Lerp starten
        currentLane = targetLane;
        targetLane  = next;
        startX = LaneToX(currentLane);
        targetX = LaneToX(targetLane);
        laneLerpT = 0f;
    }

    float LaneToX(int lane) => lane * laneWidth;
}
