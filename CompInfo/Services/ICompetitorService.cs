﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CompInfo.Models;

namespace CompInfo.Services
{
    interface ICompetitorService
    {
        List<CompetitorViewModel> GetAll();

    }
}