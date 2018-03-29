using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodeAggregator
{
    class ZipCode
    {
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private int zipC;

        public int ZipC
        {
            get { return zipC ; }
            set { zipC = value; }
        }

        private int areaCode;

        public int AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }

        private string timeZone;

        public string TimeZone
        {
            get { return timeZone; }
            set { timeZone = value; }
        }

    }
}
