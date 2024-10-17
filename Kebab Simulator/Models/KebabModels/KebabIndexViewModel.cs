namespace Kebab_Simulator.Models.KebabModels
{
    public enum KebabType
    {
        Shawarma, Döner, Falafel
    }
    public enum KebabFoods
    {
        tortilla, fries, kebab, salad, veggies, falafel, specialsauce
    }
    public class KebabIndexViewModel
    {
        public Guid ID { get; set; }

        public string KebabName { get; set; }
        public int KebabXP { get; set; }
        public int KebabXPNextLevel { get; set; }
        public int KebabLevel { get; set; }
        public KebabFoods KebabFoods { get; set; }
        public KebabType KebabType { get; set; }
        public int Checkout { get; set; }
        public int BankAccount { get; set; }
        public DateTime KebabStart { get; set; }
        public DateTime KebabDone { get; set; }
        public int KebabStatus { get; set; }
        //pp

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
