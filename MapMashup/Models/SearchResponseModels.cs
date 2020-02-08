using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapMashup.Models
{
    public enum AddressCountry { Us };

    public enum AddressRegion { Il };

    public enum EntityScenario { ListItem };

    public enum TypeElement { LocalBusiness, Place, Restaurant };

    public partial class Address
    {
        public AddressCountry AddressCountry { get; set; }
        public string AddressLocality { get; set; }
        public AddressRegion AddressRegion { get; set; }
        public string Neighborhood { get; set; }
        public long PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string Text { get; set; }
    }

    public partial class EntityPresentationInfo
    {
        public EntityScenario EntityScenario { get; set; }
        public List<TypeElement> EntityTypeHints { get; set; }
    }

    public partial class Geo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public partial class Places
    {
        public SearchAction SearchAction { get; set; }
        public long TotalEstimatedMatches { get; set; }
        public List<Value> Value { get; set; }
    }

    public partial class QueryContext
    {
        public string OriginalQuery { get; set; }
    }

    public partial class SearchAction
    {
    }

    public partial class SearchResponse
    {
        public Places Places { get; set; }
        public QueryContext QueryContext { get; set; }
        public string Type { get; set; }
    }

    public partial class Value
    {
        public Address Address { get; set; }
        public EntityPresentationInfo EntityPresentationInfo { get; set; }
        public Geo Geo { get; set; }
        public Uri Id { get; set; }
        public string Name { get; set; }
        public Geo RoutablePoint { get; set; }
        public string Telephone { get; set; }
        public TypeElement Type { get; set; }
        public Uri Url { get; set; }
    }
}