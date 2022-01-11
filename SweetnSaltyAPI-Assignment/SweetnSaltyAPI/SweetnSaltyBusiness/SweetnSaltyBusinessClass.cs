using SweetnSaltyDbAccess;
using SweetnSaltyModels;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SweetnSaltyBusiness
{
    public class SweetnSaltyBusinessClass : ISweetnSaltyBusinessClass
    {
        private readonly ISweetnSaltyDbAccessClass _dbAccess;
        private readonly IMapper _mapper;

        public SweetnSaltyBusinessClass(ISweetnSaltyDbAccessClass Dbaccess, IMapper mapper)
        {
            this._mapper = mapper;
            _dbAccess = Dbaccess;
        }

        public async Task<Flavor> PostFlavor(string flavor)
        {
            SqlDataReader dr = await this._dbAccess.PostFlavor(flavor);
            if (dr.Read())
            {
                Flavor f = this._mapper.EntitytoFlavor(dr);
                return f;
            }
            else
                return null;
        }

        public async Task<Person> PostPerson(string fname, string lname, string flavor)
        {
            SqlDataReader dr = await this._dbAccess.GetPerson(fname, lname);

            Person p = null;
            if (dr.Read())
            {
                p = this._mapper.EntitytoPerson(dr);
            }

            SqlDataReader dr1 = await this._dbAccess.FindFlavor(flavor);
            Flavor f = new Flavor();
            if (dr1.Read())
            {
                f = this._mapper.EntitytoFlavor(dr1);
            }

            this._dbAccess.LikesFlavor(p.PersonId, f.FlavorId);
            return p;
        }

        public async Task<Person> GetPerson(string fname, string lname)
        {
            SqlDataReader dr = await this._dbAccess.GetPerson(fname, lname);
            if (dr.Read())
            {
                Person p = this._mapper.EntitytoPerson(dr);
                return p;
            }
            else
                return null;
        }

        public async Task<Person> GetPerson(int personId)
        {
            SqlDataReader dr = await this._dbAccess.FindPerson(personId);
            Person p = null;
            if (dr.Read())
            {
                p = this._mapper.EntitytoPerson(dr);
            }
            p.Flavors = await GetPersonAndFlavors(personId);
            return p;
        }

        public async Task<List<Flavor>> GetPersonAndFlavors(int personId)
        {
            SqlDataReader dr = await this._dbAccess.GetPersonAndFlavors(personId);
            List<Flavor> flavors = new List<Flavor>();
            while (dr.Read())
            {
                Flavor f = this._mapper.EntitytoFlavor(dr);
                flavors.Add(f);
            }
            return flavors;
        }

        public async Task<List<Flavor>> GetFlavors()
        {
            SqlDataReader dr = await this._dbAccess.GetFlavors();
            List<Flavor> flavors = new List<Flavor>();
            while (dr.Read())
            {
                Flavor f = this._mapper.EntitytoFlavor(dr);
                flavors.Add(f);
            }
            return flavors;
        }
    }
}
