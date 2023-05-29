namespace JWO_PaymentsConnector
{
    public class AddCardRequestUI
    {
        public string card_number { get; set; }
        public string card_exp_month { get; set; }
        public string card_exp_year { get; set; }
        public string card_cvc { get; set; }
        public string action { get; set; }

        public string person_name { get; set; }
        public string email_id { get; set; }
    }
}
