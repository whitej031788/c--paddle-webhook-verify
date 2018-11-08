using System;

namespace PaddleWebhook.Models
{
    // Paddle is a PHP application, and passes all of its POST params as strings
    public class PaddleWebhookModel
    {
        public string alert_name { get; set; }
        public string subscription_id { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string marketing_consent { get; set; }
        public string subscription_plan_id { get; set; }
        public string next_bill_date { get; set; }
        public string update_url { get; set; }
        public string cancel_url { get; set; }
        public string currency { get; set; }
        public string checkout_id { get; set; }
        public string passthrough { get; set; }
        public string new_quantity { get; set; }
        public string old_quantity { get; set; }
        public string new_unit_price { get; set; }
        public string old_unit_price { get; set; }
        public string new_price { get; set; }
        public string old_price { get; set; }
        public string cancellation_effective_date { get; set; }
        public string user_id { get; set; }
        public string order_id { get; set; }
        public string country { get; set; }
        public string sale_gross { get; set; }
        public string fee { get; set; }
        public string earnings { get; set; }
        public string customer_name { get; set; }
        public string plan_name { get; set; }
        public string payment_tax { get; set; }
        public string payment_method { get; set; }
        public string balance_currency { get; set; }
        public string balance_tax { get; set; }
        public string balance_earnings { get; set; }
        public string balance_fee { get; set; }
        public string balance_gross { get; set; }
        public string coupon { get; set; }
        public string initial_payment { get; set; }
        public string receipt_url { get; set; }
        public string instalments { get; set; }
        public string quantity { get; set; }
        public string unit_price { get; set; }
        public string next_retry_date { get; set; }
        public string amount { get; set; }
        public string event_time { get; set; }
        public string subscription_payment_id { get; set; }
        public string p_signature { get; set; }
        public string gross_refund { get; set; }
        public string tax_refund { get; set; }
        public string fee_refund { get; set; }
        public string earnings_decrease { get; set; }
        public string balance_gross_refund { get; set; }
        public string balance_tax_refund { get; set; }
        public string balance_fee_refund { get; set; }
        public string balance_earnings_decrease { get; set; }
    }
}