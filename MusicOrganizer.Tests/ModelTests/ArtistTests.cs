using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{

  [TestClass]
  public class ArtistTest : IDisposable
  {
    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("Can", "KrautRock");

      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsAListOfArtists_Artist()
    {
      Artist newArtist1 = new Artist("Can", "KrautRock");
      Artist newArtist2 = new Artist("Prince", "Pop");

      List<Artist> testList = new List<Artist> { newArtist1, newArtist2 };
      List<Artist> result = Artist.GetAll();

      CollectionAssert.AreEqual(testList, result);

    }

    [TestMethod]
    public void Find_ReturnsArtistBasedOnId_Artist()
    {
      Artist newArtist1 = new Artist("Can", "KrautRock");
      Artist newArtist2 = new Artist("Prince", "Pop");

      Artist result = Artist.Find(1);

      // List<Artist> listResult = Artist.GetAll();
      // foreach()


      Assert.AreEqual(newArtist2, result);
    }

    [TestMethod]
    public void Update_UpdatesArtistInformation_Void()
    {
      Artist newArtist1 = new Artist("Can", "KrautRock");
      Artist newArtist2 = new Artist("Prince", "Pop");

      string newName = "Test Name";

      Artist.Update(1, newName, "Rock");
      Artist result = Artist.Find(1);

      Assert.AreEqual(newName, result.Name);

    }
  }
}