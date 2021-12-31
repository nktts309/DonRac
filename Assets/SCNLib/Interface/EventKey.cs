using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCN;
using System;
public class EventKey : IEventParams
{
   
    public struct OnCollect : IEventParams
    {
        public Vector3 posMove;
        public Action action;
    }
}
