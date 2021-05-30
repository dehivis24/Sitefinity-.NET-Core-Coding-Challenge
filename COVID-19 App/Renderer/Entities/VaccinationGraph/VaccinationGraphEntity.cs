using Progress.Sitefinity.Renderer.Designers.Attributes;
using System.ComponentModel;

namespace Renderer.Entities.VaccinationGraph
{
    public class VaccinationGraphEntity
    {
        [DisplayName("Default Country")]
        [DefaultValue(CountryList.CRI)]
        [DescriptionExtended(InstructionalNotes = "Select country to display as default")]
        public CountryList DefaultCountry { get; set; }

        [DisplayName("Graph Type")]
        [DescriptionExtended(InstructionalNotes = "Select graph type")]
        public GraphType GraphTypeValue { get; set; }

        #region Enums
        public enum CountryList
        {
            [Description("Afghanistan")]
            AFG,
            [Description("Albania")]
            ALB,
            [Description("Algeria")]
            DZA,
            [Description("Andorra")]
            AND,
            [Description("Angola")]
            AGO,
            [Description("Anguilla")]
            AIA,
            [Description("Antigua and Barbuda")]
            ATG,
            [Description("Argentina")]
            ARG,
            [Description("Armenia")]
            ARM,
            [Description("Aruba")]
            ABW,
            [Description("Australia")]
            AUS,
            [Description("Austria")]
            AUT,
            [Description("Azerbaijan")]
            AZE,
            [Description("Bahamas")]
            BHS,
            [Description("Bahrain")]
            BHR,
            [Description("Bangladesh")]
            BGD,
            [Description("Barbados")]
            BRB,
            [Description("Belarus")]
            BLR,
            [Description("Belgium")]
            BEL,
            [Description("Belize")]
            BLZ,
            [Description("Bermuda")]
            BMU,
            [Description("Bhutan")]
            BTN,
            [Description("Bolivia")]
            BOL,
            [Description("Bosnia and Herzegovina")]
            BIH,
            [Description("Botswana")]
            BWA,
            [Description("Brazil")]
            BRA,
            [Description("Brunei")]
            BRN,
            [Description("Bulgaria")]
            BGR,
            [Description("Cambodia")]
            KHM,
            [Description("Cameroon")]
            CMR,
            [Description("Canada")]
            CAN,
            [Description("Cape Verde")]
            CPV,
            [Description("Cayman Islands")]
            CYM,
            [Description("Chile")]
            CHL,
            [Description("China")]
            CHN,
            [Description("Colombia")]
            COL,
            [Description("Comoros")]
            COM,
            [Description("Congo")]
            COG,
            [Description("Costa Rica")]
            CRI,
            [Description("Cote d'Ivoire")]
            CIV,
            [Description("Croatia")]
            HRV,
            [Description("Curacao")]
            CUW,
            [Description("Cyprus")]
            CYP,
            [Description("Czechia")]
            CZE,
            [Description("Democratic Republic of Congo")]
            COD,
            [Description("Denmark")]
            DNK,
            [Description("Djibouti")]
            DJI,
            [Description("Dominica")]
            DMA,
            [Description("Dominican Republic")]
            DOM,
            [Description("Ecuador")]
            ECU,
            [Description("Egypt")]
            EGY,
            [Description("El Salvador")]
            SLV,
            [Description("England")]
            OWID_ENG,
            [Description("Equatorial Guinea")]
            GNQ,
            [Description("Estonia")]
            EST,
            [Description("Eswatini")]
            SWZ,
            [Description("Ethiopia")]
            ETH,
            [Description("Faeroe Islands")]
            FRO,
            [Description("Falkland Islands")]
            FLK,
            [Description("Fiji")]
            FJI,
            [Description("Finland")]
            FIN,
            [Description("France")]
            FRA,
            [Description("Gabon")]
            GAB,
            [Description("Gambia")]
            GMB,
            [Description("Georgia")]
            GEO,
            [Description("Germany")]
            DEU,
            [Description("Ghana")]
            GHA,
            [Description("Gibraltar")]
            GIB,
            [Description("Greece")]
            GRC,
            [Description("Greenland")]
            GRL,
            [Description("Grenada")]
            GRD,
            [Description("Guatemala")]
            GTM,
            [Description("Guernsey")]
            GGY,
            [Description("Guinea")]
            GIN,
            [Description("Guyana")]
            GUY,
            [Description("Honduras")]
            HND,
            [Description("Hong Kong")]
            HKG,
            [Description("Hungary")]
            HUN,
            [Description("Iceland")]
            ISL,
            [Description("India")]
            IND,
            [Description("Indonesia")]
            IDN,
            [Description("Iran")]
            IRN,
            [Description("Iraq")]
            IRQ,
            [Description("Ireland")]
            IRL,
            [Description("Isle of Man")]
            IMN,
            [Description("Israel")]
            ISR,
            [Description("Italy")]
            ITA,
            [Description("Jamaica")]
            JAM,
            [Description("Japan")]
            JPN,
            [Description("Jersey")]
            JEY,
            [Description("Jordan")]
            JOR,
            [Description("Kazakhstan")]
            KAZ,
            [Description("Kenya")]
            KEN,
            [Description("Kosovo")]
            OWID_KOS,
            [Description("Kuwait")]
            KWT,
            [Description("Kyrgyzstan")]
            KGZ,
            [Description("Laos")]
            LAO,
            [Description("Latvia")]
            LVA,
            [Description("Lebanon")]
            LBN,
            [Description("Lesotho")]
            LSO,
            [Description("Libya")]
            LBY,
            [Description("Liechtenstein")]
            LIE,
            [Description("Lithuania")]
            LTU,
            [Description("Luxembourg")]
            LUX,
            [Description("Macao")]
            MAC,
            [Description("Malawi")]
            MWI,
            [Description("Malaysia")]
            MYS,
            [Description("Maldives")]
            MDV,
            [Description("Mali")]
            MLI,
            [Description("Malta")]
            MLT,
            [Description("Mauritania")]
            MRT,
            [Description("Mauritius")]
            MUS,
            [Description("Mexico")]
            MEX,
            [Description("Moldova")]
            MDA,
            [Description("Monaco")]
            MCO,
            [Description("Mongolia")]
            MNG,
            [Description("Montenegro")]
            MNE,
            [Description("Montserrat")]
            MSR,
            [Description("Morocco")]
            MAR,
            [Description("Mozambique")]
            MOZ,
            [Description("Myanmar")]
            MMR,
            [Description("Namibia")]
            NAM,
            [Description("Nauru")]
            NRU,
            [Description("Nepal")]
            NPL,
            [Description("Netherlands")]
            NLD,
            [Description("New Zealand")]
            NZL,
            [Description("Nicaragua")]
            NIC,
            [Description("Niger")]
            NER,
            [Description("Nigeria")]
            NGA,
            [Description("North Macedonia")]
            MKD,
            [Description("Northern Cyprus")]
            OWID_CYN,
            [Description("Northern Ireland")]
            OWID_NIR,
            [Description("Norway")]
            NOR,
            [Description("Oman")]
            OMN,
            [Description("Pakistan")]
            PAK,
            [Description("Palestine")]
            PSE,
            [Description("Panama")]
            PAN,
            [Description("Papua New Guinea")]
            PNG,
            [Description("Paraguay")]
            PRY,
            [Description("Peru")]
            PER,
            [Description("Philippines")]
            PHL,
            [Description("Poland")]
            POL,
            [Description("Portugal")]
            PRT,
            [Description("Qatar")]
            QAT,
            [Description("Romania")]
            ROU,
            [Description("Russia")]
            RUS,
            [Description("Rwanda")]
            RWA,
            [Description("Saint Helena")]
            SHN,
            [Description("Saint Kitts and Nevis")]
            KNA,
            [Description("Saint Lucia")]
            LCA,
            [Description("Saint Vincent and the Grenadines")]
            VCT,
            [Description("Samoa")]
            WSM,
            [Description("San Marino")]
            SMR,
            [Description("Sao Tome and Principe")]
            STP,
            [Description("Saudi Arabia")]
            SAU,
            [Description("Scotland")]
            OWID_SCT,
            [Description("Senegal")]
            SEN,
            [Description("Serbia")]
            SRB,
            [Description("Seychelles")]
            SYC,
            [Description("Sierra Leone")]
            SLE,
            [Description("Singapore")]
            SGP,
            [Description("Slovakia")]
            SVK,
            [Description("Slovenia")]
            SVN,
            [Description("Solomon Islands")]
            SLB,
            [Description("Somalia")]
            SOM,
            [Description("South Africa")]
            ZAF,
            [Description("South Korea")]
            KOR,
            [Description("South Sudan")]
            SSD,
            [Description("Spain")]
            ESP,
            [Description("Sri Lanka")]
            LKA,
            [Description("Sudan")]
            SDN,
            [Description("Suriname")]
            SUR,
            [Description("Sweden")]
            SWE,
            [Description("Switzerland")]
            CHE,
            [Description("Syria")]
            SYR,
            [Description("Taiwan")]
            TWN,
            [Description("Thailand")]
            THA,
            [Description("Timor")]
            TLS,
            [Description("Togo")]
            TGO,
            [Description("Tonga")]
            TON,
            [Description("Trinidad and Tobago")]
            TTO,
            [Description("Tunisia")]
            TUN,
            [Description("Turkey")]
            TUR,
            [Description("Turks and Caicos Islands")]
            TCA,
            [Description("Uganda")]
            UGA,
            [Description("Ukraine")]
            UKR,
            [Description("United Arab Emirates")]
            ARE,
            [Description("United Kingdom")]
            GBR,
            [Description("United States")]
            USA,
            [Description("Uruguay")]
            URY,
            [Description("Uzbekistan")]
            UZB,
            [Description("Venezuela")]
            VEN,
            [Description("Vietnam")]
            VNM,
            [Description("Wales")]
            OWID_WLS,
            [Description("Zambia")]
            ZMB,
            [Description("Zimbabwe")]
            ZWE
        }

        public enum GraphType
        {
            Bars,
            Lines
        }

        #endregion
    }
}
