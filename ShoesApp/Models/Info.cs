namespace ShoesApp.Models
{
    public class Info
    {
        public int InfoId { get; set; }
        public int? UserId { get; set; }
        public int? ShoesId { get; set; }
        public string? Name { get; set; }
        public string? RelatedName1 { get; set; }
        public string? RelatedName2 { get; set; }
        public string? RelatedPhone1 { get; set;}
        public string? RelatedPhone2 { get;set;}
        public string? Address {  get; set; }
        public string? Message { get; set; }
        public string? Email { get; set; }
        public bool? NameVisibility { get; set; }
        public bool? RelatedName1Visibility { get; set; }
        public bool? RelatedName2Visibility { get; set; }
        public bool? RelatedPhone1Visibility { get; set; }
        public bool? RelatedPhone2Visibility { get; set; }
        public bool? AddressVisibility { get; set; }
        public bool? MessageVisibility { get; set; }
        public bool? EmailVisibility { get; set; }


    }
}
