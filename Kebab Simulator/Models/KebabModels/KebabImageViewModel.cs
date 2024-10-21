namespace Kebab_Simulator.Models.KebabModels
{
    public class KebabImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image {  get; set; }
        public Guid? KebabID { get; set; }
    }
}
