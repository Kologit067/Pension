

namespace PensionImport
{

    internal class Program
    {
        static Dictionary<string, int> MonthDictionary = new Dictionary<string, int>()
        {
            ["січень"] = 1,
            ["лютий"] = 2,
            ["березень"] = 3,
            ["квітень"] = 4,
            ["травень"] = 5,
            ["червень"] = 6,
            ["липень"] = 7,
            ["серпень"] = 8,
            ["вересень"] = 9,
            ["жовтень"] = 10,
            ["листопад"] = 11,
            ["грудень"] = 12
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            if (args.Length > 0)
            { 
                if (args[0] == "PersonData")
                {
                    ProcessPersonData();
                }
                else if (args[0] == "Before2002")
                {
                    ProcessBefore2002();
                }
                else if (args[0] == "After2002")
                {
                    ProcessAfter2002();
                }
            }
        }

        private static void ProcessAfter2002()
        {
            string[] paymentStrings = File.ReadAllLines("average_2003_2025.txt");


            if (paymentStrings != null)
            {
                List<AverageSalary> salaryList = CreateAverageSalaryListAfter2002(paymentStrings);
                ImportSalary importSalary = new ImportSalary();
                importSalary.InsertAvarage(salaryList);
            }
        }

        private static void ProcessBefore2002()
        {
            string[] paymentStrings = File.ReadAllLines("avgsal.csv");
 

            if (paymentStrings != null)
            {
                List<AverageSalary> salaryList = CreateAverageSalaryListBefore2002(paymentStrings);
                ImportSalary importSalary = new ImportSalary();
                importSalary.InsertAvarage(salaryList);
            }

        }

        private static void ProcessPersonData()
        {
            string paymentString = File.ReadAllText("PensionData.json");
            PaymentData? paymentData = Newtonsoft.Json.JsonConvert.DeserializeObject<PaymentData>(paymentString);
            if (paymentData != null)
            {
                List<PersonSalary> salaryList = CreateSalaryList(paymentData);
                ImportSalary importSalary = new ImportSalary();
                importSalary.Insert(salaryList);
            }
        }

        private static List<PersonSalary> CreateSalaryList(PaymentData paymentData)
        {
            List<PersonSalary> result = new List<PersonSalary>();
            foreach(var item in paymentData.Items)
            {
                int year = item.Year;
                for (int i = 0; i < item.ForPens.Count; i++)
                {
                    PersonSalary salary = new PersonSalary()
                    {
                        SalaryYear = year,
                        SalaryMonth = i + 1,
                        SalaryForPens = item.ForPens[i],
                        UserLoginId = 1
                    };
                    result.Add(salary);
                }
            }
            return result.OrderBy(s => s.SalaryYear).ToList();
        }

        private static List<AverageSalary> CreateAverageSalaryListBefore2002(string[] paymentStrings)
        {
            List<AverageSalary> result = new List<AverageSalary>();
            int month = 1;
            foreach (string paymentString in paymentStrings)
            {
                int year = 1995;
                string[] paymentMonths = paymentString.Split(",\"");
                for (int i = 1; i < paymentMonths.Length; i++)
                {
                    string paymentMonth = paymentMonths[i].Replace("\"", "");
                    paymentMonth = paymentMonth.Replace(" ", "");
                    paymentMonth = paymentMonth.Replace(",", ".");
                    decimal salarySum = decimal.Parse(paymentMonth);
                    AverageSalary salary = new AverageSalary()
                    {
                        SalaryYear = year,
                        SalaryMonth = month,
                        Salary = salarySum,
                    };
                    result.Add(salary);
                    year++;
                }
                month++;
            }
            
            return result.OrderBy(s => s.SalaryYear).ThenBy(s => s.SalaryMonth).ToList();
        }

        private static List<AverageSalary> CreateAverageSalaryListAfter2002(string[] paymentStrings)
        {
            List<AverageSalary> result = new List<AverageSalary>();
            foreach (string paymentString in paymentStrings)
            {
                string[] paymentParts = paymentString.Split("\t");
                string[] sumParts = paymentParts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] dateParts = paymentParts[2].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int year = 0;
                int month = 0;
                if (dateParts.Length == 4)
                {
                    year = int.Parse(dateParts[2]);
                    month = MonthDictionary[dateParts[1]];
                }
                else
                {
                    year = int.Parse(dateParts[1]);
                    month = MonthDictionary[dateParts[0]];
                }
                decimal salarySum = 0;
                if (sumParts.Length == 4)
                {
                    salarySum = decimal.Parse(sumParts[0]) + decimal.Parse(sumParts[2])/100;
                }
                else
                {
                    salarySum = decimal.Parse(sumParts[0]+ sumParts[1]) + decimal.Parse(sumParts[3]) / 100;
                }

                AverageSalary salary = new AverageSalary()
                {
                    SalaryYear = year,
                    SalaryMonth = month,
                    Salary = salarySum,
                };
                result.Add(salary);
            }

            return result.OrderBy(s => s.SalaryYear).ThenBy(s => s.SalaryMonth).ToList();
        }
    }
}
