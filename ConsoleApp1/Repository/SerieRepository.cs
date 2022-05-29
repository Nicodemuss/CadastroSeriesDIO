using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    internal class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void DeleteById(int id)
        {

            try
            {
                if (listaSeries[id].existe())
                {
                    listaSeries[id].deletar();
                    Console.WriteLine("Deletado com sucesso\n");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Não encontrado\n");
                return;
            }
            
        }

        public Serie? FindByID(int id)
        {
            try
                {
               if (listaSeries[id].existe())
            {
                return listaSeries[id];
            }    
                }catch(ArgumentOutOfRangeException e)
                {   
                return null;
                }
            return null;
        }

        public List<Serie> listar()
        {
            List<Serie> listaExiste = new List<Serie>();
            foreach(var item in listaSeries)
            {
                if (item.existe() == true){
                    listaExiste.Add(item);
                }
            }
            return listaExiste;
        }

        public int ProximoID()
        {
            return listaSeries.Count;
        }

        public void Save(Serie entidade)
        {
           listaSeries.Add(entidade);
        }

        public void Update(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }
    }
}
