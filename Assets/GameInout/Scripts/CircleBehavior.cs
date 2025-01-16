using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavior : MonoBehaviour
{
    public Vector3 objSize = Vector3.zero;
    public bool grow; 
    // Start is called before the first frame update
    void Start()
    {
        objSize = this.gameObject.transform.localScale;
        grow = true;
        Actions.GrowCircle += growing; 
    }

    // Update is called once per frame
    void Update()
    {
        //growing(); 
    }

    public void growing() 
    {
        if (grow)
        {
            objSize *= (1 + (Time.deltaTime * 0.5f));
            this.transform.localScale = objSize;
        }

        if (objSize.x > 1.5f)
        {
            grow = false;
            objSize = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnDisable()
    {
        Actions.GrowCircle -= growing;
    }

}
