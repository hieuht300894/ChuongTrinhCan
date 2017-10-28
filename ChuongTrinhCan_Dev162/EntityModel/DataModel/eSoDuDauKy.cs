namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("eSoDuDauKy")]
    public partial class eSoDuDauKy
    {
        public eSoDuDauKy()
        {
        }

        [Key]
        public int KeyID { get; set; }

        public DateTime NgayNhap { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }

        public int IDLoaiCongViec { get; set; }

        public string LoaiCongViec { get; set; }

        public int IDLoai { get; set; }

        public string Loai { get; set; }

        public decimal SoLuong { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }
    }
}
