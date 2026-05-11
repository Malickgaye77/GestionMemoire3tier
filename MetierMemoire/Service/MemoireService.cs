using MetierMemoire.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetierMemoire.Service
{
    public class MemoireService
    {
        BdMemoireContext db = new BdMemoireContext();
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
        public Memoire GetMemoire(int? id)
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
        /// <summary>
        /// Permet de modifier un memoire
        /// </summary>
        /// <param name="memoire"></param>
        /// <returns></returns>
        public bool EditMemoire(Memoire memoire)
        {
            try
            {
                db.Entry(memoire).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;

        }
        public bool DeleteMemoire(Memoire memo)
        {
            try
            {
                db.Entry(memo).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memo"></param>
        /// <returns></returns>
        public List<Memoire> GetMemoireList(MemoireModel memo) 
        {
            var Liste = db.Memoires.ToList();
            return Liste;

            if (!string.IsNullOrEmpty(memo.SujetMemoire))
            {
                Liste = Liste.Where(a => a.SujetMemoire.ToLower().Contains(memo.SujetMemoire.ToLower())).ToList();
            }
            if (memo.AnneeMemoire!=null)
            {
                Liste = Liste.Where(a => a.AnneeMemoire==memo.AnneeMemoire).ToList();
            }
        }

    }
}