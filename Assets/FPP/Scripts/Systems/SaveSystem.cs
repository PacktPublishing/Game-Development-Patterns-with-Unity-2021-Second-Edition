using System.IO;
using UnityEngine;
using FPP.Scripts.Core;
using System.Runtime.Serialization.Formatters.Binary;

namespace FPP.Scripts.Systems
{
    public class SaveSystem
    {
        private readonly string _filePath = Application.persistentDataPath + "/player.data";

        public void SavePlayer(Player player)
        {
            FileStream dataStream = new FileStream(_filePath, FileMode.Create);
            BinaryFormatter converter = new BinaryFormatter();

            converter.Serialize(dataStream, player);
            dataStream.Close();
        }
        
        public Player LoadPlayer()
        {
            if (File.Exists(_filePath))
            {
                FileStream dataStream = new FileStream(_filePath, FileMode.Open);
                BinaryFormatter converter = new BinaryFormatter();
                Player playerData = converter.Deserialize(dataStream) as Player;

                dataStream.Close();
                return playerData;
            }
            return null;
        }

        public void DeleteSave()
        {
            if (File.Exists(_filePath)) 
                File.Delete(_filePath);
        }
    }
}