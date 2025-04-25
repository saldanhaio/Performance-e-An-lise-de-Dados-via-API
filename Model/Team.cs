using System.Collections.Generic;

namespace CodeconChallenge.Model
{
public class Team
{
    public string? Name { get; set; }

    public bool Leader { get; set; }    

    public List<Project> Projects { get; set; } = new List<Project>();  
}

}