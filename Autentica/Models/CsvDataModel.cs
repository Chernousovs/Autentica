using CsvHelper.Configuration.Attributes;
using System;

namespace Autentica.Models
{
    public class CsvDataModel
    {
        [Index(0)]
        [Name("#KODS#")]
        public string KODS { get; set; }
        [Index(1)]
        [Name("#TIPS_CD#")]
        public string TIPS_CD { get; set; }
        [Index(2)]
        [Name("#NOSAUKUMS#")]
        public string NOSAUKUMS { get; set; }
        [Index(3)]
        [Name("#VKUR_CD#")]
        public string VKUR_CD { get; set; }
        [Index(4)]
        [Name("#VKUR_TIPS#")]
        public string VKUR_TIPS { get; set; }
        [Index(5)]
        [Name("#STD#")]
        public string STD { get; set; }
        [Index(6)]
        [Name("#KOORD_X#")]
        public string KOORD_X { get; set; }
        [Index(7)]
        [Name("#KOORD_Y#")]
        public string KOORD_Y { get; set; }
        [Index(8)]
        [Name("#DD_N#")]
        public string DD_N { get; set; }
        [Index(9)]
        [Name("#DD_E#")]
        public string DD_E { get; set; }
    }
}
