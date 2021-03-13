using System.Collections.Generic;
using NoteService.Models;

namespace NoteService.Interfaces
{
    public interface IDbContext {
        string GetVersion();
        IEnumerable<Note> GetAllNotes();
    }
}