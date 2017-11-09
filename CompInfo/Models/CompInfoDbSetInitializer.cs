using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CompInfo.Models;

namespace CompInfo.Models
{
    public class CompInfoDbSetInitializer : DropCreateDatabaseAlways<CompInfoDB>
    {
        protected override void Seed(CompInfoDB context)
        {
            base.Seed(context);
        }

    }
}