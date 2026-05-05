using MetierMemoire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierMemoire.Service
{
    public class MemoireService
    {
        BdMemoireContext db=new BdMemoireContext();
        /// <summary>
        /// Renvoie la liste des memoires
        /// </summary>
        /// <returns></returns>
        public List<Memoire> GetAllMemoire()
        {
            return db.Memoires.ToList();
        }
        /// <summary>
        /// Renvoie un memoire selon son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Memoire GetMemoire(int?   id)
        {
            return db.Memoires.Find(id);
        }

        /// <summary>
        /// Permet de faire l'enregistrement d'un Memoire 
        /// </summary>
        /// <param name="memo">le memoire enregistrer </param>
        /// <returns></returns>
        public bool AddMemoire(Memoire memo)
        {
            try
            {
                db.Memoires.Add(memo);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //todo: implementer la gestion d'erreur
            }
            return false;
        }
        public bool SupprimerMemoire(int id)
        {
            try
            {
                Memoire memoire = db.Memoires.Find(id);
                if (memoire == null) return false;
                db.Memoires.Remove(memoire);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // todo: implementer la gestion d'erreur
            }
            return false;
        }
    }
}