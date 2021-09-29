using Varuosad.DTO;

namespace Varuosad.Controllers
{
    public class QueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 30;
        public string Search { get; set; }
        public string Sort { get; set; } = "";
        
    }
}