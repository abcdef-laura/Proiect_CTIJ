using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health =3;

    public UnityEngine.UI.Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    

    void Update()
    {
        foreach (UnityEngine.UI.Image img in hearts)
        {
            img.sprite = emptyHeart;
        
        }
        for( int i=0;i<health;i++)
        {
            hearts[i].sprite=fullHeart; 
        }
    }
}
