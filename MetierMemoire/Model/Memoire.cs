using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetierMemoire.Model
{
    public class Memoire
    {
        [Key]
        public int IdMemoire { get; set; }
        [Required, MaxLength(2000)]
        public string SujetMemoire { get; set; }
        
        [Required, MaxLength(100000)]
        public string DescriptionMemoire { get; set; }
        [Required]
        public int AnneeMemoire { get; set; }
    }
    /// <summary>
    /// si une classe se termine par Model ça veut dire que c'est une classe de transfert de données (DTO) qui est utilisé pour faire le lien entre la couche métier et la couche de présentation
    /// </summary>
    public class MemoireModel
    {
        
        public string SujetMemoire { get; set; }
       public int AnneeMemoire { get; set; }
    }
}