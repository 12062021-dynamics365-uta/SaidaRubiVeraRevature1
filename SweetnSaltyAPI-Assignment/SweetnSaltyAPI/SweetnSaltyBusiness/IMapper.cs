using SweetnSaltyModels;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public interface IMapper
    {
        Person EntitytoPerson(SqlDataReader dr);
        Flavor EntitytoFlavor(SqlDataReader dr);

    }
}