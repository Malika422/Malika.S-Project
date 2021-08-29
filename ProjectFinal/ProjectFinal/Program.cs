using ProjectFinal.Models;
using ProjectFinal.Utils;
using System;
using System.Collections.Generic;

namespace ProjectFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Drug> drugs = new List<Drug>();
            Pharmacy pharmacy = new Pharmacy();
            List<DrugType> drugTypeNames = new List<DrugType>();
            while (true)
            {
                Helper.Print(ConsoleColor.Yellow, "\n 1.Dermanin tipini yaratmaq, \n 2.Dermani elave etmek \n" +
               " 3.Dermanlar siyahisini gorsetmek, \n 4.Dermani satmaq, \n 5.Chixish ");
                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 5))
                {
                    if (menu == 5)
                    {
                        break;
                    }

                    switch (menu)
                    {
                        case 1:
                            selectCount:
                            Helper.Print(ConsoleColor.Green, "Tip sayini daxil edin");
                            result = Console.ReadLine();
                            isInt = int.TryParse(result, out int count);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Eded daxil edin");
                                goto selectCount;
                            }
                            typeName:
                            Helper.Print(ConsoleColor.Green, "Tip adini daxil edin");
                            string drugTypeName = Console.ReadLine();

                            bool isExistsDrugType = drugTypeNames.Exists(x => x.TypeName.ToLower() == drugTypeName.ToLower());
                            if (isExistsDrugType)
                            {
                                Helper.Print(ConsoleColor.Red, $"{drugTypeName} adinda tip movcuddur");
                                goto typeName;
                            }

                            DrugType newDragType = new DrugType(drugTypeName);
                            drugTypeNames.Add(newDragType);
                            Helper.Print(ConsoleColor.Green, $"{drugTypeName} tip yaradildi");
                            break;

                        case 2:
                            Helper.Print(ConsoleColor.Yellow, "movcud typlerden sechin");
                            foreach (DrugType drugTypeNames1 in drugTypeNames)
                            {
                                Helper.Print(ConsoleColor.Yellow, drugTypeNames1.ToString());
                            }
                            selectType:
                            string selectedDrugType = Console.ReadLine();
                            DrugType existDrugType = drugTypeNames.Find(x => x.TypeName.ToLower() == selectedDrugType.ToLower());
                            if (existDrugType == null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{selectedDrugType} tip yoxdur");
                                goto selectType;
                            }

                            Helper.Print(ConsoleColor.DarkBlue, "Dermanin adini daxil edin");
                            string name = Console.ReadLine();
                            selectDrugCount:
                            Helper.Print(ConsoleColor.DarkBlue, "Dermanin sayini daxil edin");
                            result = Console.ReadLine();
                            isInt = int.TryParse(result, out int drugCount);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Eded daxil edin");
                                goto selectDrugCount;
                            }

                            selectPrice:
                            Helper.Print(ConsoleColor.DarkBlue, "Dermanin qiymetini daxil edin");
                            string newPrice = Console.ReadLine();
                            bool isDoublePrice = double.TryParse(newPrice, out double drugPrice);
                            if (!isDoublePrice)
                            {
                                Helper.Print(ConsoleColor.Red, "Eded daxil edin");
                                goto selectPrice;
                            }
                            Drug drug = new Drug(name, drugCount, existDrugType, drugPrice);
                            pharmacy.AddDrug(drug);
                            break;

                        case 3:
                            pharmacy.ShowDrugItems();
                            break;

                        case 4:
                            Helper.Print(ConsoleColor.Cyan, "movcud dermanlardan secin");
                            pharmacy.ShowAllDrugs();
                            selectedDrug:
                            string selectedDrug = Console.ReadLine();
                            //var existDrug = drugs.Find(x => x.Name.ToLower() == selectedDrug.ToLower());
                            if (selectedDrug == null)
                            {
                                Helper.Print(ConsoleColor.Red, "Dermanin adini duzgun yaz");
                                goto selectedDrug;
                            }
                            selectedCount:
                            Helper.Print(ConsoleColor.Cyan, "Neche eded derman alirsiniz");
                            string selectCount = Console.ReadLine();
                            isInt = int.TryParse(selectCount, out int drugCount1);
                            if (drugCount1 <= 0)
                            {
                                Helper.Print(ConsoleColor.Red, "Derman sayini duzgun daxil edin");
                                goto selectedCount;
                            }

                            selectedPayment:
                            Helper.Print(ConsoleColor.Cyan, "odenisi daxil edin");
                            string selectPayment = Console.ReadLine();
                            isInt = int.TryParse(selectCount, out int drugPayment);
                            if (drugPayment <= 0)
                            {
                                Helper.Print(ConsoleColor.Red, "Odenishi duzgun daxil edin");
                                goto selectedPayment;
                            }

                            if (pharmacy.SaleDrug(selectedDrug, drugCount1, drugPayment) != false)
                            {

                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Gosterilen ededlerden sechin");
                }
            }
        }
    }

}
