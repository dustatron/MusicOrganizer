using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class MusicController : Controller
  {
    [HttpGet("/artist")]
    public ActionResult Index()
    {
      List<Artist> artist = Artist.GetAll();
      return View(artist);
    }

    [HttpGet("/artist/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artist/create")]
    public ActionResult Create(string artistName, string genre)
    {
      Artist newArtist = new Artist(artistName, genre);
      return RedirectToAction("Index");
    }

    [HttpGet("/artist/{id}")]
    public ActionResult Show(int id)
    {
      Artist artist = Artist.Find(id);
      List<Album> listAlbums = Artist.GetAlbumsList(id);
      Dictionary<string, object> items = new Dictionary<string, object>
      {
        {"Artist", artist},
        {"Albums", listAlbums}
      };
      return View(items);
    }

    [HttpGet("/artist/{id}/Edit")]
    public ActionResult Edit(int id)
    {
      Artist artist = Artist.Find(id);
      return View(artist);
    }

    [HttpPost("/artist/update/{id}")]
    public ActionResult Update(int id, string artistName, string genre)
    {
      Artist.Update(id, artistName, genre);
      return RedirectToAction("Show", id);
    }
    [HttpPost("/artist/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Artist.Delete(id);
      return View();
    }
    [HttpGet("/artist/{id}/album/new")]
    public ActionResult NewAlbum(int id)
    {
      Artist thisArtist = Artist.Find(id);
      return View(thisArtist);
    }
    [HttpPost("/artist/{id}/album/create")]
    public ActionResult CreateAlbum(int id, string title, int year, string label, string img)
    {
      Album newAlbum = new Album(title, year, label, img);
      Artist.AddAlbum(id, newAlbum);
      return RedirectToAction("Show", id);
    }
    [HttpGet("/artist/{id}/album/{albumId}/show")]
    public ActionResult ShowAlbum(int id, int albumId)
    {
      Album thisAlbum = Artist.GetAlbum(id, albumId);
      Dictionary<string, object> albumDetails = new Dictionary<string, object>
      {
        {"album", thisAlbum},
        {"artist", id}
      };
      return View(albumDetails);
    }
    [HttpGet("/artist/{id}/album/{albumId}/edit")]
    public ActionResult EditAlbum(int id, int albumId)
    {
      Album thisAlbum = Artist.GetAlbum(id, albumId);
      Dictionary<string, object> albumDetails = new Dictionary<string, object>
      {
        {"album", thisAlbum},
        {"artist", id}
      };
      return View(albumDetails);
    }

    [HttpPost("/artist/{id}/album/{albumId}/update")]
    public ActionResult UpdateAlbum(int id, int albumId, string title, int year, string label, string img)
    {
      Artist.UpdateAlbum(id, albumId, title, year, label, img);
      return RedirectToAction("Show", id);
    }
  }
}