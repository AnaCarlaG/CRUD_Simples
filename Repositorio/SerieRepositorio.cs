using System;
using System.Collections.Generic;
using Series.Classes;
using Series.Interfaces;

namespace Series
{
    public class SerieRepositorio: IRepository<Serie>
    {

        private List<Serie> listaSeries = new List<Serie>();
        public List<Serie> Lista(){
            return listaSeries;
        }
         public Serie RetornaPorId(int id){
            return listaSeries[id];
         }
        public void Atualizar(int id, Serie entidade){
            listaSeries[id] = entidade;
        }

        public void Excluir(int id){
            listaSeries[id].Exclui();
        }

        public void Inserir(Serie entidade){
            listaSeries.Add(entidade);
        }

        public int ProximoId(){
            return listaSeries.Count;

        }
    }
}