using System.IO;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Input
{
    public class InputRecorder : MonoBehaviour
    {
        private float _replayTime;
        private bool _isReplaying;
        private BikeController _bikeController;
        private SortedList<float, Command> _commands = new SortedList<float, Command>();

        private void Start()
        {
            _bikeController = FindObjectOfType<BikeController>();
        }

        private void LoadFile()
        {
            if (!File.Exists(Application.dataPath + "/replay.bin")) return;
            byte[] bytes = File.ReadAllBytes(Application.dataPath + "/replay.bin");

            //_commands = SerializationUtility.DeserializeValue<SortedList<float, Command>>(bytes, DataFormat.Binary);
            Debug.Log(_commands.Count);

            _isReplaying = true;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R)) 
                LoadFile();
        }

        void FixedUpdate()
        {
            if (_isReplaying)
            {
                _replayTime += Time.deltaTime;
                if (_commands.Any())
                {
                    if (Mathf.Approximately(_replayTime, _commands.Keys[0]))
                    {
                        _commands.Values[0].Replay(_bikeController);
                        _commands.RemoveAt(0);
                    }
                }
            }
        }
    }
}