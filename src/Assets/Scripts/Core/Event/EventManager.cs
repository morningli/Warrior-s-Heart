using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EventParam
{
    public EventDefine Define;
    public float SendTime;
    public object Param1, Param2, Param3, Param4;
    public EventParam(EventDefine define, float sendtime, object param1, object param2, object param3, object param4)
    {
        Define = define;
        SendTime = sendtime;
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
        Param4 = param4;
    }
}
public class EventManager
{
    public delegate void EventDelegate(EventDefine define, object param1, object param2, object param3, object param4);

    static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EventManager();
            return instance;
        }
    }

    Dictionary<EventDefine, List<EventDelegate>> EventDic = new Dictionary<EventDefine, List<EventDelegate>>();
    List<EventParam> NextUpdateEvent = new List<EventParam>();

    public void RegisterEvent(EventDefine define, EventDelegate func)
    {
        try
        {
            EventDic.Add(define,new List<EventDelegate>());
        }
        catch (System.Exception ex)
        {
        	
        }
        try
        {
            EventDic[define].Add(func);
        }
        catch (System.Exception ex)
        {
        	
        }
        
    }

    public void UnRegisterEvent(EventDefine define, EventDelegate func)
    {
        try
        {
            EventDic[define].Remove(func);
        }
        catch (System.Exception ex)
        {
        	
        }
    }

    void DellEvent(EventDefine define, object param1, object param2, object param3, object param4)
    {
        List<EventDelegate> funclist;
        try
        {
            funclist = EventDic[define];
        }
        catch (System.Exception ex)
        {
            //LogManager.Log("NoDelegateRecvThisEvent:" + define.ToString());
            return;
        }
        for (int i = 0; i < funclist.Count; i++)
        {
            funclist[i](define, param1, param2, param3, param4);
        }
    }
    //sendtime<0：立即发送，=0下次Update时发送，>0：sendtime时间后发送
    public void SendEvent(EventDefine define, float sendtime, object param1 = null, object param2 = null, object param3 = null, object param4 = null)
    {
        if (sendtime>=0)
        {
            NextUpdateEvent.Add(new EventParam(define, sendtime, param1, param2, param3, param4));
        }
        else
        {
            DellEvent(define, param1, param2, param3, param4);
        }
        

    }

    public void Update()
    {
        List<EventParam> newNextUpdateEvent = new List<EventParam>();
        for (int i = 0; i < NextUpdateEvent.Count;i++ )
        {
            if (NextUpdateEvent[i].SendTime <= Time.time)
            {
                DellEvent(NextUpdateEvent[i].Define, NextUpdateEvent[i].Param1, NextUpdateEvent[i].Param2, NextUpdateEvent[i].Param3, NextUpdateEvent[i].Param4);
            }
            else
            {
                newNextUpdateEvent.Add(NextUpdateEvent[i]);
            }
        }
        NextUpdateEvent = newNextUpdateEvent;
    }
}
