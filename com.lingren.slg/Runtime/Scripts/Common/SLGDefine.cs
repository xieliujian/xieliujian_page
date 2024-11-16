using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LR.SLG
{
    /// <summary>
    /// 
    /// </summary>
    public class SLGDefine
    {
        /// <summary>
        /// 
        /// </summary>
        public const int SLG_GRID_UNIT_SIZE = 4;

        /// <summary>
        /// 
        /// </summary>
        public const int SLG_GRID_HORIZONTAL_NUM = 50;

        /// <summary>
        /// 
        /// </summary>
        public const int SLG_GRID_VERTICAL_NUM = 50;

        /// <summary>
        /// 
        /// </summary>
        public const int SLG_MAP_HORIZONTAL_SIZE = SLG_GRID_HORIZONTAL_NUM * SLG_GRID_UNIT_SIZE;

        /// <summary>
        /// 
        /// </summary>
        public const int SLG_MAP_VERTICAL_SIZE = SLG_GRID_VERTICAL_NUM * SLG_GRID_UNIT_SIZE;

        /// <summary>
        /// 
        /// </summary>
        public const int SLG_LOGIC_GRID_HORIZONTAL_OFFSET = SLG_GRID_HORIZONTAL_NUM / 2 + 1;

        /// <summary>
        /// 
        /// </summary>
        public const int SLG_LOGIC_GRID_VERTICAL_OFFSET = SLG_GRID_VERTICAL_NUM / 2 + 1;

        /// <summary>
        /// �ߴ���4�ı���
        /// </summary>
        public const int SLG_AREA_HORIZONTAL_SIZE = 40;

        /// <summary>
        /// �ߴ���4�ı���
        /// </summary>
        public const int SLG_AREA_VERTICAL_SIZE = 40;

        /// <summary>
        /// ����ˮƽ������Ŀ
        /// </summary>
        public const int SLG_AREA_HORIZONTAL_GRID_NUM = SLG_AREA_HORIZONTAL_SIZE / SLG_GRID_UNIT_SIZE;

        /// <summary>
        /// ����ֱ������Ŀ
        /// </summary>
        public const int SLG_AREA_VERTICAL_GRID_NUM = SLG_AREA_VERTICAL_SIZE / SLG_GRID_UNIT_SIZE;

        /// <summary>
        /// �����ܵĸ�����Ŀ
        /// </summary>
        public const int SLG_AREA_TOTAL_GRID_NUM = SLG_AREA_HORIZONTAL_GRID_NUM * SLG_AREA_VERTICAL_GRID_NUM;

        /// <summary>
        /// ˮƽ������Ŀ
        /// </summary>
        public const int SLG_AREA_HORIZONTAL_NUM = SLG_GRID_HORIZONTAL_NUM * SLG_GRID_UNIT_SIZE / SLG_AREA_HORIZONTAL_SIZE;

        /// <summary>
        /// ��ֱ������Ŀ
        /// </summary>
        public const int SLG_AREA_VERTICAL_NUM = SLG_GRID_VERTICAL_NUM * SLG_GRID_UNIT_SIZE / SLG_AREA_VERTICAL_SIZE;

        /// <summary>
        /// С��ͼһ������ռ�õ�������Ŀ
        /// </summary>
        public const int SLG_MINIMAP_GRID_PIXEL_COUNT = 1;

        /// <summary>
        /// С��ͼ��ͼ���
        /// </summary>
        public const int SLG_MINIMAP_TEX_WIDTH = SLG_GRID_HORIZONTAL_NUM * SLG_MINIMAP_GRID_PIXEL_COUNT;

        /// <summary>
        /// С��ͼ��ͼ�߶�
        /// </summary>
        public const int SLG_MINIMAP_TEX_HEIGHT = SLG_GRID_VERTICAL_NUM * SLG_MINIMAP_GRID_PIXEL_COUNT;

        /// <summary>
        /// ÿ�α��������ݣ����ö�پ�Ҫ�仯�����Ż���
        /// </summary>
        public enum SLGInfoLayer
        {
            CampInfo = 5,
            FireInfo,
            AreaTargetPos,
            AreaWayPoint,
            SceneLine,
            ResLvProperty
        }

        /// <summary>
        /// 
        /// </summary>
        public enum SLGInfoLayerType
        {
            Invalid = -1,        // ��Ч
            AreaGrid,           // �����������
            SceneLine           // �����߶�����
        }

        /// <summary>
        /// ����������Բ�����
        /// </summary>
        public enum SLGAreaGridPropertyLayerType
        {
            Invalid = -1,        // ��Ч
            SelState,           // ѡ��״̬
            ResLvState          // ��Դ�ȼ�״̬
        }

        /// <summary>
        /// 
        /// </summary>
        public delegate void SLGRun();

        /// <summary>
        /// Shader
        /// </summary>
        public static readonly int SLG_SHADER_FLAG_ID = Shader.PropertyToID("_SLGShaderFlag");

        public static readonly int SLG_SHADER_SCENEOBJ_BASECOLOR_ID = Shader.PropertyToID("_BaseColor");
        public static readonly int SLG_SHADER_SCENEOBJ_UV_SCALE_OFFSET_ID = Shader.PropertyToID("_UVScaleOffset");
        public static readonly int SLG_SHADER_SCENEOBJ_ZCLIP_ID = Shader.PropertyToID("_ZClip");
        public static readonly int SLG_SHADER_SCENEOBJ_ZTEST_ID = Shader.PropertyToID("_ZTest");
        public static readonly int SLG_SHADER_SCENEOBJ_ZWRITE_ID = Shader.PropertyToID("_ZWrite");

        public static readonly int SLG_SHADER_SCENELINE_ENEMY_ID = Shader.PropertyToID("_Enemy");
        public static readonly int SLG_SHADER_SCENELINE_UV_SCALE_OFFSET_ID = Shader.PropertyToID("_UVScaleOffset");
    }
}

