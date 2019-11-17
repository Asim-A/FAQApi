using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Model.DatabaseModel
{   
    /**
     * Kunder trenger ikke å oppgi navnet sitt, men epost kan være nyttig å lagre
     * fordi hvis spørsmålet blir behandlet, kan kunden få en epost angående spørsmålet sitt.
     * Det er også ikke noe grunn til å inkludere kategorier fordi de gjør at kunden må tenke
     * unødvendig på besvarelsen sin. Man ønsker egentlig bare å få et svar på et spørsmål.
     **/
    public class CustomerQuestion
    {
        [Key]
        public int cq_id { get; set; }
        public string customer_email { get; set; }
        public string question_text { get; set; }

       
    }
}
