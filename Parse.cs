using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
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
        public string NameMaterial { get; set; }
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
    class TypeOrgParse
    {
        [Index(1)]
        public string Name { get; set; }
    }
    class TypeSuppliersParse
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public string typeOrg { get; set; }
        [Index(2)]
        public string INN { get; set; }
        [Index(3)]
        public string Rate { get; set; }
        [Index(4)]
        public DateTime startWork { get; set; }
    }
    class PostavshickTypeParse
    {
        [Index(1)]
        public string Name { get; set; }
     

    }
    class Parse
    {
        MaterialType materialType;
        ProductType ProductType;
        appDbContext Db;
        TypeOrg typeOrg;
        Materials materials;
        MaterialSuppliers materialSuppliers;
        TypeSuppliers typeSuppliers;
        public Parse(appDbContext db)
        {
            Db = db;
        }
        public void AddMaterialType()
        {
            using (StreamReader reader = new StreamReader("Material_type_import - Material_type_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<MaterialTypeParse>().ToList();
                    foreach (var item in data)
                    {
                        materialType = new MaterialType() { procentRawMaterialsLoss = item.procentRawMaterialsLoss, TypeMaterial = item.TypeMaterial };
                        Db.Add(materialType);
                        Db.SaveChanges();

                    }
                }
            }
        }
        public void AddTypePostav()
        {

            using (StreamReader reader = new StreamReader("Material_suppliers_import - Material_suppliers_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<PostavshickTypeParse>().ToList();
                    foreach (var item in data)
                    {
                        var postav = new PostavshickType() { Name = item.Name };
                        Db.Add(postav);
                        Db.SaveChanges();

                    }
                }
            }
        }
        public void AddTypeOrg()
        {

            using (StreamReader reader = new StreamReader("Suppliers_import - Suppliers_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<TypeOrgParse>().ToList();
                    foreach (var item in data)
                    {
                        var typeOrg = new TypeOrg() { Name = item.Name };
                        Db.Add(typeOrg);
                        Db.SaveChanges();

                    }
                }
            }
        }
        public void AddProductType()
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
        public void AddMaterial()
        {
            using (StreamReader reader = new StreamReader("Materials_import - Materials_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<MaterialsParse>().ToList();
                    foreach (var item in data)
                    {
                        var materialTypes = Db.MaterialType.FirstOrDefault(f => f.TypeMaterial == item.materialType);

                        if (materialTypes == null)
                        {
                     
                            continue;
                        }

                        var execute = Db.Materials.FirstOrDefault(f => f.NameMaterial == item.NameMaterial);
                        if (execute != null)
                            continue;

                        var materials = new Materials()
                        {
                            MaterialTypeId = materialTypes.Id, 
                            count = item.count,
                            materialType = materialTypes,
                            countInBox = item.countInBox,
                            NameMaterial = item.NameMaterial,
                            minCount = item.minCount,
                            priceoneMaterial = item.priceoneMaterial,
                            unitofmeasurement = item.unitofmeasurement
                        };

                        Db.Materials.Add(materials);
                        Db.SaveChanges();
                    }
                }
            }
        }
        public void AddTypeSuppliers()
        {

            using (StreamReader reader = new StreamReader("Suppliers_import - Suppliers_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<TypeSuppliersParse>().ToList();
                    foreach (var item in data)
                    {
                        var typeOrg = Db.TypeOrg.FirstOrDefault(f => f.Name == item.typeOrg);
                        var postav = Db.PostavshickType.FirstOrDefault(f=> f.Name == item.Name);
                        if (typeOrg == null || postav == null)
                        {
          
                            continue;
                        }
                        var execute = Db.TypeSuppliers.FirstOrDefault(f => f.Name == item.Name || f.PostavshickTypeId == postav.Id);
                        if (execute != null)
                            continue;

                        var typeSuppliers = new TypeSuppliers() { PostavshickTypeId = postav.Id,  Name = item.Name, INN = item.INN, Rate = item.Rate, startWork = item.startWork, TypeOrgId = typeOrg.Id };

                        Db.TypeSuppliers.Add(typeSuppliers);



                        Db.SaveChanges();

                    }
                }
            }
        }
        public void AddMaterialSuppliers()
        {
            using (StreamReader reader = new StreamReader("Material_suppliers_import - Material_suppliers_import.csv"))
            {
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<MaterialSuppliersParse>().ToList();
                    foreach (var item in data)
                    {
                        var suppliersType = Db.PostavshickType.FirstOrDefault(f => f.Name == item.Suppliers);
                        var material = Db.Materials.FirstOrDefault(m => m.NameMaterial == item.NameMaterial);

                        if (suppliersType == null || material == null)
                        {
                            if (suppliersType == null)
                       
                            if (material == null)
                          
                            continue;
                        }

                        var execute = Db.MaterialSuppliers.FirstOrDefault(f => f.PostavshickTypeId == suppliersType.Id && f.MaterialId == material.Id);
                        if (execute != null)
                            continue;

                        var materialSupplierss = new MaterialSuppliers()
                        {
                            MaterialId = material.Id, 
                            PostavshickTypeId = suppliersType.Id  

                        };

                        Db.MaterialSuppliers.Add(materialSupplierss);
                        Db.SaveChanges();
                    }
                }
            }
        }
    }
}
