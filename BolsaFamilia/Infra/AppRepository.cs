using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaFamilia.Infra
{
    internal class AppRepository<T> (AppDbContext context) where T : class
    {
        private DbSet<T> DbSet = context.Set<T>();
        public IList<T> Listar()
        {
            return DbSet.ToList();
        }
        public void Adicionar(T valor)
        {

            DbSet.Add(valor);
            context.SaveChanges();
        }
        public void Atualizar(T valor)
        {
            DbSet.Update(valor);
            context.SaveChanges();
        }
        public void Deletar(T valor)
        {
            DbSet.Remove(valor);
            context.SaveChanges();
        }
        public void DeletarTodos(Func<T, bool> condicao)
        {
            var list = DbSet.Where(condicao);
            DbSet.RemoveRange(list);
            context.SaveChanges();
        }

        public T? RecuperarUmPor(Func<T, bool> condicao)
        {
            return DbSet.FirstOrDefault(condicao);
        }

        public IEnumerable<T> RecuperarListaPor(Func<T, bool> condicao)
        {
            return DbSet.Where(condicao);
        }
    }
}
 