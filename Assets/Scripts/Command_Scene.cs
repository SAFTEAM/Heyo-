using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using Assets.Scripts;
public class Command_Scene : MonoBehaviour
{
    //Yazı Fontu
    public Font Komikax;
    //Butonlar
    public Button btn_Forward;
    public Button btn_Right;
    public Button btn_Left;
    public Button btn_For;
    public Button btn_If;
    public Button btn_For2;
    public Button btn_If2;
    public Button btn_Clean;
    public Button btn_Run;
    public Button btn_Map;
    //Input Field Tanımları
    public InputField inp_Forward;
    public InputField inp_Right;
    public InputField inp_Left;
    public InputField inp_For;
    public InputField inp_If;
    //Kullanılan Değişkenler
    ArrayList gecici;
    Vector2 scrollPosition;
    bool basildi=false;
    int tekrar_degeri;
    public string Screen_commands = "";
    public string[] Received_commands;
    private string ekran_yazi = "";


    void Start()
    {
    //Sahneler arası geçiş kontrolü
    gecici = new ArrayList();
      
        if (File.Exists(Application.persistentDataPath + @"/temp.txt"))
        {
            Received_commands = System.IO.File.ReadAllLines(Application.persistentDataPath + @"/temp.txt");

            for (int i = 0; i < Received_commands.Length; i++)
            {                
                Screen_commands += Received_commands[i] + Environment.NewLine;
            }
           System.IO.File.WriteAllText(Application.persistentDataPath + @"/temp.txt", null);
        }
        //Buton Tıklanma Durumları
        btn_Run.onClick.AddListener(delegate { SavetoTXT(Screen_commands); });

        btn_Map.onClick.AddListener(delegate { SaveTemptoTXT(Screen_commands); });

        btn_Right.onClick.AddListener(() =>
        {
            //For butonuna basıldığında yapılacak işlem
            if (basildi)
            {
                for (int i = 0; i < Convert.ToInt32(inp_Right.text); i++)
                {
                    gecici.Add("Saga Don");                   
                }
                ekran_yazi += inp_Right.text + " kere Saga Don" + Environment.NewLine;
                Step(inp_Right.text + " kere Saga Don"+ Environment.NewLine);
                inp_Right.text = " ";
            }
            //Diğer durumlarda yapılacak işlem
            else
            {
                for (int i = 0; i < Convert.ToInt32(inp_Right.text); i++)
                {
                    Step("Saga Don" + Environment.NewLine);
                }
                ekran_yazi += inp_Right.text + " kere Saga Don" + Environment.NewLine;
                inp_Right.text = "";
            }         
        });

        btn_Left.onClick.AddListener(() =>
        {
            //For butonuna basıldığında yapılacak işlem
            if (basildi)
            {
                for (int i = 0; i < Convert.ToInt32(inp_Left.text); i++)
                {
                    gecici.Add("Sola Don");
                }
                ekran_yazi += inp_Left.text + " kere Sola Don" + Environment.NewLine;
                Step(inp_Left.text + " kere Sola Don" + Environment.NewLine);
                inp_Left.text = " ";
            }
            //Diğer durumlarda yapılacak işlem
            else
            {
                for (int i = 0; i < Convert.ToInt32(inp_Left.text); i++)
                {
                    Step("Sola Don" + Environment.NewLine);
                }
                ekran_yazi += inp_Left.text + " kere Sola Don" + Environment.NewLine;
                inp_Left.text = " ";
            }         
        });

        btn_Forward.onClick.AddListener(() =>
        {
            //For butonuna basıldığında yapılacak işlem
            if (basildi)
            {
                for (int i = 0; i < Convert.ToInt32(inp_Forward.text); i++)
                {
                    gecici.Add("Ilerle");                  
                }
                ekran_yazi += inp_Forward.text + " kere Ilerle." + Environment.NewLine;
                Step(inp_Forward.text + " kere Ilerle."+ Environment.NewLine);
                inp_Forward.text = " ";
            }
            //Diğer durumlarda yapılacak işlem
            else
            {
                for (int i = 0; i < Convert.ToInt32(inp_Forward.text); i++)
                {
                    Step("Ilerle" + Environment.NewLine);
                }
                ekran_yazi += inp_Forward.text + " kere Ilerle." + Environment.NewLine;
                inp_Forward.text = " ";
            }           
        });
        btn_For.onClick.AddListener(() =>
        {
            //For işlemine başlanıldığında 
            basildi = true;
            tekrar_degeri =Convert.ToInt32( inp_For.text);
            ekran_yazi += "Dongu Basladi. " + inp_For.text + " kere tekrar olacak." + Environment.NewLine;
            Step("Dongu Basladi. " + inp_For.text + " kere tekrar olacak." + Environment.NewLine);
            inp_For.text = " ";
            btn_For2.gameObject.SetActive(true);
            btn_Run.interactable = false;
            btn_For.gameObject.SetActive(false);
            
        });
        btn_For2.onClick.AddListener(() =>
        {
            //For işlemi bittiğinde 
            basildi = false;
            for (int k = 0; k < tekrar_degeri; k++)
            {
                for (int j = 0; j < gecici.Count; j++)
                {
                    Step(gecici[j] + Environment.NewLine);
                }
            }
            ekran_yazi += "Dongu Bitti" + Environment.NewLine;
            Step("Dongu Bitti" + Environment.NewLine);
            inp_For.text = " ";
            btn_For.gameObject.SetActive(true);
            btn_Run.interactable = true;
            btn_For2.gameObject.SetActive(false);
        });

        btn_If.onClick.AddListener(() =>
        {
            //If işlemine başlanıldığında 
            for (int i = 0; i < Convert.ToInt32(inp_If.text); i++)
            {
                Step("Eger Basla" + Environment.NewLine);
            }
            ekran_yazi += "Eger Basladı" + Environment.NewLine;
            Step("Eger Basladı." + Environment.NewLine);
            inp_If.text = " ";
            btn_If2.gameObject.SetActive(true);
            btn_Run.interactable = false;
            btn_If.gameObject.SetActive(false);
        });       

        btn_If2.onClick.AddListener(() =>
        {
            //If işlemi bittiğinde
            for (int i = 0; i < Convert.ToInt32(inp_If.text); i++)
            {
                Step("Eger Bitir" + Environment.NewLine);
            }
            ekran_yazi += "Eger Bitti"+ Environment.NewLine;
            Step("Eger Bitti" + Environment.NewLine);
            inp_If.text = " ";
            btn_If.gameObject.SetActive(true);
            btn_Run.interactable = true;
            btn_If2.gameObject.SetActive(false);
        });

        btn_Clean.onClick.AddListener(() =>
        {
            ekran_yazi = "";
            Screen_commands = "";
        });

    }
    void OnGUI()
    {
        //Komut Ekranı Stili
        GUIStyle myStyle = new GUIStyle();
        myStyle.font = Komikax;
        myStyle.fontSize = 25;
        myStyle.fontStyle = FontStyle.Bold;

        GUILayout.BeginArea(new Rect(180, 90, 900, 500), myStyle);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(900), GUILayout.Height(500));

        //Ekran oluşturma ayarları
        GUI.skin.box.wordWrap = true;
        GUI.skin.box.alignment = TextAnchor.UpperLeft;
        GUI.skin.box.fontSize = 25;
        GUI.skin.box.font = Komikax;

        GUILayout.Box(ekran_yazi);
        GUILayout.EndScrollView();
        GUILayout.EndArea();       
    }
    //Her adımın kayıt edilmesi
    void Step(string deger)
    {
        Screen_commands += deger;
    }
    //Komutların kaydedilmesi
    void SavetoTXT(string yazilacak)
    {
        System.IO.File.WriteAllText(Application.persistentDataPath + @"/commandsave.txt", yazilacak);
        System.IO.File.WriteAllText(Application.persistentDataPath + @"/temp.txt", null);
    }
    //Komutların geçiçi olarak kayıt edilmesi
    void SaveTemptoTXT(string gecici)
    {
        System.IO.File.AppendAllText(Application.persistentDataPath + @"/temp.txt", gecici);
    }
}