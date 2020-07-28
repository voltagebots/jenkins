using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Inventory
{
    public class SalesOrderDetailsResponseModel
    {

        [JsonProperty("salesorder_id")]
        public string SalesorderId { get; set; }

        [JsonProperty("documents")]
        public IList<object> Documents { get; set; }

        [JsonProperty("zcrm_potential_id")]
        public string ZcrmPotentialId { get; set; }

        [JsonProperty("zcrm_potential_name")]
        public string ZcrmPotentialName { get; set; }

        [JsonProperty("salesorder_number")]
        public string SalesorderNumber { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("color_code")]
        public string ColorCode { get; set; }

        [JsonProperty("current_sub_status_id")]
        public string CurrentSubStatusId { get; set; }

        [JsonProperty("current_sub_status")]
        public string CurrentSubStatus { get; set; }

        [JsonProperty("sub_statuses")]
        public IList<object> SubStatuses { get; set; }

        [JsonProperty("shipment_date")]
        public string ShipmentDate { get; set; }

        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("contact_persons")]
        public IList<object> ContactPersons { get; set; }

        //[JsonProperty("contact_person_details")]
        //public IList<ContactPersonDetail> ContactPersonDetails { get; set; }

        [JsonProperty("contact_category")]
        public string ContactCategory { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("exchange_rate")]
        public string ExchangeRate { get; set; }

        [JsonProperty("discount")]
        public string Discount { get; set; }

        [JsonProperty("discount_applied_on_amount")]
        public string DiscountAppliedOnAmount { get; set; }

        [JsonProperty("is_discount_before_tax")]
        public string IsDiscountBeforeTax { get; set; }

        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        [JsonProperty("estimate_id")]
        public string EstimateId { get; set; }

        [JsonProperty("delivery_method")]
        public string DeliveryMethod { get; set; }

        [JsonProperty("delivery_method_id")]
        public string DeliveryMethodId { get; set; }

        [JsonProperty("is_inclusive_tax")]
        public string IsInclusiveTax { get; set; }

        [JsonProperty("order_status")]
        public string OrderStatus { get; set; }

        [JsonProperty("invoiced_status")]
        public string InvoicedStatus { get; set; }

        [JsonProperty("shipped_status")]
        public string ShippedStatus { get; set; }

        [JsonProperty("sales_channel")]
        public string SalesChannel { get; set; }

        [JsonProperty("account_identifier")]
        public string AccountIdentifier { get; set; }

        [JsonProperty("stringegration_id")]
        public string stringegrationId { get; set; }

        [JsonProperty("is_dropshipped")]
        public string IsDropshipped { get; set; }

        [JsonProperty("is_backordered")]
        public string IsBackordered { get; set; }

        [JsonProperty("is_manually_fulfilled")]
        public string IsManuallyFulfilled { get; set; }

        [JsonProperty("has_qty_cancelled")]
        public string HasQtyCancelled { get; set; }

        [JsonProperty("is_offline_payment")]
        public string IsOfflinePayment { get; set; }

        [JsonProperty("created_by_email")]
        public string CreatedByEmail { get; set; }

        //[JsonProperty("line_items")]
        //public IList<LineItem> LineItems { get; set; }

        [JsonProperty("submitter_id")]
        public string SubmitterId { get; set; }

        [JsonProperty("approver_id")]
        public string ApproverId { get; set; }

        [JsonProperty("submitted_date")]
        public string SubmittedDate { get; set; }

        [JsonProperty("submitted_by")]
        public string SubmittedBy { get; set; }

        [JsonProperty("shipping_charge_tax_id")]
        public string ShippingChargeTaxId { get; set; }

        [JsonProperty("shipping_charge_tax_name")]
        public string ShippingChargeTaxName { get; set; }

        [JsonProperty("shipping_charge_tax_type")]
        public string ShippingChargeTaxType { get; set; }

        [JsonProperty("shipping_charge_tax_percentage")]
        public string ShippingChargeTaxPercentage { get; set; }

        [JsonProperty("shipping_charge_tax")]
        public string ShippingChargeTax { get; set; }

        [JsonProperty("shipping_charge_exclusive_of_tax")]
        public string ShippingChargeExclusiveOfTax { get; set; }

        [JsonProperty("shipping_charge_inclusive_of_tax")]
        public string ShippingChargeInclusiveOfTax { get; set; }

        [JsonProperty("shipping_charge_tax_formatted")]
        public string ShippingChargeTaxFormatted { get; set; }

        [JsonProperty("shipping_charge_exclusive_of_tax_formatted")]
        public string ShippingChargeExclusiveOfTaxFormatted { get; set; }

        [JsonProperty("shipping_charge_inclusive_of_tax_formatted")]
        public string ShippingChargeInclusiveOfTaxFormatted { get; set; }

        [JsonProperty("shipping_charge")]
        public string ShippingCharge { get; set; }

        [JsonProperty("bcy_shipping_charge")]
        public string BcyShippingCharge { get; set; }

        [JsonProperty("adjustment")]
        public string Adjustment { get; set; }

        [JsonProperty("bcy_adjustment")]
        public string BcyAdjustment { get; set; }

        [JsonProperty("adjustment_description")]
        public string AdjustmentDescription { get; set; }

        [JsonProperty("roundoff_value")]
        public string RoundoffValue { get; set; }

        [JsonProperty("transaction_rounding_type")]
        public string TransactionRoundingType { get; set; }

        [JsonProperty("sub_total")]
        public string SubTotal { get; set; }

        [JsonProperty("bcy_sub_total")]
        public string BcySubTotal { get; set; }

        [JsonProperty("sub_total_inclusive_of_tax")]
        public string SubTotalInclusiveOfTax { get; set; }

        [JsonProperty("sub_total_exclusive_of_discount")]
        public string SubTotalExclusiveOfDiscount { get; set; }

        [JsonProperty("discount_total")]
        public string DiscountTotal { get; set; }

        [JsonProperty("bcy_discount_total")]
        public string BcyDiscountTotal { get; set; }

        [JsonProperty("discount_percent")]
        public string DiscountPercent { get; set; }

        [JsonProperty("tax_total")]
        public string TaxTotal { get; set; }

        [JsonProperty("bcy_tax_total")]
        public string BcyTaxTotal { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("bcy_total")]
        public string BcyTotal { get; set; }

        [JsonProperty("taxes")]
        public IList<object> Taxes { get; set; }

        [JsonProperty("price_precision")]
        public string PricePrecision { get; set; }

        [JsonProperty("is_emailed")]
        public string IsEmailed { get; set; }

        [JsonProperty("has_unconfirmed_line_item")]
        public string HasUnconfirmedLineItem { get; set; }

        [JsonProperty("packages")]
        public IList<Package> Packages { get; set; }

        [JsonProperty("invoices")]
        public IList<Invoice> Invoices { get; set; }

        [JsonProperty("purchaseorders")]
        public IList<object> Purchaseorders { get; set; }

        [JsonProperty("salesreturns")]
        public IList<object> Salesreturns { get; set; }

        //[JsonProperty("warehouses")]
        //public IList<Warehouse> Warehouses { get; set; }

        //[JsonProperty("billing_address")]
        //public BillingAddress BillingAddress { get; set; }

        //[JsonProperty("shipping_address")]
        //public ShippingAddress ShippingAddress { get; set; }

        //[JsonProperty("payments")]
        //public IList<Payment> Payments { get; set; }

        [JsonProperty("refunds")]
        public IList<object> Refunds { get; set; }

        [JsonProperty("is_test_order")]
        public string IsTestOrder { get; set; }

        [JsonProperty("refundable_amount")]
        public string RefundableAmount { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("terms")]
        public string Terms { get; set; }

        [JsonProperty("payment_terms")]
        public string PaymentTerms { get; set; }

        [JsonProperty("payment_terms_label")]
        public string PaymentTermsLabel { get; set; }

        [JsonProperty("custom_fields")]
        public IList<object> CustomFields { get; set; }

        //[JsonProperty("custom_field_hash")]
        //public CustomFieldHash CustomFieldHash { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("template_name")]
        public string TemplateName { get; set; }

        [JsonProperty("page_width")]
        public string PageWidth { get; set; }

        [JsonProperty("page_height")]
        public string PageHeight { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("template_type")]
        public string TemplateType { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_modified_time")]
        public DateTime LastModifiedTime { get; set; }

        [JsonProperty("created_by_id")]
        public string CreatedById { get; set; }

        [JsonProperty("created_date")]
        public string CreatedDate { get; set; }

        [JsonProperty("last_modified_by_id")]
        public string LastModifiedById { get; set; }

        [JsonProperty("attachment_name")]
        public string AttachmentName { get; set; }

        [JsonProperty("can_send_in_mail")]
        public string CanSendInMail { get; set; }

        [JsonProperty("salesperson_id")]
        public string SalespersonId { get; set; }

        [JsonProperty("salesperson_name")]
        public string SalespersonName { get; set; }

        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("approvers_list")]
        public IList<object> ApproversList { get; set; }
    }

    public class ShipmentOrder
    {

        [JsonProperty("shipment_id")]
        public string ShipmentId { get; set; }

        [JsonProperty("shipment_number")]
        public string ShipmentNumber { get; set; }

        [JsonProperty("shipment_date")]
        public string ShipmentDate { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty("delivery_date")]
        public string DeliveryDate { get; set; }

        [JsonProperty("shipment_type")]
        public string ShipmentType { get; set; }

        [JsonProperty("associated_packages_count")]
        public string AssociatedPackagesCount { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("delivery_days")]
        public string DeliveryDays { get; set; }

        [JsonProperty("delivery_guarantee")]
        public string DeliveryGuarantee { get; set; }

        [JsonProperty("tracking_url")]
        public string TrackingUrl { get; set; }

        [JsonProperty("is_carrier_shipment")]
        public string IsCarrierShipment { get; set; }
    }

    public class Package
    {

        [JsonProperty("package_id")]
        public string PackageId { get; set; }

        [JsonProperty("package_number")]
        public string PackageNumber { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("detailed_status")]
        public string DetailedStatus { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        [JsonProperty("shipment_id")]
        public string ShipmentId { get; set; }

        [JsonProperty("shipment_number")]
        public string ShipmentNumber { get; set; }

        [JsonProperty("shipment_status")]
        public string ShipmentStatus { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty("shipment_date")]
        public string ShipmentDate { get; set; }

        [JsonProperty("delivery_days")]
        public string DeliveryDays { get; set; }

        [JsonProperty("delivery_guarantee")]
        public string DeliveryGuarantee { get; set; }

        [JsonProperty("delivery_method")]
        public string DeliveryMethod { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("is_tracking_enabled")]
        public string IsTrackingEnabled { get; set; }

        [JsonProperty("shipment_order")]
        public ShipmentOrder ShipmentOrder { get; set; }
    }

    public class Invoice
    {

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }
    }
}
