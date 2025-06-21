using UnityEngine;
using System.Collections;

public class AutoTrafficSetController : MonoBehaviour
{
    public enum CycleMode { Standard, Flashing, Off }
    public CycleMode cycleMode = CycleMode.Standard;

    public float goDuration = 6f;
    public float warnDuration = 2f;
    public float stopDuration = 6f;

    private float timer = 0f;
    private PhaseState currentState = PhaseState.Stop;

    void Start()
    {
        ApplyCurrentState();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (cycleMode == CycleMode.Off)
        {
            if (currentState != PhaseState.Off)
            {
                currentState = PhaseState.Off;
                ApplyCurrentState();
            }
            return;
        }

        if (cycleMode == CycleMode.Flashing)
        {
            float flashInterval = 0.5f;
            if (timer >= flashInterval)
            {
                currentState = (currentState == PhaseState.Flash) ? PhaseState.Off : PhaseState.Flash;
                ApplyCurrentState();
                timer = 0f;
            }
            return;
        }

        switch (currentState)
        {
            case PhaseState.Stop:
                if (timer >= stopDuration)
                {
                    currentState = PhaseState.Go;
                    ApplyCurrentState();
                    timer = 0f;
                }
                break;

            case PhaseState.Go:
                if (timer >= goDuration)
                {
                    currentState = PhaseState.Warn;
                    ApplyCurrentState();
                    timer = 0f;
                }
                break;

            case PhaseState.Warn:
                if (timer >= warnDuration)
                {
                    currentState = PhaseState.Stop;
                    ApplyCurrentState();
                    timer = 0f;
                }
                break;
        }
    }

    void ApplyCurrentState()
    {
        BroadcastMessage("ApplyState", currentState, SendMessageOptions.DontRequireReceiver);
    }
}
