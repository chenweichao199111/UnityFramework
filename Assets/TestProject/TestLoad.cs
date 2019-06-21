﻿
#region 版权信息
/*
 * -----------------------------------------------------------
 *  Copyright (c) KeJun All rights reserved.
 * -----------------------------------------------------------
 *		描述: 
 *      创建者：DESKTOP-1050N1H\luoyikun
 *      创建时间: 2018/11/16 00:21:33
 *  
 */
#endregion


using AssetBundles;
using Framework.Unity.AssetBundles;
using UnityEngine;

namespace TestProject
{
    public class TestLoad : MonoBehaviour
    {
        #region Fields
        public string assetBundleName;
        public string assetName;
        #endregion

        #region Properties

        #endregion

        #region Unity Messages
        //    void Awake()
        //    {
        //
        //    }
        //    void OnEnable()
        //    {
        //
        //    }
        //
        void Start()
        {
            // Load asset.
            LoadQueue.Instance.AddTask(assetBundleName, assetName, typeof(GameObject), LoadFinish);

            /*
            LoadQueue.Instance.AddTask("red.ab", "Red", typeof(GameObject), LoadFinish);
            LoadQueue.Instance.AddTask("green.ab", "Green", typeof(GameObject), LoadFinish);
            LoadQueue.Instance.AddTask("blue.ab", "Blue", typeof(GameObject), LoadFinish);
            */
        }
        //    
        //    void Update() 
        //    {
        //    
        //    }
        //
        //    void OnDisable()
        //    {
        //
        //    }
        //
        //    void OnDestroy()
        //    {
        //
        //    }

        #endregion

        #region Private Methods

        #endregion

        #region Protected & Public Methods
        public void LoadFinish(AssetBundleLoadOperation varOp)
        {
            AssetBundleLoadAssetOperation tempOp = varOp as AssetBundleLoadAssetOperation;

            GameObject prefab = tempOp.GetAsset<GameObject>();
            if (prefab != null)
                GameObject.Instantiate(prefab);
        }
        #endregion
    }
}