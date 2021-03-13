using NUnit.Framework;
using NoteService.Controllers;
using NoteService.Interfaces;
using NoteService.Database;
using NoteService.Models;
using System.Collections.Generic;
using Moq;
using System.Text.Json;
using System.Linq;

namespace Tests
{
    public class NoteTests
    {
        NoteController noteController;
        Mock<IDbContext> mock;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IDbContext>();
        }

        [Test]
        public void TestOneRowInDb()
        {
            mock
             .Setup(x => x.GetAllNotes())
             .Returns(new List<Note>() {
                 new Note() {
                     Id = 0,
                     Author = "Igor",
                     Text = "Some random text"
                 } });
            noteController = new NoteController(mock.Object);

            var result =  JsonSerializer.Deserialize<List<Note>>(noteController.Get()).FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Id);
            Assert.AreEqual("Igor", result.Author);
            Assert.AreEqual("Some random text", result.Text);
        }

        [Test]
        public void TestNoneRowInDb() {
            mock
             .Setup(x => x.GetAllNotes())
             .Returns(new List<Note>());
            noteController = new NoteController(mock.Object);

            var result =  JsonSerializer.Deserialize<List<Note>>(noteController.Get()).FirstOrDefault();
            
            Assert.IsNull(result);
        }
    }
}