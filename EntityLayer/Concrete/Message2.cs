using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageID { get; set; }
        public int? SenderID { get; set; } //gönderen 
        public int? ReceiverID { get; set; } //alıcı
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; } //okundu okumadı olarak kullanıcaz

        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }
    }
}
