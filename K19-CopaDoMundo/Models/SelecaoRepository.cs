using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K19_CopaDoMundo.Models
{
    public class SelecaoRepository:IDisposable
    {
        private bool disposed = false;
        private K19CopaDoMundoContext context;

        public SelecaoRepository(K19CopaDoMundoContext context)
        {
            this.context = context;
        }

        public void Adiciona (Selecao selecao)
        {
            context.Selecoes.Add(selecao);
        }

        public List<Selecao> Selecoes
        {
            get
            {
                return context.Selecoes.ToList();
            }
        }

        public void Salva()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}