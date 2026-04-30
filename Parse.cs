using System;
using System.Collections.Generic;

using CsvHelper.Configuration.Attributes;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper;
using System.Globalization;
using TimeExam.Module;
namespace TimeExam
{
    class MaterialTypeParse
    {
        [Index(0)]
        public string TypeMaterial { get; set; }
        [Index(1)]
        public decimal procentRawMaterialsLoss { get; set; }
    }
    class ProductTypeParse
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public decimal procent { get; set; }
    }
    class MaterialSuppliersParse
    {
        [Index(0)]
        public string NameMaterial { get; set; }
        [Index(1)]
        public string Suppliers { get; set; }
    }
    class MaterialsParse
    {
        [Index(0)]
        public string materialsSuppliers { get; set; }
        [Index(1)]
        public string materialType { get; set; }

        [Index(2)]
        public decimal priceoneMaterial { get; set; }
        [Index(3)]
        public decimal count { get; set; }
        [Index(4)]
        public decimal minCount { get; set; }
        [Index(5)]
        public int countInBox { get; set; }
        [Index(6)]
        public string unitofmeasurement { get; set; }
    }
    class Parse
    {
        MaterialType materialType;
        ProductType ProductType;
        appDbContext Db;
        public Parse(appDbContext db)
        {
            Db = db;
        }
        void AddMaterialType()
        {
            using (StreamReader reader = new StreamReader("Material_type_import - Material_type_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<MaterialTypeParse>().ToList();
                    foreach (var item in data)
                    {
                        var materialType = new MaterialType() { procentRawMaterialsLoss = item.procentRawMaterialsLoss, TypeMaterial = item.TypeMaterial };
                        Db.Add(materialType);
                        Db.SaveChanges();

                    }
                }
            }
        }
        void AddProductType()
        {
            using (StreamReader reader = new StreamReader("Product_type_import - Product_type_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<ProductTypeParse>().ToList();
                    foreach (var item in data)
                    {
                        var ProductslType = new ProductType() { Name = item.Name, procent = item.procent };
                        Db.Add(ProductslType);
                        Db.SaveChanges();

                    }
                }
            }
        }
        void AddMaterial()
        {
            materialType = new MaterialType();
         
            using (StreamReader reader = new StreamReader("Materials_import - Materials_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<MaterialsParse>().ToList();
                    foreach (var item in data)
                    {
                        var ProductslType = new Materials() { count = item.count, materialType= materialType,  };
                        Db.Add(ProductslType);
                        Db.SaveChanges();

                    }
                }
            }
        }

    }
}
