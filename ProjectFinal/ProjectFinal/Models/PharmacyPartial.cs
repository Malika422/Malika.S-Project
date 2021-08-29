using ProjectFinal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{                                                   
    partial class Pharmacy
    {
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
        public void ShowAllDrugs()
        {
            Helper.Print(ConsoleColor.Cyan, $"{Name} Dermanlarin siyahisi:");
            foreach (Drug drug in _drugs)
            {
                Helper.Print(ConsoleColor.Yellow, drug.ToString());
            }
        }
        public bool ShowDrugItems()
        {
            if (_drugs.Count != 0)
            {
                foreach (Drug drug in _drugs)
                {
                    Console.WriteLine(drug);
                }
                return true;
            }
            return false;
        }
        public bool AddDrug(Drug newDrug)
        {
            bool isFalse = false;
            foreach (var inPharmacyDrug in _drugs)
            {
                if (newDrug.Name == inPharmacyDrug.Name)
                {
                    inPharmacyDrug.Count += newDrug.Count;
                    isFalse = true;
                }
            }
            if (isFalse == false)
            {
                _drugs.Add(newDrug);
            }
            return false;
        }
        public bool InfoDrug(string name)
        {
            Drug existDrug = _drugs.Find(xDrug => xDrug.Name.ToLower() == name.ToLower());
            if (existDrug == null)
            {
                return false;
            }
            return true;
        }
        public bool SaleDrug(string name, int count, double payment)
        {
            Drug existDrug = _drugs.Find(x => x.Name.ToLower() == name.ToLower());
            if (existDrug == null)
            {
                Helper.Print(ConsoleColor.Red, "Bele bir derman tapilmadi. Dogru derman daxil edin");
                return false;
            }
            else if (existDrug.Count < count)
            {
                Helper.Print(ConsoleColor.Red, $"{Name} aptekinde {existDrug.Name} dermani yeterli deyil");
                return false;
            }
            else if (payment < existDrug.Price * count)
            {
                Helper.Print(ConsoleColor.Red, "Odenish yeterli deyil");
                return false;
            }
            else
            {
                _drugs.Find(x => x.Name.ToLower() == name.ToLower()).Count -= count;
                Helper.Print(ConsoleColor.Green, "Satish ughurla basha chatdi");
                return true;
            }
        }
    }
}
