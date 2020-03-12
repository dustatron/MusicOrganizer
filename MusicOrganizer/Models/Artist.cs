using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> { };
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Id { get; }
    public List<Album> Albums { get; set; }
    private static int _count = 0;

    public Artist(string artistName, string genre)
    {
      Name = artistName;
      Genre = genre;
      _instances.Add(this);
      Id = _count++;
      Albums = new List<Album> { };

    }

  }
}