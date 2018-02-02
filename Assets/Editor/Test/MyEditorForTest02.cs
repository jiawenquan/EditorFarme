using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
///自定义Tset脚本   作用于指定的类
[CustomEditor(typeof(Test02))]

////在编辑模式下执行脚本
[ExecuteInEditMode]
public class MyEditorForTest02 : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ////得到Test对象
        Test02 test02 = (Test02)target;

        //绘制一个窗口
        test02.mRectValue = EditorGUILayout.RectField("窗口坐标",test02.mRectValue);
        //绘制一个贴图槽
        test02.texture = EditorGUILayout.ObjectField("增加一个贴图",test02.texture,typeof(Texture),true) as Texture;
    }


}
