using UnityEngine.Events;
using System.Collections.Generic;

namespace Chapter.EventBus
{
    public class RaceEventBus : Singleton<RaceEventBus>
    {
        private Dictionary<RaceEventType, UnityEvent> _eventDictionary;

        public override void Awake()
        {
            base.Awake();
            Instance.Init();
        }

        private void Init()
        {
            if (Instance._eventDictionary == null)
            {
                Instance._eventDictionary = new Dictionary<RaceEventType, UnityEvent>();
            }
        }

        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance._eventDictionary.Add(eventType, thisEvent);
            }
        }

        public static void Unsubscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(RaceEventType eventType)
        {
            UnityEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}