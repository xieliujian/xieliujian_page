using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LR.SLG
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class SLGAreaDB
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        public Vector3 logicBoundMin;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        public Vector3 logicBoundMax;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        public Vector3 boundMin;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        public Vector3 boundMax;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        public SLGAreaMapLayerSetDB mapLayerSet = new SLGAreaMapLayerSetDB();

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        public SLGAreaDynamicMapLayerSetDB dynamicMapLayerSet = new SLGAreaDynamicMapLayerSetDB();
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        public SLGAreaGridSetDB gridSet = new SLGAreaGridSetDB();

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        public List<GameObject> objList = new List<GameObject>();

        /// <summary>
        /// 
        /// </summary>
        public void InitGridSet()
        {
            gridSet.CalcStartEndPos(logicBoundMin, logicBoundMax);
            gridSet.Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void AddObj(GameObject obj)
        {
            objList.Add(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CalcBounds()
        {
            var bounds = SLGUtils.CalcObjListBounds(objList);

            boundMin = bounds.min;
            boundMax = bounds.max;

            boundMin.y = 0f;
            boundMax.y = 1f;

            // �������ת��ͷ��Ե��Ƭ©��Ⱦ����
            // ֮ǰ֮���Ի����������⣬����ΪSLG��Ⱦ�������֮ǰ�������ӳ�ˢ��һ֡
            // ����SLGˢ���޸ĵ������ˢ��֮�󣬲���Ҫ���extraSize�ˡ�
            float extraSize = 5f;
            boundMin -= new Vector3(extraSize, 0f, extraSize);
            boundMax += new Vector3(extraSize, 0f, extraSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name=""></param>
        public void CalcLogicBound(int x, int y, int gridWidth, int gridHeight)
        {
            logicBoundMin.x = gridWidth * (-0.5f) + x * SLGDefine.SLG_AREA_HORIZONTAL_SIZE;
            logicBoundMin.y = 0f;
            logicBoundMin.z = gridHeight * (-0.5f) + y * SLGDefine.SLG_AREA_VERTICAL_SIZE;

            logicBoundMax.x = logicBoundMin.x + SLGDefine.SLG_AREA_HORIZONTAL_SIZE;
            logicBoundMax.y = 1f;
            logicBoundMax.z = logicBoundMin.z + SLGDefine.SLG_AREA_VERTICAL_SIZE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsInArea(Vector3 pos)
        {
            if (pos.x >= logicBoundMin.x && pos.z >= logicBoundMin.z && 
                pos.x < logicBoundMax.x && pos.z < logicBoundMax.z)
            {
                return true;
            }

            return false;
        }
    }
}

