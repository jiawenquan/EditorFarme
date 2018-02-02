using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//自定义Tset脚本   作用于指定的类
[CustomEditor(typeof(Test))]
public class MyEditorForTest : Editor {

    void OnSceneGUI()
    {
        //得到test脚本的对象
        Test test = (Test)target;

        //绘制文本框显示物体名字 加坐标   第一个是文字显示的坐标信息    第二个是名字 第三个是  
        Handles.Label(test.transform.position + Vector3.up * 2,
                   test.transform.name + " : " + test.transform.position.ToString());

        //开始绘制GUI
        Handles.BeginGUI();

        //规定GUI显示区域
        GUILayout.BeginArea(new Rect(100, 100, 120, 100));

        //GUI绘制一个按钮
        if (GUILayout.Button("这是一个按钮!"))
        {
            Debug.Log("test");
        }
        //GUI绘制文本框
        GUILayout.Label("我在编辑Scene视图");

        GUILayout.EndArea();

        Handles.EndGUI();
    }
}
