using System;
using System.Collections.Generic;
using System.Text;

namespace Vin.Api.Customer.Models.Requests
{
  

        public class FindOrCreateCustomerRequest
        {
            public string type { get; set; }
            public Source source { get; set; }
            public Company company { get; set; }
            public Name name { get; set; }
            public Personalinformation personalInformation { get; set; }
            public Contact contact { get; set; }
        }

        public class Source
        {
            public int dealer { get; set; }
            public int user { get; set; }
            public string originator { get; set; }
        }

        public class Company
        {
            public string name { get; set; }
        }

        public class Name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string middle { get; set; }
            public string last { get; set; }
            public string suffix { get; set; }
        }

        public class Personalinformation
        {
            public string gender { get; set; }
        }

        public class Contact
        {
            public Phone[] phones { get; set; }
            public Email[] emails { get; set; }
            public Address[] addresses { get; set; }
        }

        public class Phone
        {
            public string type { get; set; }
            public string value { get; set; }
            public string extension { get; set; }
            public bool isPreferred { get; set; }
        }

        public class Email
        {
            public string type { get; set; }
            public string value { get; set; }
            public bool isPreferred { get; set; }
        }

        public class Address
        {
            public string type { get; set; }
            public string street1 { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string stateOrProvince { get; set; }
            public string postalCode { get; set; }
            public string countyOrRegion { get; set; }
            public string country { get; set; }
            public bool isPreferred { get; set; }
        }

    }

