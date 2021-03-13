using System.Data;
using Dapper;
using NoteService.Interfaces;
using System.Collections.Generic;
using NoteService.Models;

namespace NoteService.Database {
   public class DbContextDapper : IDbContext {
       readonly IDbConnection conn;
       public DbContextDapper(IDbConnection dbcon)
       {
           conn = dbcon;
           conn.Open();
       }

       public string GetVersion() {
           return conn.QueryFirst("select SQLITE_VERSION() AS Version").Version;
       }

       public IEnumerable<Note> GetAllNotes() {
           return conn.Query<Note>("select * from Notes");
       } 
    }
}