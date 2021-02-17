using System;

namespace Series.Classes
{
    public class Serie : EntidadeBase
    {
        public Serie(Genero genero, string titulo, string descricao, int ano, int Id)
        {
            this.Id = Id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        public string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido{get;set;}

        public string retornaTitulo(){
            return this.Titulo;
        }

         public int retornaId(){
            return this.Id;
        }
        public bool retornaExcluido(){
            return this.Excluido;
        }
         public void Exclui(){
            this.Excluido = true;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno+="Gênero: " + this.Genero + Environment.NewLine;
            retorno+="Título: " + this.Titulo + Environment.NewLine;
            retorno+="Descrição: " + this.Descricao + Environment.NewLine;
            retorno+="Ano de Ínicio: " + this.Ano + Environment.NewLine;
            retorno+="Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;
        }
    }
}