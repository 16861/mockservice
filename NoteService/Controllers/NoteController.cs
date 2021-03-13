using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteService.Interfaces;
using System.Text.Json;

namespace NoteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase {
        readonly IDbContext db;

        public NoteController(IDbContext dbcontext)
        {
            db = dbcontext;
        }

        [HttpGet]
        public string Get() {
            return JsonSerializer.Serialize(db.GetAllNotes()); 
        }
    }
}