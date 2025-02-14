using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour
{
   // public GameObject firstSelected;
    public static WindowManager manager;
    //public EventSystem eventSystem
    //{
    //   get { return GameObject.Find("EventSystem").GetComponent<EventSystem>(); }
    //}
    //public void OnFocus()
    //{
        
    //    eventSystem.SetSelectedGameObject(firstSelected);

    //}
    protected void Display(bool value)
    {
        gameObject.SetActive(value);
    }
    public virtual  void Open()
    {
        Display(true);
        //OnFocus();
    }
     public virtual void Close()
    {
        Display(false);
    }
    protected virtual  void Awake()
    {
        Close();
    }

}
