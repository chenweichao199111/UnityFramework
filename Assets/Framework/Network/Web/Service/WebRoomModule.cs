﻿#region 版权信息
/*
 * -----------------------------------------------------------
 *  Copyright (c) KeJun All rights reserved.
 * -----------------------------------------------------------
 *		描述: 
 *      创建者：陈伟超
 *      创建时间: 2019/04/19 15:31:34
 *  
 */
#endregion

using Framework.Http;
using System;
using System.Collections.Generic;

namespace Framework.Network.Web
{
    public class WebRoomModule : IRoomModule
    { 
        private HttpUtils mHttp;
        private string id;
        private string sign;
        private string createRoomUrl;
        private string joinRoomUrl;
        private string getRoomListUrl;


        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Sign
        {
            get
            {
                return sign;
            }

            set
            {
                sign = value;
            }
        }

        public WebRoomModule(string id, string sign, string createRoomUrl, string joinRoomUrl, string getRoomListUrl)
        {
            mHttp = new HttpUtils();
            Id = id;
            Sign = sign;

            this.createRoomUrl = createRoomUrl;
            this.joinRoomUrl = joinRoomUrl;
            this.getRoomListUrl = getRoomListUrl;
        }

        public bool RequestCreate(Action<EventArgs> response)
        {
            Dictionary<string, string> tempDic = new Dictionary<string, string>();
            tempDic.Add("user_id", Id);
            tempDic.Add("sign", Sign);

            if (response == null)
            {
                return mHttp.SendPostAnsyc(createRoomUrl, tempDic, null);
            }
            else
            {
                Action<string> tempA = delegate (string result)
                {
                    NetworkEventArgs<string> tempArgs = new NetworkEventArgs<string>(result);
                    response.Invoke(tempArgs);
                };

                return mHttp.SendPostAnsyc(createRoomUrl, tempDic, tempA);
            }
        }

        public bool RequestJoin(Action<EventArgs> response)
        {
            Dictionary<string, string> tempDic = new Dictionary<string, string>();
            tempDic.Add("user_id", Id);
            tempDic.Add("sign", Sign);

            if (response == null)
            {
                return mHttp.SendPostAnsyc(joinRoomUrl, tempDic, null);
            }
            else
            {
                Action<string> tempA = delegate (string result)
                {
                    NetworkEventArgs<string> tempArgs = new NetworkEventArgs<string>(result);
                    response.Invoke(tempArgs);
                };

                return mHttp.SendPostAnsyc(joinRoomUrl, tempDic, tempA);
            }
        }

        public bool RequestRoomList(Action<EventArgs> response)
        {
            Dictionary<string, string> tempDic = new Dictionary<string, string>();
            tempDic.Add("user_id", Id);
            tempDic.Add("sign", Sign);

            if (response == null)
            {
                return mHttp.SendPostAnsyc(getRoomListUrl, tempDic, null);
            }
            else
            {
                Action<string> tempA = delegate (string result)
                {
                    NetworkEventArgs<string> tempArgs = new NetworkEventArgs<string>(result);
                    response.Invoke(tempArgs);
                };

                return mHttp.SendPostAnsyc(getRoomListUrl, tempDic, tempA);
            }
        }

        public void RequestGetRoomInfo()
        {
            ProtocolJson tempPj = new ProtocolJson();
            CS_GetRoomInfo tempData = new CS_GetRoomInfo();
            tempData.protocolName = ProtocolConst.GetRoomInfo;
            tempData.id = Id;
            tempPj.Serialize(tempData);
            WebMgr.SrvConn.Send(tempPj);
        }

        public void RequestLeaveRoom()
        {
            ProtocolJson tempPj = new ProtocolJson();
            CS_LeaveRoom tempData = new CS_LeaveRoom();
            tempData.protocolName = ProtocolConst.LeaveRoom;
            tempData.id = Id;
            tempPj.Serialize(tempData);
            WebMgr.SrvConn.Send(tempPj);
        }

        public void RequestDissolveRoom()
        {
            ProtocolJson tempPj = new ProtocolJson();
            CS_DissolveRoom tempData = new CS_DissolveRoom();
            tempData.protocolName = ProtocolConst.DissolveRoom;
            tempData.id = Id;
            tempPj.Serialize(tempData);
            WebMgr.SrvConn.Send(tempPj);
        }

        public void RequestFight()
        {
            ProtocolJson tempPj = new ProtocolJson();
            CS_StartFight tempData = new CS_StartFight();
            tempData.protocolName = ProtocolConst.StartFight;
            tempData.id = Id;
            tempPj.Serialize(tempData);
            WebMgr.SrvConn.Send(tempPj);
        }
    }
}