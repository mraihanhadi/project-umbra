using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnHandler : MonoBehaviour
{
    public List<CharacterData> allCharacters;
    public Transform spawnPoint;
    public GameObject characterPrefab;
    public List<RarityChance> rarityChances;

    public GameObject profileUI;
    public CharacterProfile profileScript;

    private GameObject currentCharacter;
    private CharacterManager characterManager;

    [System.Serializable]
    public class RarityChance
    {
        public Rarity rarity;
        public float chance;
    }

    void Start()
    {
        characterManager = GameManager.Instance.characterManager;
        SpawnCharacter();
    }

    public void SpawnCharacter()
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        CharacterData chosenData = GetRandomCharacterByRarity();
        if (chosenData == null)
        {
            Debug.LogWarning("No available characters left to spawn.");
            return;
        }

        GameObject character = Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
        CharacterClickHandler clickHandler = character.GetComponent<CharacterClickHandler>();
        clickHandler.characterData = chosenData;
        clickHandler.profile = profileScript;
        clickHandler.profileUI = profileUI;

        currentCharacter = character;
    }

    CharacterData GetRandomCharacterByRarity()
    {
        float totalChance = 0f;
        foreach (var rc in rarityChances) totalChance += rc.chance;

        float roll = Random.Range(0f, totalChance);
        float cumulative = 0f;
        Rarity selectedRarity = Rarity.Common;

        foreach (var rc in rarityChances)
        {
            cumulative += rc.chance;
            if (roll <= cumulative)
            {
                selectedRarity = rc.rarity;
                break;
            }
        }

        List<CharacterData> available = allCharacters.FindAll(c =>
            c.rarity == selectedRarity &&
            !characterManager.IsChosenSent(c.chosenName) // <- check if already sent
        );

        if (available.Count == 0) return null;
        return available[Random.Range(0, available.Count)];
    }
}

