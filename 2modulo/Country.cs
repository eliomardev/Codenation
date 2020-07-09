using System;

using System.Collections.Generic;

using System.Linq;


namespace Codenation.Challenge

{

    public class Country

    {

        public Country() { }

        public State[] Top10StatesByArea() => this.LoadStates().OrderByDescending(obj => obj.Key).Take(10).Select(obj => obj.Value).ToArray();

        private List<KeyValuePair<double, State>> LoadStates() => new List<KeyValuePair<double, State>>

        {

            new KeyValuePair<double, State>(164123.040,  new State(acronym: "AC", name:"Acre")),

            new KeyValuePair<double, State>(27778.506,   new State(acronym: "AL", name: "Alagoas")),

            new KeyValuePair<double, State>(142828.521,  new State(acronym: "AP", name: "Amapa")),

            new KeyValuePair<double, State>(1559159.148, new State(acronym: "AM", name: "Amazonas")),

            new KeyValuePair<double, State>(564733.177,  new State(acronym: "BA", name: "Bahia")),

            new KeyValuePair<double, State>(148920.472,  new State(acronym: "CE", name: "Ceara")),

            new KeyValuePair<double, State>(5779.999,    new State(acronym: "DF", name: "Distrito Federal")),

            new KeyValuePair<double, State>(46095.583,   new State(acronym: "ES", name: "Espirito Santo")),

            new KeyValuePair<double, State>(340111.783,  new State(acronym: "GO", name: "Goias")),

            new KeyValuePair<double, State>(331937.450,  new State(acronym: "MA", name: "Maranhao")),

            new KeyValuePair<double, State>(903366.192,  new State(acronym: "MT", name: "Mato Grosso")),

            new KeyValuePair<double, State>(357145.532,  new State(acronym: "MS", name: "Mato Grosso do Sul")),

            new KeyValuePair<double, State>(586522.122,  new State(acronym: "MG", name: "Minas Gerais")),

            new KeyValuePair<double, State>(1247954.666, new State(acronym: "PA", name: "Para")),

            new KeyValuePair<double, State>(56585.000,   new State(acronym: "PB", name: "Paraiba")),

            new KeyValuePair<double, State>(199307.922,  new State(acronym: "PR", name: "Parana")),

            new KeyValuePair<double, State>(98311.616,   new State(acronym: "PE", name: "Pernambuco")),

            new KeyValuePair<double, State>(251577.738,  new State(acronym: "PI", name: "Piaui")),

            new KeyValuePair<double, State>(43780.172,   new State(acronym: "RJ", name: "Rio de Janeiro")),

            new KeyValuePair<double, State>(52811.047,   new State(acronym: "RN", name: "Rio Grande do Norte")),

            new KeyValuePair<double, State>(281730.223,  new State(acronym: "RS", name: "Rio Grande do Sul")),

            new KeyValuePair<double, State>(237590.547,  new State(acronym: "RO", name: "Rondonia")),

            new KeyValuePair<double, State>(224300.506,  new State(acronym: "RR", name: "Roraima")),

            new KeyValuePair<double, State>(95736.165,   new State(acronym: "SC", name: "Santa Catarina")),

            new KeyValuePair<double, State>(248222.362,  new State(acronym: "SP", name: "Sao Paulo")),

            new KeyValuePair<double, State>(21915.116,   new State(acronym: "SE", name: "Sergipe")),

            new KeyValuePair<double, State>(277720.520,  new State(acronym: "TO", name: "Tocantins"))

        };

    }

}