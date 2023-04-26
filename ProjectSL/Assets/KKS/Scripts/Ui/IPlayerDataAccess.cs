using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerDataAccess
{
    PlayerStatus SavePlayerData();
    void LoadPlayerData(PlayerStatus _playerStatusData );
} // IPlayerDataAccess
