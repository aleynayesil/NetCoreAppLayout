using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout.Models
{
        //veri tabanıyla bağlantıları yoktur.verileri vari tabanona göndermeden önce ara katman.validasyon işlemleri için dataannotations kullanırız dataanno.. sadece input modellerde

    public class CategoryCreateInputModel
    {
        [Required(ErrorMessage ="name alanı boş geçilemez")]
        public string Name { get; set; }
        [MaxLength(200,ErrorMessage ="en fazla 200 karakter giriniz")]
        public string Description { get; set; }
    }
}
