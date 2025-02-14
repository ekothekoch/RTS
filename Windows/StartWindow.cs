using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public GameObject[] OpenWindows;
    //public override void Open()
    //{
    //    base.Open();
    //}
    //public override void Close()
    //{
    //    base.Close(); 
    //}
    //// Update is called once per frame
    //void Start()
    //{
    //    Open();
    //}
    //public void Production()
    //{
    //   manager.Open(2); 
    //}
    //public void City()
    //{
    //    manager.Open(3);
    //}
    //public void Mayor()
    //{
    //    manager.Open(4);
    //}
    public void CloseStart()
    {
        for (int i = 0; i < OpenWindows.Length; i++)
        {
            OpenWindows[i].SetActive(false);
        }
        Close();
    }

    public override void Open()
    {
        base.Open();
    }
    public override void Close()
    {
        base.Close();
    }
    protected override void Awake()
    {

    }

    public void ProductView()
    {
        manager.Open(2);

    }
    public void CityView()
    {
        manager.Open(3);
    }
    public void MayorView()
    {
        manager.Open(4);
    }
    //public void CloseWindow()
    //{
    //    manager.CloseAll();
    //    gameObject.SetActive(false);


    //}
}
