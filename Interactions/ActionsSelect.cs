using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsSelect : Interaction
{
    public GameObject buttonHud;
    public override void Deselect()
    {
        ActionsManager.Current.ClearButtons();
       buttonHud.SetActive(false);
    }

    public override void Select()
    {
       buttonHud.SetActive(true);
        ActionsManager.Current.ClearButtons();
        foreach (var ab in GetComponents<ActionBehavior>())
        {
            ActionsManager.Current.AddButton(ab.ButtonPic, ab.GetClickAction()); 
        }
    }


}
