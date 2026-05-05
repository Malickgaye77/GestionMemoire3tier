using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetierMemoire.Model
{
    public class BdMemoireContext:DbContext
    {
        //[DbConfigurationType(typeof(MySqlEFConfiguration))]
        public BdMemoireContext(): base("connMemoire") { }
        public DbSet<Memoire> Memoires { get; set; }
    }
}