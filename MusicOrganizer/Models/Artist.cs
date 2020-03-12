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

    public static List<Artist> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _count = 0;
      _instances.Clear();
    }

    public static Artist Find(int id)
    {
      foreach (Artist artist in _instances)
      {
        if (artist.Id == id)
        {
          return artist;
        }
      }
      return _instances[0];
    }

    public static void Update(int id, string artistName, string genre)
    {
      Artist result = Find(id);
      result.Name = artistName;
      result.Genre = genre;
    }
    public static void Delete(int id)
    {
      Artist toRemove = Find(id);
      _instances.Remove(toRemove);
    }
  }
}