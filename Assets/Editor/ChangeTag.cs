using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ChangeTag : EditorWindow
{

    [MenuItem("Menu/批量修改子物体Tag")]
    static void AddWindow()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 400, 500);
        ChangeTag window = (ChangeTag)EditorWindow.GetWindowWithRect(typeof(ChangeTag), wr, true, "批量修改父子物体Tag");
        window.Show();

    }


    GameObject obj;  //储存父物体
    //Tag 
    private string tagName;


    void Start()
    {
        this.ShowNotification(new GUIContent("请先提前创建Tag"));
    }
    //绘制窗口时调用
    void OnGUI()
    {
        
        obj =(GameObject)EditorGUILayout.ObjectField("要修改物体:", obj, typeof(GameObject), true);


        //输入框控件 //获取到输入的 Tag
        tagName = EditorGUILayout.TextField("请输入tag:", tagName);
        
        //是否按下按钮 
        if (GUILayout.Button("一键修改", GUILayout.Width(200)))
        {

            //判断是否拖入对象
            if (obj==null)
            {
                this.ShowNotification(new GUIContent("请拖入要操作的物体"));
            }else
            {

                //判断是否输入了 TagName
                if (tagName == ""||tagName==null)
                {
                    this.ShowNotification(new GUIContent("请先输入Tagname"));
                }
                else
                {
                    if (isHasTag(tagName))
                    {
                        AddTag(tagName);      //添加一个标签
                        Change(obj, tagName.Trim());  //修改选中物体的标签
                        this.ShowNotification(new GUIContent("修改成功"));
                    }
                    else
                    {
                        this.ShowNotification(new GUIContent("请先先创建出这个Tag"));
                    }

                }
                
            }

        }

    }
    #region MyRegion
    //添加一个 Tag  新版本unity 占时不能用
    void AddTag(string tag)
    {
        if (!isHasTag(tag))
        {
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            SerializedProperty it = tagManager.GetIterator();
            while (it.NextVisible(true))
            {
                if (it.name == "tags")
                {
                    for (int i = 0; i < it.arraySize; i++)
                    {
                        SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
                        if (string.IsNullOrEmpty(dataPoint.stringValue))
                        {
                            dataPoint.stringValue = tag;
                            tagManager.ApplyModifiedProperties();
                            return;
                        }
                    }
                }
            }
        }
    }
    #endregion


    //如果已有 tag 返回 True  没有 返回 fasle
    bool isHasTag(string tag)
    {
        for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++)
        {
            if (UnityEditorInternal.InternalEditorUtility.tags[i].Contains(tag))
                return true;
        }
        return false;
    }

    //把传入的 物体 与其子物体 全部修改 tag
    void Change(GameObject obj,string tag)
    {

        foreach (Transform item in obj.GetComponentsInChildren<Transform>())
        {
            Debug.Log(tag+"标签");
            item.tag = tag;

        }
    }




}
