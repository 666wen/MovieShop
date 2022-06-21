﻿using ApplicationCore.Contract.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService:IGenreService

    {
        //DI generRepository is using Repository<genre> =>Irepository<genre>
        private readonly IRepository<Genre> _genreRepository;

        public GenreService(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAll();// List(rows)
            // var genresModel = genres.Select(g => new GenreModel { Id = g.Id, Name = g.Name });
            //same as the following codes
            var genresModel = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genresModel.Add(new GenreModel { Id=genre.Id, Name=genre.Name});
            }
            return genresModel;
        }
    }
}
