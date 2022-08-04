using PoupaDev.API.Enums;

namespace PoupaDev.API.Controllers
{
    public class OperacaoInputModel
    {
        public decimal Valor { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
    }
}
