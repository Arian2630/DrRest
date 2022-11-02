using DrRest.Managers;
using DrRest.Models;

namespace MusicTest
{
    [TestClass]
    public class MusicSongTest
    {
        public Music song = new Music() { Title = "Orale", Artist = "Gilli", Duration = 2.48, publicationYear = 2015 };
        public Music songNull = new Music() { Title = null, Artist = "Poor Man's Poison", Duration = 3.03, publicationYear = 2020 };
        public Music songArtistNull = new Music() { Title = "Hejsa", Artist = null, Duration = 3.03, publicationYear = 2020 };
        public Music songDuration = new Music() { Title = "hey", Artist = "Poor Man's Poison", Duration = 0, publicationYear = 2020 };
        public Music songPublication1 = new Music() { Title = "test", Artist = "Poor Man's Poison", Duration = 3.03, publicationYear = 1899 };
        public Music songPublication2 = new Music() { Title = "test", Artist = "Poor Man's Poison", Duration = 3.03, publicationYear = 1900 };
        public Music songPublication3 = new Music() { Title = "test", Artist = "Poor Man's Poison", Duration = 3.03, publicationYear = 1901 };
        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            MusicManager _manager = new MusicManager();
            //Act
            int result = _manager.GetAll().Count;
            //Assert
            Assert.AreEqual(5, result);
        }
        [TestMethod()]
        public void GetSongByIdTest()
        {
            MusicManager _manager = new MusicManager();
            Music music1 = _manager.GetById(4);
            Assert.AreEqual(4, music1.Id);
            Assert.AreEqual(2022, music1.publicationYear);
        }
        [TestMethod()]
        public void ValidateTitle()
        {
            song.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => songNull.ValidateTitle());
        }
        [TestMethod()]
        public void ValidateArtist()
        {
            song.ValidateArtist();
            Assert.ThrowsException<ArgumentNullException>(() => songArtistNull.ValidateArtist());
        }
        [TestMethod()]
        public void ValidateDuration()
        {
            song.ValidateDuration();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => songDuration.ValidateDuration());
        }
        [TestMethod()]
        public void ValidatePublicationYear()
        {
            song.ValidatePublicationYear();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => songPublication1.ValidatePublicationYear());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => songPublication2.ValidatePublicationYear());


        }
        
    }
}