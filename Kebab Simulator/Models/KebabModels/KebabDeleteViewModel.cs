namespace Kebab_Simulator.Models.KebabModels
{
    public class KebabDeleteViewModel
    {
        public Guid ID { get; set; }
        public string KebabName { get; set; }
        public int KebabXP { get; set; }
        public int KebabXPNextLevel { get; set; }
        public int KebabLevel { get; set; }
        public int Checkout { get; set; }
        public int KebabBankAccount { get; set; }
        public DateTime KebabStart { get; set; }
        public DateTime KebabDone { get; set; }
        public KebabFoods KebabFoods { get; set; }
        public KebabType KebabType { get; set; }
        public int KebabStatus { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<KebabImageViewModel> Image { get; set; } = new List<KebabImageViewModel>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
