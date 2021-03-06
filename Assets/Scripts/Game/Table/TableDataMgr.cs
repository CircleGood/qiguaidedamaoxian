// **********************************************************************
// 
// 文件名(File Name)：             TableDataMgr
// 
// 作者(Author)：                  Circle
// 
// 创建时间(CreateTime):           2016/11/6 17:56:16
//
// 网址：                          http://blog.csdn.net/u013108312
//
// **********************************************************************

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Assets.Scripts.MyFramwork.UIMgr;

public class TableDataMgr : MonoBehaviour , ILoadUIListener
{
    public static TableDataMgr Instance
    {
        private set;
        get;
    }

    /// <summary>
    /// 要加载的配置表
    /// </summary>
    private List<TableDateBase> mLoadTables = new List<TableDateBase>();

    

	void Awake()
	{
        Instance = this;

//         buffCfg = new BuffCfg("Buff");
//         equipmentCfg = new EquipmentCfg("Equipment");
//         goodsCfg = new GoodsCfg("Goods");
//         monsterCfg = new MonsterCfg("Monster");
//         monsterSkillCfg = new MonsterSkillCfg("MonsterSkill");
//         skillCfg = new SkillCfg("Skill");
        UIMgr.Instance.ShowUI(UIDef.StartUI, typeof(StartCtrl), this);
        return;

        for (int i = 0; i < mLoadTables.Count;i++ )
        {
            ResMgr.Instance.Load(mLoadTables[i].tableName,mLoadTables[i]);
        }

	}
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
	
    #region 读取配置表基类

    public class TableDateBase : IResLoadListener
    {
        public string tableName;

        public TableDateBase(string tableName)
        {
            this.tableName = tableName;
            Instance.mLoadTables.Add(this);
        }

        public void Finish(object asset)
        {
            Debug.LogError("000000000000");
            Log.Debug("tableName" + tableName + "/Instance.mLoadTables =" + Instance.mLoadTables.Count);
            TextAsset text = asset as TextAsset;
            if (text == null)
            {
                Log.Error("读取配置表失败 tableName：" + tableName);
            }
            else
            {
                ExtractJson(text.text);
            }

            Instance.mLoadTables.Remove(this);

            if (Instance.mLoadTables.Count == 0)
            {
                //EntranceSceneCtrl.Instance.SendEvent(EventDef.TableDataFinish);
            }
        }

        public void Failure()
        {
        }

        /// <summary>
        /// 解析json数据
        /// </summary>
        /// <param name="json">json字符串</param>
        protected virtual void ExtractJson(string json)
        {

        }
    }
#endregion


    public void FiniSh(BaseUI ui)
    {
    }

    public void Failure()
    {
    }
}
