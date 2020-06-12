using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName =("Heart Sprite Config"))]

public class HeartSpritesConfig : ScriptableObject
{
    [SerializeField] Sprite[] heartSpritesArray = default;

    public List<Sprite> GetHeartSprites()
    {
        var heartSprite = new List<Sprite>();
        foreach (Sprite child in heartSpritesArray)
        {
            heartSprite.Add(child);
        }
        return heartSprite;
    }

}
