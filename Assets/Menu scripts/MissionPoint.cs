using UnityEngine;
using UnityEngine.EventSystems;

public class MissionPoint : MonoBehaviour, IPointerClickHandler
{
    public MissionData missionData;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (missionData != null)
        {
            MissionUIManager.Instance.ShowMissionDetails(missionData);
        }
    }
}
