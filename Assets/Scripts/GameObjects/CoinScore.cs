using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used for storing the global variable value in a script so that it won't get changed when loading the next scene.
public class CoinScore
{
    //Global coinscore.
    public static int globalCoinScore { get; set; }
    public static int tempGlobalCoinScore{ get; set; }
    public static int globalTotalCoinScore{ get; set; }
    public static int tempglobalTotalCoinScore{ get; set; }

    public static bool flagCheck{ get; set; }
    //Small dragon 0, medium 1-3, large 3+
}
