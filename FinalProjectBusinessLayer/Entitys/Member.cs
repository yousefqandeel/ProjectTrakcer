using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Entitys
{
    /// <summary>
    /// Member info to inherit from it
    /// </summary>
    public class Member : IdentityUser
    {
        public string FullName { get; set; }
        public List<ProjectMembers> ProjectMembers { get; set; }
    }
}
