using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistor : JsonPersistor<PlayerData>
{
    public PlayerPersistor(): base("player_data")
    {

    }
}
