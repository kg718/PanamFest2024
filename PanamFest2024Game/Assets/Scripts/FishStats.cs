using System.Collections.Generic;
using UnityEngine;

public class FishStats : MonoBehaviour
{
    [SerializeField] private FishSize Size;
    [HideInInspector] public float Weight;
    [HideInInspector] public float Length;
    [HideInInspector] public string FishName;
    [HideInInspector] public Sprite FishSprite;

    [SerializeField] private List<string> FishNames;
    [SerializeField] private List<Sprite> FishSprites;

    private enum FishSize {Small, Medium, Large}

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CalculateValues()
    {
        float randomValue = Random.Range(0.4f, 0.9f);
        int FishSelection = Random.Range(0, FishSprites.Count);
        switch(Size)
        {
            case FishSize.Small:
                Weight = 1 * randomValue;
                Length = 0.7f * randomValue;
                break;
            case FishSize.Medium:
                Weight = 2.3f * randomValue;
                Length = 1.7f * randomValue;
                break;
            case FishSize.Large:
                Weight = 4 * randomValue;
                Length = 2.5f * randomValue;
                break;
        }
        FishName = FishNames[FishSelection];
        FishSprite = FishSprites[FishSelection];
    }
}
