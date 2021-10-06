﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

public class RayScript : MonoBehaviour
{    
    Ray ray; //射線

    float raylength = 1.5f; //射線最大長度

    RaycastHit hit; //被射線打到的物件   

    public Text text;
    public RawImage image;
    public Texture point;
    public Texture crosshair;    

    void Start()
    {        
    }
        
    void Update()  
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); 
        //由攝影機射到是畫面正中央的射線

        if (Physics.Raycast(ray, out hit, raylength)) 
        // (射線,out 被射線打到的物件,射線長度)，out hit 意思是：把"被射線打到的物件"帶給hit
        {
            hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver); 
            //向被射線打到的物件呼叫名為"HitByRaycast"的方法，不需要傳回覆

            Debug.DrawLine(ray.origin, hit.point, Color.yellow); 
            //當射線打到物件時會在Scene視窗畫出黃線，方便查閱

            print(hit.transform.name);
            //在Console視窗印出被射線打到的物件名稱，方便查閱          

            text.text = "射線已對打中物件：" + hit.transform.name;

            image.texture = crosshair;
        }
        else
        {
            image.texture = point;
            text.text = "距離不夠近or準心沒對準，射線沒有打中物件";
        }
    }
}
