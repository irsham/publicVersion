using System.Collections.Generic;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Country
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
       
        /// <summary>
        /// Gets or sets the alpha3 code.
        /// </summary>
        /// <value>
        /// The alpha3 code.
        /// </value>
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>
        /// The flag.
        /// </value>
        public string Flag { get; set; }

        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        /// <value>
        /// The population.
        /// </value>
        public long Population { get; set; }

        /// <summary>
        /// Gets or sets the timezones.
        /// </summary>
        /// <value>
        /// The timezones.
        /// </value>
        public List<string> Timezones { get; set; }

        /// <summary>
        /// Gets or sets the currencies.
        /// </summary>
        /// <value>
        /// The currencies.
        /// </value>
        public List<Currency> Currencies { get; set; }

        /// <summary>
        /// Gets or sets the capital.
        /// </summary>
        /// <value>
        /// The capital.
        /// </value>
        public string Capital { get; set; }

        /// <summary>
        /// Gets or sets the languages.
        /// </summary>
        /// <value>
        /// The languages.
        /// </value>
        public List<Language> Languages { get; set; }

        /// <summary>
        /// Gets or sets the borders.
        /// </summary>
        /// <value>
        /// The borders.
        /// </value>
        public List<string> Borders { get; set; }
    }
}
