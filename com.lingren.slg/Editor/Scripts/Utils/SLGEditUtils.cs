using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Tilemaps;
using UnityEngine.Tilemaps;

namespace LR.SLG
{
    /// <summary>
    /// 
    /// </summary>
    public class SLGEditUtils
    {
        /// <summary>
        /// 
        /// </summary>
        public const string SLG_INFO_PREFAB_PATH_PREFIX = "Assets/scene/common/res/slg/logicprefab/";

        /// <summary>
        /// 
        /// </summary>
        public const string SLG_SHARE_GRID_PREFAB_NAME = "slg_share_grid";

        /// <summary>
        /// 
        /// </summary>
        public const string PREFAB_SUFFIX = ".prefab";

        /// <summary>
        /// 
        /// </summary>
        const string SCENE_SUFFIX = ".unity";

        /// <summary>
        /// 
        /// </summary>
        const string SLG_SCENE_SUFFIX_NAME = "_SLG";

        /// <summary>
        /// 
        /// </summary>
        const string ASSET_SUFFIX = ".asset";

        /// <summary>
        /// 
        /// </summary>
        [MenuItem("MHT/SLG/SLG������ͬ��������Ⱦ�ڵ�", false, 142)]
        static void CreateOrSyncSceneRenderRootNode()
        {
            SLGRenderGridEdit.CreateOrSyncSceneRenderRootNode();
        }

        [MenuItem("MHT/SLG/SLG������ͬ���������Խڵ�", false, 143)]
        static void CreateOrSyncScenePropertyRootNode()
        {
            SLGPropertyGridEdit.CreateOrSyncScenePropertyRootNode();
        }

        /// <summary>
        /// 
        /// </summary>
        [MenuItem("MHT/SLG/SLG����������̬�����", false, 144)]
        static void CreateOrSyncSLGSceneDynamicObjGroup()
        {
            SLGDynamicObjGroupEdit.CreateOrSyncSLGSceneDynamicObjGroup();
        }

        //[MenuItem("MHT/SLG����BottomLayer�ϲ�", false, 145)]
        static void CombineAllRenderLayerBottomMap()
        {
            SLGRenderGridEdit.CombineAllRenderLayerBottomMap();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetsPath"></param>
        public static void SafeRemoveAsset(string assetsPath)
        {
            Debug.Log("SafeRemoveAsset " + assetsPath);

            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetsPath);

            if (obj != null)
            {
                var succeed = AssetDatabase.DeleteAsset(assetsPath);
            }
        }

        /// <summary>
        /// �Ƿ�prefab
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="bIgnore"></param>
        /// <returns></returns>
        public static bool IsPrefabObject(GameObject gameObject, bool bIgnore = false)
        {
            bool bIsPrefab = PrefabUtility.IsPartOfPrefabAsset(gameObject) ||
                PrefabUtility.IsPartOfPrefabInstance(gameObject);

            if (bIsPrefab)
            {
                if (gameObject.transform.parent != null)
                {
                    //������ڵ��Ǹ�prefab�Ļ�������Ͳ���
                    GameObject parentObject = gameObject.transform.parent.gameObject;

                    bool bParentIsPrefab = PrefabUtility.IsPartOfPrefabAsset(parentObject) ||
                        PrefabUtility.IsPartOfPrefabInstance(parentObject);
                    if (bParentIsPrefab)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static string GetObjectAssetPath(GameObject gameObject)
        {
            // Project�е�Prefab��Asset����Instance
            if (UnityEditor.PrefabUtility.IsPartOfPrefabAsset(gameObject))
            {
                // Ԥ������Դ��������
                return UnityEditor.AssetDatabase.GetAssetPath(gameObject);
            }

            // Scene�е�Prefab Instance��Instance����Asset
            if (UnityEditor.PrefabUtility.IsPartOfPrefabInstance(gameObject))
            {
                // ��ȡԤ������Դ
                var prefabAsset = UnityEditor.PrefabUtility.GetCorrespondingObjectFromOriginalSource(gameObject);
                return UnityEditor.AssetDatabase.GetAssetPath(prefabAsset);
            }

            // PrefabMode�е�GameObject�Ȳ���InstanceҲ����Asset
#if UNITY_2022_1_OR_NEWER
            var prefabStage = UnityEditor.SceneManagement.PrefabStageUtility.GetPrefabStage(gameObject);
#else
            var prefabStage = UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetPrefabStage(gameObject);
#endif
            if (prefabStage != null)
            {
                // Ԥ������Դ��prefabAsset = prefabStage.prefabContentsRoot
                return prefabStage.assetPath;
            }

            // ����Ԥ����
            return string.Empty;
        }

        /// <summary>
        /// �ҵ����ڵ������е�prefab
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static List<GameObject> CollectAllPrefabByRootNode(GameObject parent, bool ignoreUnVis = false)
        {
            List<GameObject> prefabList = new List<GameObject>();

            if (parent == null)
                return prefabList;

            var transArray = parent.GetComponentsInChildren<Transform>(true);
            foreach (var trans in transArray)
            {
                if (trans == null)
                    continue;

                var go = trans.gameObject;

                if (ignoreUnVis)
                {
                    if (!go.activeSelf)
                        continue;
                }

                bool bPerfab = IsPrefabObject(go, false);
                if (!bPerfab)
                    continue;

                prefabList.Add(go);
            }

            return prefabList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenePath"></param>
        /// <returns></returns>
        public static string GetSLGSceneDBPath(string scenePath)
        {
            string path = scenePath.Replace(SCENE_SUFFIX, "");
            path += SLG_SCENE_SUFFIX_NAME;
            path += ASSET_SUFFIX;
            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        public static void ResetTransPosY(Transform trans)
        {
            var pos = trans.localPosition;
            trans.localPosition = new Vector3(pos.x, 0f, pos.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static Vector3 ResetPosY(Vector3 pos)
        {
            return new Vector3(pos.x, 0f, pos.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOpacity"></param>
        /// <param name="renderQueueOffset"></param>
        /// <returns></returns>
        public static int CalcSLGRenderQueue(bool isOpacity, int renderQueueOffset)
        {
            int renderQueue = 2000;

            if (isOpacity)
            {
                renderQueue = 2000 + renderQueueOffset;
            }
            else
            {
                renderQueue = 3000 + renderQueueOffset;
            }

            return renderQueue;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ReloadLayerCfgMgr()
        {
            SLGLayerConfigMgr layerCfgMgr = SLGLayerConfigMgr.S;
            layerCfgMgr.LoadDefaultConfig();
            layerCfgMgr.Init();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SyncSLGRootGridProperty(Grid grid)
        {
            if (grid == null)
                return;

            grid.cellSize = new Vector3(SLGDefine.SLG_GRID_UNIT_SIZE, SLGDefine.SLG_GRID_UNIT_SIZE, 0);
            grid.cellLayout = GridLayout.CellLayout.Rectangle;
            grid.cellSwizzle = GridLayout.CellSwizzle.XZY;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <returns></returns>
        public static float CalcSLGLayerPosYOffset(int layerIndex)
        {
            return (layerIndex + 1) * 0.01f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootGo"></param>
        /// <param name="layerName"></param>
        /// <param name="layerIndex"></param>
        public static void CreateSLGLayer(GameObject rootGo, string layerName, int layerIndex)
        {
            var layerGo = new GameObject(layerName);
            if (layerGo == null)
                return;

            layerGo.AddComponent<Tilemap>();
            layerGo.AddComponent<TilemapRenderer>();

            layerGo.transform.SetParent(rootGo.transform);
            SLGUtils.ResetTransfrom(layerGo.transform);

            float y = CalcSLGLayerPosYOffset(layerIndex);
            layerGo.transform.localPosition = new Vector3(0f, y, 0f);
        }
    }
}

