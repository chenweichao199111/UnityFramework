﻿#region 版权信息
/*
 * -----------------------------------------------------------
 *  Copyright (c) KeJun All rights reserved.
 * -----------------------------------------------------------
 *		描述: 
 *      创建者：陈伟超
 *      创建时间: 2019/04/21 15:31:34
 *  
 */
#endregion

namespace Framework.Network
{
    public interface INetworkConnect
    {
        #region Protected & Public Methods
        /// <summary>
        /// 连接服务器
        /// </summary>
        void ConnectServer();

        /// <summary>
        /// 断开服务器
        /// </summary>
        void DisconnectServer();
        #endregion
    }
}