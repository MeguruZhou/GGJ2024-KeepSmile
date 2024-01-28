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
        // ����Process
        process = new Process();
        // ����ProcessStartInfo����
        startInfo = new ProcessStartInfo();
        process.StartInfo = startInfo;
        // �趨ִ��cmd
        //startInfo.FileName = @"E:/DTprediction/Library/PythonInstall/python.exe";
        startInfo.FileName = Application.streamingAssetsPath + "/main.exe";
        // �����������һ����command�ַ���
        //startInfo.Arguments = pythonPath;
        // ��ΪǶ��Unity�к�̨ʹ�ã��������ò���ʾ����
        startInfo.CreateNoWindow = true;
        // ������Ҫ�趨Ϊfalse
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardInput = true;     //��������
        // �����ض���������̵ı�׼�����������ֱ�ӱ�Unity C#���񣬴Ӷ�ʵ�� Python -> Unity ��ͨ��
        startInfo.RedirectStandardOutput = true;
        // �����ض���������̵ı�׼��������������Unity��C#�н���Debug Python���bug
        startInfo.RedirectStandardError = true;
        //process.StandardInput.AutoFlush = true;//ÿ�ε��� Write()֮�󣬽��仺����ˢ�µ�������
        process.OutputDataReceived += new DataReceivedEventHandler(OnOutputDataReceived);
        process.ErrorDataReceived += new DataReceivedEventHandler(OnErrorDataReceived);

        //�����ű�Process�����Ҽ������ж�ȡ����뱨��
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
