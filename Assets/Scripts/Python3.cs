using System.Diagnostics;
using System.Text;
using UnityEngine;
using System;

public class Python3 : MonoBehaviour
{
    private ProcessStartInfo startInfo;
    private Process process;
    private static StringBuilder output = new StringBuilder();
    private string a;

    public int testGetBool;

    void Start()
    {
        UnityEngine.Debug.Log(Application.streamingAssetsPath + "/main.exe");
        // 创建Process
        process = new Process();
        // 创建ProcessStartInfo对象
        startInfo = new ProcessStartInfo();
        process.StartInfo = startInfo;
        // 设定执行cmd
        //startInfo.FileName = @"E:/DTprediction/Library/PythonInstall/python.exe";
        startInfo.FileName = Application.streamingAssetsPath + "/main.exe";
        // 输入参数是上一步的command字符串
        //startInfo.Arguments = pythonPath;
        // 因为嵌入Unity中后台使用，所以设置不显示窗口
        startInfo.CreateNoWindow = true;
        // 这里需要设定为false
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardInput = true;     //打开流输入
        // 设置重定向这个进程的标准输出流，用于直接被Unity C#捕获，从而实现 Python -> Unity 的通信
        startInfo.RedirectStandardOutput = true;
        // 设置重定向这个进程的标准报错流，用于在Unity的C#中进行Debug Python里的bug
        startInfo.RedirectStandardError = true;
        //process.StandardInput.AutoFlush = true;//每次调用 Write()之后，将其缓冲区刷新到基础流
        process.OutputDataReceived += new DataReceivedEventHandler(OnOutputDataReceived);
        process.ErrorDataReceived += new DataReceivedEventHandler(OnErrorDataReceived);

        //启动脚本Process，并且激活逐行读取输出与报错
        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();
    }
    private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            output.Clear();
            output.Append(e.Data);
            //UnityEngine.Debug.Log(output.ToString());
            a = output.ToString();
        }
    }

    private void Update()
    {
        try
        {
            testGetBool += 1;
            if (testGetBool >= 2)
            {
                testGetBool = 0;
                float b = float.Parse(a);
                //UnityEngine.Debug.Log(b);
                SmileCheckManager.Instance.SetSmileFloat(b);
            }
        }
        catch (Exception)
        {

        }
    }
    private void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            UnityEngine.Debug.LogError("Received error output: " + e.Data);
        }
    }
    private void OnApplicationQuit()
    {
        UnityEngine.Debug.Log("Unity Quit");
        UnityEngine.Debug.Log(process.ProcessName);
        Process[] processes = Process.GetProcessesByName("main");
        foreach (Process process in processes)
        {
            process.Kill();
        }
    }

}
