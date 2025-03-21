﻿using DataService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Core.Services
{
    public interface ICinemaService
    {
        Task<Movie> GetMovieByTitleAsync(string title);
    }
}
