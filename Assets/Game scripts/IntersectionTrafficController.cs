using UnityEngine;
using System.Collections.Generic;

public class IntersectionTrafficController : MonoBehaviour
{
    [System.Serializable]
    public class TrafficGroup
    {
        public string name;
        public AutoTrafficSetController[] trafficLights;
    }

    public List<TrafficGroup> groups = new List<TrafficGroup>();
    public float greenDuration = 8f;
    public float yellowDuration = 2f;

    private int currentGroupIndex = 0;
    private float timer = 0f;
    private enum IntersectionPhase { Go, Warn, Transition }
    private IntersectionPhase phase = IntersectionPhase.Go;

    void Start()
    {
        SetGroupState(currentGroupIndex, PhaseState.Go);
    }

    void Update()
    {
        timer += Time.deltaTime;

        switch (phase)
        {
            case IntersectionPhase.Go:
                if (timer >= greenDuration)
                {
                    SetGroupState(currentGroupIndex, PhaseState.Warn);
                    phase = IntersectionPhase.Warn;
                    timer = 0f;
                }
                break;

            case IntersectionPhase.Warn:
                if (timer >= yellowDuration)
                {
                    SetGroupState(currentGroupIndex, PhaseState.Stop);
                    phase = IntersectionPhase.Transition;
                    timer = 0f;
                }
                break;

            case IntersectionPhase.Transition:
                currentGroupIndex = (currentGroupIndex + 1) % groups.Count;
                SetGroupState(currentGroupIndex, PhaseState.Go);
                phase = IntersectionPhase.Go;
                timer = 0f;
                break;
        }
    }

    void SetGroupState(int groupIndex, PhaseState state)
    {
        for (int i = 0; i < groups.Count; i++)
        {
            PhaseState newState = (i == groupIndex) ? state : PhaseState.Stop;
            foreach (var light in groups[i].trafficLights)
            {
                light.currentState = newState;
                light.SendMessage("ApplyState", newState, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    public bool IsGroupAllowedToGo(int groupIndex)
    {
    if (groupIndex < 0 || groupIndex >= groups.Count)
        return false;

    return currentGroupIndex == groupIndex && phase == IntersectionPhase.Go;
    }

}
