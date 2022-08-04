using PoupaDev.API.Entities;

namespace PoupaDev.API.Persistence
{
    public class PoupaDevContext
    {
        public List<ObjetivoFinanceiro> Objetivos { get; set; }

        public PoupaDevContext()
        {
            Objetivos = new List<ObjetivoFinanceiro>();
        }
    }
}
