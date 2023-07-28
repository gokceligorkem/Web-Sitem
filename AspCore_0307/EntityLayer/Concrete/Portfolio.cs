using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string SlidUrl { get; set; }
        public string Platform { get; set; }
        public string Price { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public bool Status { get; set; }
        public int Value { get; set; }
    }
}
