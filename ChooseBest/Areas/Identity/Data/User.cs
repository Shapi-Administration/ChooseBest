using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChooseBest.Models;
using Microsoft.AspNetCore.Identity;

namespace ChooseBest.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public bool VotePlayer { get; set; } = false;
    public bool VoteTeam { get; set; } = false;
    public bool VoteTrainer { get; set; } = false;
    public Guid? ChosenPlayer { get; set; }
    public Guid? ChosenTeam { get; set; }
    public Guid? ChosenTrainer { get; set; }
}

