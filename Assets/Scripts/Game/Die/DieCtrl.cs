// **********************************************************************
// 
// 文件名(File Name)：             DieCtrl
// 
// 作者(Author)：                  Circle
// 
// 创建时间(CreateTime):           2016/12/18 21:18:37
//
// 网址：                          http://blog.csdn.net/u013108312
//
// **********************************************************************

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts.MyFramwork.UIMgr;

public class DieCtrl : BaseUI , ILoadUIListener
{
    private int mCurrentLevel = 1;
    private int mDieNum = 0;
    private readonly List<string> mFindNames = new List<string>() { "Score", "BtnRestarat" };
    private Text mScoreText;
    protected override void OnInit()
    {
        List<Transform> findTrans = new List<Transform>();
        ComUtil.GetTransformInChild(mFindNames, CacheTransform, ref findTrans);
        for (int i = 0; i < findTrans.Count;i++ )
        {
            if (findTrans[i].name.Equals(mFindNames[0]))
            {
                mScoreText = findTrans[i].GetComponent<Text>();
            }
            else
            {
                Button btn = findTrans[i].GetComponent<Button>();
                btn.onClick.AddListener(OnRestartClick);
            }
        }
    }

    /// <summary>
    /// 重新开始
    /// </summary>
    private void OnRestartClick()
    {
        UIMgr.Instance.DestroyUI(UIDef.GetLevelName(mCurrentLevel));
        UIMgr.Instance.ShowUI(UIDef.GetLevelName(mCurrentLevel), typeof(LevelMgr), this,mCurrentLevel);
    }

    protected override void OnAwake()
    {
        
    }

    protected override void OnShow(object param)
    {
        int level = (int)param;
        if (level != mCurrentLevel)
        {
            mDieNum = 0;
        }
        else
        {
            mDieNum += 1;
        }
        mScoreText.text = (250 - 50 * mDieNum).ToString();
    }

    protected override void OnHide()
    {

    }

    protected override void OnDestroy()
    {
    }

    public void FiniSh(BaseUI ui)
    {
        UIMgr.Instance.HideUI(this.UIName);
    }

    public void Failure()
    {
    }
}
