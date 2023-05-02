using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key] //BlogID DEĞİŞKENİNİN BİRİNCİL ANAHTAR-PRIMARY KEY OLMASINA YARIYOR
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; } //içerik alanı
        public string BlogThumbnailImage { get; set; } //küçük resim
        public string BlogImage { get; set; } //büyük resim
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }

        public int CategoryID { get; set; } //id'nin tutulacağı alan, Category sınıfındaki isimle aynı  
                                            //olmalı ki ilişki kısmında bi sorun çıkmasın
        public Category Category { get; set; } // ilişki içerisine alınacak olan yani
                                               // Category'den türünde olması gerekiyor

        public int WriterID { get; set; } 
        public Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
