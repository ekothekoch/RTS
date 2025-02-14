using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionWindow : GenericWindow
{
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

    // Start is called before the first frame update
    void Start()
    {
        // Open();

    }
    public void OnNext()
    {
        Close();
    }
}


