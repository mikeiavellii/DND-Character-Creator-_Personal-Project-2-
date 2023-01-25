namespace Personal_Procject_2_DND_Character_Creator
{
  public class You
  {
    //properties
    public string Name { get; set; }
    public string Race { get; set; }
    public string Class { get; set; }

    //Constructor
    public You(string _name, string _race, string _class)
    {
      Name = _name;
      Race = _race;
      Class = _class;
    }
  }
}
