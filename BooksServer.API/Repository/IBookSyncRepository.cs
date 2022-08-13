
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksServer.API.Models;
using BooksServer.API.Entities;
using Refit;
namespace BooksServer.API.Repository
{
    public interface IBookSyncRepository
    {
        [Post("/api/books")]
        Task SyncOut([Body] Books book);
    }
}