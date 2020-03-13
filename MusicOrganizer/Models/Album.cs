using System.Collections.Generic;
using System;

namespace MusicOrganizer.Models
{
  public class Album
  {
    public string Title { get; set; }
    public int Year { get; set; }
    public string Label { get; set; }
    public string Img { get; set; }
    public int Id { get; }
    // private static List<Album> _instances = new List<Album> { };
    private static int _count = 0;

    public Album(string title, int year, string label, string img)
    {
      Title = title;
      Year = year;
      Label = label;
      Img = img;
      // _instances.Add(this);
      Id = _count++;

    }
    // public static List<Album> GetAll()
    // {

    //   return _instances;
    // }
    // public static void ResetAll()
    // {
    //   _count = 0;
    //   _instances.Clear();
    // }

    // public static Album Find(int id)
    // {
    //   foreach (Album album in _instances)
    //   {
    //     if (album.Id == id)
    //     {
    //       return album;
    //     }
    //   }
    //   return _instances[0];
    // }

    // public static void Update(int id, string title, int year, string label, string img)
    // {
    //   Album result = Find(id);
    //   result.Title = title;
    //   result.Year = year;
    //   result.Label = label;
    //   result.Img = img;
    // }

    // public static void Delete(int id)
    // {
    //   Album toRemove = Find(id);
    //   _instances.Remove(toRemove);
    // }
  }
}