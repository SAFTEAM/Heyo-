using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using Assets.Scripts;
public class Command_Scene : MonoBehaviour
{
    public Font Komikax;

    public Button btn_Forward;
    public Button btn_Right;
    public Button btn_Left;
    public Button btn_For;
    public Button btn_If;
    public Button btn_Clean;
    public Button btn_Run;
    public Button btn_Map;

    public InputField inp_Forward;
    public InputField inp_Right;
    public InputField inp_Left;
    public InputField inp_For;
    public InputField inp_If;
    Vector2 scrollPosition;
    public string Screen_commands = "";
    public string[] Received_commands;
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + @"/temp.txt"))
        {
            Received_commands = System.IO.File.ReadAllLines(Application.persistentDataPath + @"/temp.txt");

            for (int i = 0; i < Received_commands.Length; i++)
            {
                Screen_commands += Received_commands[i] + Environment.NewLine;
            }
            System.IO.File.WriteAllText(Application.persistentDataPath + @"/temp.txt", null);
        }

        btn_Run.onClick.AddListener(delegate { SavetoTXT(Screen_commands); });

        btn_Map.onClick.AddListener(delegate { SaveTemptoTXT(Screen_commands); });

        btn_Right.onClick.AddListener(() =>
        {
            for (int i = 0; i < Convert.ToInt32(inp_Right.text); i++)
            {
                Step("Saga Don" + Environment.NewLine);
            }
            inp_Right.text = "";
        });

        btn_Left.onClick.AddListener(() =>
        {
            for (int i = 0; i < Convert.ToInt32(inp_Left.text); i++)
            {
                Step("Sola Don" + Environment.NewLine);
            }
            inp_Left.text = " ";
        });

        btn_Forward.onClick.AddListener(() =>
        {
            for (int i = 0; i < Convert.ToInt32(inp_Forward.text); i++)
            {
                Step("Ilerle" + Environment.NewLine);
            }
            inp_Forward.text = " ";
        });

        btn_For.onClick.AddListener(() =>
        {
            for (int i = 0; i < Convert.ToInt32(inp_For.text); i++)
            {
                Step("Dongu" + Environment.NewLine);
            }
            inp_For.text = " ";
        });

        btn_If.onClick.AddListener(() =>
        {
            for (int i = 0; i < Convert.ToInt32(inp_If.text); i++)
            {
                Step("Eger" + Environment.NewLine);
            }
            inp_If.text = " ";
        });

        btn_Clean.onClick.AddListener(() =>
        {
            Screen_commands = "";
        });

    }
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();//textarea
        myStyle.font = Komikax;
        myStyle.fontSize = 25;
        myStyle.fontStyle = FontStyle.Bold;

        GUILayout.BeginArea(new Rect(180, 90, 900, 500), myStyle);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(900), GUILayout.Height(500));
        GUI.skin.box.wordWrap = true;
        GUI.skin.box.alignment = TextAnchor.UpperLeft;
        GUI.skin.box.fontSize = 25;
        GUI.skin.box.font = Komikax;
        GUILayout.Box(Screen_commands);
        GUILayout.EndScrollView();
        GUILayout.EndArea();
        //   GUI.enabled = false;
        // Screen_commands=GUI.TextArea(new Rect(140, 90, 900, 500), Screen_commands,200,myStyle);    
    }
    void Step(string deger)
    {
        Screen_commands += deger;
    }
    void SavetoTXT(string yazilacak)
    {
        System.IO.File.WriteAllText(Application.persistentDataPath + @"/commandsave.txt", yazilacak);
        System.IO.File.WriteAllText(Application.persistentDataPath + @"/temp.txt", null);
    }
    void SaveTemptoTXT(string gecici)
    {
        System.IO.File.AppendAllText(Application.persistentDataPath + @"/temp.txt", gecici);
    }
}