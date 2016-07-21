using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssetsTest : MonoBehaviour {

    private AssetBundleCreateRequest request;
    public float mDelayTime = 5f;
    private string mShaderName = "shareshader";
    private List<string> mNameList = new List<string>();
    private int mLoadedIndex = 0;
    private string mCurLoadName;
    private float mStartTime;
    private bool isLoadShader = false;

    // Use this for initialization
    void Start () {
        mNameList.Add("m_000_000");
        mNameList.Add("m_000_001");
        mNameList.Add("m_000_003");
        mNameList.Add("m_000_012");
        mNameList.Add("m_001_000");
        mNameList.Add("m_002_000");
        mNameList.Add("m_003_000");
        mNameList.Add("m_004_000");
        mNameList.Add("m_006_000");
        mNameList.Add("m_008_000");
        mNameList.Add("m_009_000");
        mNameList.Add("m_011_000");
        mNameList.Add("m_012_000");
        mNameList.Add("m_013_000");
    }
	
	// Update is called once per frame
	void Update () {
        if (mDelayTime > 0)
        {
            mDelayTime -= Time.deltaTime;
            if (mDelayTime <= 0)
            {
                mStartTime = Time.time;
                Debug.Log("Start Load");
                //LoadNextAsset();
                LoadShareShader();
            }
        }

        if (request != null && request.isDone)
        {
            if (!isLoadShader)
            {
                GameObject go = request.assetBundle.LoadAsset<GameObject>(mCurLoadName);
                GameObject ins = GameObject.Instantiate(go);
                request.assetBundle.Unload(false);
            }
            else
            {
                isLoadShader = false;
            }
         
            LoadNextAsset();
        }
	}

    private void LoadShareShader()
    {
        isLoadShader = true;
        request = AssetBundle.LoadFromFileAsync("Assets/AssetBundles/" + mShaderName + ".bytes");
    }

    private void LoadNextAsset()
    {
        if (mLoadedIndex >= mNameList.Count)
        {
            request = null;

            Debug.Log("End Load : " + ((Time.time - mStartTime) * 1000) + "ms");
            return;
        }
        mCurLoadName = mNameList[mLoadedIndex];
        request = AssetBundle.LoadFromFileAsync("Assets/AssetBundles/" + mCurLoadName + ".bytes");
        mLoadedIndex += 1;
    }
}
