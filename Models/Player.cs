
using System;
namespace c_sharp_asp_net_core_player_tracker.Models;


public class Player
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string club { get; set; }
    public int salary { get; set; }

    public Player()
    {

    }
}