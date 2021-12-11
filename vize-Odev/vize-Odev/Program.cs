using MLModel1_ConsoleApp1;
using System;

namespace vize_Odev
{
    class Program
    {
        static void Main(string[] args)
        {
            float age;
            String sex;
            String chestType;
            float restingBP;
            float cholesterol;
            String restingECG;
            float maxHR;

            //Yaş verisini alıyoruz.
            startage:
            Console.Write("Age : ");
            age = float.Parse(Console.ReadLine());
            
            if(age < 0 || age > 100) // Girilen değerin 0 ile 100 arasında olması için if kullanıyoruz.
            {
                Console.WriteLine("Error!!! \nMust be a value between 0 and 100");
                goto startage;
            }

            //Cinsiyet verisini alıyoruz.
            Console.Write("Sex ('M' or 'F') : ");
            sex = Console.ReadLine();
          
            //Chest type verisini alıyoruz.
            Console.Write("Chest Pain Type (ASY, ATA or NAP) : ");
            chestType = Console.ReadLine();

            //Resting BP değerini alıyoruz.
            startrestingBP:
            Console.Write("Resting BP (example 140) : ");
            restingBP = float.Parse(Console.ReadLine());

            if(restingBP < 0 || restingBP > 200) //Girilen değerin 0 ile 200 arasında olması için if kullanıyoruz.
            {
                Console.WriteLine("Error!!!! \nMust be a value between 0 and 200");
                goto startrestingBP;
            }

            //Cholesterol verisini alıyoruz.
            Console.Write("Cholesterol (example 248) : ");
            cholesterol = float.Parse(Console.ReadLine());

            if(cholesterol < 0 || cholesterol > 600) //Girilen değerin 0 ile 600 arasında olması için if kullanıyoruz.
            {
                Console.WriteLine("Error!!!! \nMust be a value between 0 and 600");
            }

            //Resting ECG verisini alıyoruz.
            Console.Write("Resting ECG (Normal, ST or LVH) : ");
            restingECG = Console.ReadLine();

            //Maksimum kalp ritmi verisini alıyoruz.
            startmaxHR:
            Console.Write("Max Heart Rate (Example 145) : ");
            maxHR = float.Parse(Console.ReadLine());

            if(maxHR < 60 || maxHR > 200) //Girilen değerin 60 ile 200 arasında olması için if kullanıyoruz
            {
                Console.WriteLine("Errorr!!!!! \nMust be a value between 60 and 200");
                goto startmaxHR;
            }


            // Create single instance of sample data from first line of dataset for model input
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                Age = age,
                Sex = sex,
                ChestPainType = chestType,
                RestingBP = restingBP,
                Cholesterol = cholesterol,
                RestingECG = restingECG,
                MaxHR = maxHR,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = MLModel1.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual HeartDisease with predicted HeartDisease from sample data...\n\n");


            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Sex: {sex}");
            Console.WriteLine($"ChestPainType: {chestType}");
            Console.WriteLine($"RestingBP: {restingBP}");
            Console.WriteLine($"Cholesterol: {cholesterol}");
            Console.WriteLine($"RestingECG: {restingECG}");
            Console.WriteLine($"MaxHR: {maxHR}");


            Console.WriteLine($"\n\nPredicted HeartDisease: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
