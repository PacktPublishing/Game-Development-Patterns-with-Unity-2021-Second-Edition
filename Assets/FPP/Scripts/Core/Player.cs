using System;

[Serializable]
public class Player
{
    public int currentTrack;
    public string playerName;
    public string playerUid; // TODO: Implement a UID generator
    public TimeSpan lastSessionDuration;
}