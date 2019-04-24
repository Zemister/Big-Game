using System.Collections.Generic;
using System;
using UnityEngine;

public class TalentContainer : MonoBehaviour, ITalentContainer
{
    public List<TalentSlot> TalentSlots; //look into nodes

    public event Action<TalentSlot> OnPointerEnterEvent;
    public event Action<TalentSlot> OnPointerExitEvent;
    public event Action<TalentSlot> OnLeftClickEvent;
    public event Action<TalentSlot> OnRightClickEvent;

    void OnValidate()
    {
        GetComponentsInChildren(includeInactive: true, result: TalentSlots);
    }

    void Awake()
    {
        for (int i = 0; i < TalentSlots.Count; i++)
        {
            TalentSlots[i].OnPointerEnterEvent += slot => EventHelper(slot, OnPointerEnterEvent);
            TalentSlots[i].OnPointerExitEvent += slot => EventHelper(slot, OnPointerExitEvent);
            TalentSlots[i].OnLeftClickEvent += slot => EventHelper(slot, OnLeftClickEvent);
            TalentSlots[i].OnRightClickEvent += slot => EventHelper(slot, OnRightClickEvent);
        }
    }

    private void EventHelper(TalentSlot talentSlot, Action<TalentSlot> action)
    {
        if (action != null)
            action(talentSlot);
    }

    //need to check if you can select the talent (both have the points and the path open)

    //need to actually add the talent

    //undo a talent or remove talent

    //Reset talent tree ability set everything back to null or just 0 or something
}
