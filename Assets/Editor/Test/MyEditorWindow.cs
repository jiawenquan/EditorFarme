using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MyEditorWindow: EditorWindow
{

    //[MenuItem("GameObject/window")]
    static void AddWindow()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 500, 500);
        MyEditorWindow window = (MyEditorWindow)EditorWindow.GetWindowWithRect(typeof(MyEditorWindow), wr, true, "窗口名字");
        window.Show();

    }


    GameObject obj;
    //输入文字的内容
    private string text;
    //选择贴图的对象
    private Texture texture;

    public void Awake()
    {
        //在资源中读取一张贴图
        texture = Resources.Load("1") as Texture;
    }


    //绘制窗口时调用
    void OnGUI()
    {
        //输入框控件
        EditorGUILayout.TextField("输入文字:", text);
        EditorGUILayout.TextField("请输入文字",text);


        obj = EditorGUILayout.ObjectField("添加对象", obj, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("打开通知", GUILayout.Width(200)))
        {
            //打开一个通知栏
            this.ShowNotification(new GUIContent("这是一个通知栏"));
            //this.ShowNotification(new GUIContent("This is a Notification"));
        }

        if (GUILayout.Button("关闭通知", GUILayout.Width(200)))
        {
            //关闭通知栏
            this.RemoveNotification();
        }

        //文本框显示鼠标在窗口的位置
        EditorGUILayout.LabelField("鼠标在窗口的位置", Event.current.mousePosition.ToString());

        //选择贴图
        texture = EditorGUILayout.ObjectField("添加贴图", texture, typeof(Texture), true) as Texture;

        if (GUILayout.Button("关闭窗口", GUILayout.Width(200)))
        {
            //关闭窗口
            this.Close();
        }

    }

    //更新
    void Update()
    {

    }



    void OnFocus()
    {
        Debug.Log("当窗口获得焦点时调用一次");
    }

    

    void OnLostFocus()
    {
        Debug.Log("当窗口丢失焦点时调用一次");
    }

    void OnHierarchyChange()
    {
        Debug.Log("当Hierarchy视图中的任何对象发生改变时调用一次");
    }

    void OnProjectChange()
    {
        Debug.Log("当Project视图中的资源发生改变时调用一次");
    }

    void OnInspectorUpdate()
    {
        //Debug.Log("窗口面板的更新");
        //这里开启窗口的重绘，不然窗口信息不会刷新
        this.Repaint();
     
    }

    void OnSelectionChange()
    {
        //当窗口出去开启状态，并且在Hierarchy视图中选择某游戏对象时调用
        foreach (Transform t in Selection.transforms)
        {
            //有可能是多选，这里开启一个循环打印选中游戏对象的名称
            Debug.Log("OnSelectionChange" + t.name);
        }
    }

    void OnDestroy()
    {
        Debug.Log("当窗口关闭时调用");
    }

}
