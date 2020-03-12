using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;


namespace MusicOrganizer.Tests
{

  [TestClass]
  public class AlbumTest : IDisposable
  {

    public void Dispose()
    {
      Album.ResetAll();
    }

    [TestMethod]
    public void AlbumConstructor_CreateInstanceOfAlbum_Album()
    {
      Album newAlbum = new Album("TestTitle", 1977, "Subpop", "album.jpg");
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }

    [TestMethod]
    public void AlbumConstructor_AutoAddsToAlbumList_List()
    {
      Album newAlbum = new Album("TestTitle", 1977, "Subpop", "album.jpg");
      List<Album> testList = new List<Album>() { newAlbum };
      List<Album> returnedList = Album.GetAll();

      CollectionAssert.AreEqual(testList, returnedList);
    }

    [TestMethod]
    public void Find_ReturnSingleAlbumFromList_Album()
    {
      Album album0 = new Album("Tom and the boys", 1977, "Subpop", "album.jpg");
      Album album1 = new Album("Just Jerry", 1977, "Subpop", "album.jpg");

      List<Album> returnedList = Album.GetAll();

      Album result = Album.Find(1);

      Assert.AreEqual(album1, result);
    }

    [TestMethod]
    public void Update_WillUpdateProperties_void()
    {
      Album album0 = new Album("Tom and the boys", 1977, "Subpop", "album.jpg");
      string title = "Jerry and the boys";

      Album.Update(0, title, 1977, "Subpop", "All");
      Album testAlbum = Album.Find(0);

      Assert.AreEqual(title, testAlbum.Title);
    }

    [TestMethod]
    public void Delete_WillDeleteItemFromList_void()
    {
      Album album0 = new Album("Tom and the boys", 1977, "Subpop", "album.jpg");
      Album album1 = new Album("Just Jerry", 1977, "Subpop", "album.jpg");
      Album album3 = new Album("Jerry and the Fam", 1977, "Subpop", "album.jpg");

      Album.Delete(1);

      List<Album> testList = new List<Album> { album0, album3 };
      List<Album> result = Album.GetAll();

      CollectionAssert.AreEqual(testList, result);
    }
  }

}