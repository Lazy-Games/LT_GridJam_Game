using HexGridGame.DataModels;
using HexGridGame.Scriptables;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionsReferences : MonoBehaviour
{
    [SerializeField] private BiomesCollection _biomesCollection;
    [SerializeField] private ResourcesCollection _resourcesCollection;
    [SerializeField] private NightEventsCollection _nightEventsCollection;
    [SerializeField] private OfferingsCollection _offeringsCollection;

    public static CollectionsReferences Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public BiomesCollection BiomesCollection { get => _biomesCollection; set => _biomesCollection = value; }
    public ResourcesCollection ResourcesCollection { get => _resourcesCollection; set => _resourcesCollection = value; }
    public NightEventsCollection NightEventsCollection { get => _nightEventsCollection; set => _nightEventsCollection = value; }
    public OfferingsCollection OfferingsCollection { get => _offeringsCollection; set => _offeringsCollection = value; }

    public Biome GetBiomeFromType(BiomeType type)
    {
        return _biomesCollection.Biomes.FirstOrDefault(b => b.BiomeType == type);
    }    
}
