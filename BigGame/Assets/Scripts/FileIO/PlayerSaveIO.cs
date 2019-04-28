using UnityEngine;

public static class CharacterSaveIO
{
    private static readonly string baseSavePath;

    static CharacterSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SaveCharacter(CharacterSaveData character, string fileName)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + fileName + ".dat", character);
    }

    public static CharacterSaveData LoadCharacter(string fileName)
    {
        string filePath = baseSavePath + "/" + fileName + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<CharacterSaveData>(filePath);
        }
        return null;
    }

}

public static class ItemSaveIO
{
    private static readonly string baseSavePath;

    static ItemSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SaveItems(ItemContainerSaveData items, string fileName)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + fileName + ".dat", items);
    }

    public static ItemContainerSaveData LoadItems(string fileName)
    {
        string filePath = baseSavePath + "/" + fileName + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<ItemContainerSaveData>(filePath);
        }
        return null;
    }
}
