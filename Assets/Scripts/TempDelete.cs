using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TempDelete : MonoBehaviour {
    //Tanımlamalar
    public Button btn_Back;

    //Geçiçi komutların silinmesi
    void Start ()
    {
        btn_Back.onClick.AddListener(delegate { DeleteTemp(); });
    }
	
	void DeleteTemp ()
    {
       System.IO.File.WriteAllText(Application.persistentDataPath + @"/temp.txt", null);
    }
}
