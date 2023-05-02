using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        //Property tanımlama
        //Erişim Bel.- Değişken türü- isim- {get; set;}

        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategorDescription { get; set; }
        public bool CategoryStatus { get; set; }

        public List<Blog> Blogs { get; set; } //Category içinde Blog sınıfıyla ilişki kuruyoruz

    }
}
