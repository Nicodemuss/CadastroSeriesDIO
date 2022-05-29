using ConsoleApp1.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    internal class Serie : EntidadeBase
    {
        private Categorias categorias { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private int ano { get; set; }
        
        private bool deletado { get; set; }

        public Serie(int id,Categorias categorias, string titulo, string descricao, int ano): base(id)
        {
            this.id = id;
            this.categorias = categorias;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.deletado = false;
        }
        public Serie()
        {
        }
        public string returnTitulo()
           {
                return this.titulo;
           }

        public int returnID()
            {
                return this.id;
            }
        public bool existe() {
            return !this.deletado;
        }

        public void deletar()
        {
            this.deletado = true;
        }
        public override string ToString()
        {
            return ($"\nID: {this.id}\nCategoria:{this.categorias}\nTitulo:{this.titulo} \nDescrição: {this.descricao} \nAno: {this.ano}\n");
        }
    }

    
    
}
