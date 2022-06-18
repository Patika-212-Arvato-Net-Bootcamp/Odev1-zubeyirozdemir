using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderCli
    {
        
        private ArrayList personInfoList = new ArrayList();
        private ArrayList orderList = new ArrayList();
        private ArrayList modelList = new ArrayList();
        private ArrayList colorList = new ArrayList();
        private ArrayList engineList = new ArrayList();
        private ArrayList packageList = new ArrayList();

        public void initOrderCli()
        {
            initTestPersons();
            initProdustList();
        }

        public ArrayList PersonInfoList
        {
            get { return personInfoList; }
            set { personInfoList = value; }
        }

        public ArrayList OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

        public ArrayList ColorList
        {
            get { return colorList; }
            set { colorList = value; }
        }

        public ArrayList EngineList
        {
            get { return engineList; }
            set { engineList = value; }
        }

        public void start()
        {
            String tcnoStr = "";
            long tcno = 0;
            bool orderFlag;
            bool isExist;

            while (true)
            {
                orderFlag = false;
                isExist = false;

                Console.Write("TC giriniz: ");
                tcnoStr = Console.ReadLine();
                
                // Sadece 11 haneli rakam kontrolü
                if (tcnoStr.Length == 11 && long.TryParse(tcnoStr, out tcno) == true)
                { 
                    for (int i = 0; i < personInfoList.Count; i++)
                    {
                        if (((Person)personInfoList[i]).TcNo == tcno)
                        {
                            isExist = true;
                            orderFlag = true;
                            requestOrder(i);
                            printOrder();
                        }                      
                    }
                    if (!isExist)
                    {
                        Console.WriteLine(" Hesap bulunamadı. Lutfen kayıt olun.\n");
                        register();
                        requestOrder(personInfoList.Count - 1 );
                        printOrder();
                        orderFlag = true;
                    }
                }
                else
                {
                   Console.WriteLine("11 haneli sayi giriniz!");
                }
                if (orderFlag)
                {
                    Console.WriteLine("Çıkmak istiyorsanız E , Devam etmek istiyorsanız herhangi bir tuşa basınız...");
                    string s = Console.ReadLine();

                    if (s.Equals("E") || s.Equals("e"))
                    {
                        Console.WriteLine("İyi gunler. Yine bekleriz.");
                        break;
                    }
                }
                
                    
            }  
        }
        //Yeni kayıt her zaman son index..
        private void requestOrder(int personIndex)
        {
            int choise;

            Console.WriteLine("Volvo Dünyasına Hoşgeldiniz...");
            Console.Write(((Person)personInfoList[personIndex]).Name + " " + ((Person)personInfoList[personIndex]).SurName);
            try
            {
                Console.WriteLine("\n\nModel secımı yapınız?");
                for (int j = 0; j < modelList.Count; j++)
                {
                    Console.Write(j + 1);
                    Console.Write("- ");
                    Console.WriteLine(modelList[j]);
                }

                Console.Write("Seçiminiz : ");
                choise = Convert.ToInt32(Console.ReadLine());
                orderList.Add(modelList[choise - 1]);

                Console.WriteLine("\n****************************************");

                Console.WriteLine("\nRenk secımı yapınız?");
                for (int j = 0; j < colorList.Count; j++)
                {
                    Console.Write(j + 1);
                    Console.Write("- ");
                    Console.WriteLine(colorList[j]);
                }

                Console.Write("Seçiminiz : ");
                choise = Convert.ToInt32(Console.ReadLine());
                orderList.Add(colorList[choise - 1]);

                Console.WriteLine("\n****************************************");

                Console.WriteLine("\nMotor secımı yapınız?");
                for (int j = 0; j < engineList.Count; j++)
                {
                    Console.Write(j + 1);
                    Console.Write("- ");
                    Console.WriteLine(engineList[j]);
                }

                Console.Write("Seçiminiz : ");
                choise = Convert.ToInt32(Console.ReadLine());
                orderList.Add(engineList[choise - 1]);

                Console.WriteLine("\n****************************************");

                Console.WriteLine("\nPaket secımı yapınız?");
                for (int j = 0; j < packageList.Count; j++)
                {
                    Console.Write(j + 1);
                    Console.Write("- ");
                    Console.WriteLine(packageList[j]);
                }
                Console.Write("Seçiminiz : ");
                choise = Convert.ToInt32(Console.ReadLine());
                orderList.Add(packageList[choise - 1]);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Hatalı seçim.");
            }

        }

        public void register()
        {
            bool registerFlag = false;
            bool successful = true;
            String tcnoStr = "";
            long tcno = 0;
            Person newPerson = new Person();

            try
            {
                Console.WriteLine("********KAYIT EKRANI*********");

                Console.Write("TC giriniz : ");
                tcnoStr = Console.ReadLine();

                while (!registerFlag)
                {
                    if (tcnoStr.Length == 11 && long.TryParse(tcnoStr, out tcno) == true)
                    {
                        registerFlag = true;
                        newPerson.TcNo = Convert.ToInt64(tcnoStr);
                    }
                    else
                    {
                        Console.WriteLine("Lutfen sadece 11 haneli sayi giriniz!");
                        Console.Write("TC giriniz : ");
                        tcnoStr = Console.ReadLine();
                    }

                }


                Console.Write("Adınız : ");
                newPerson.Name = Console.ReadLine();

                Console.Write("Soyadınız : ");
                newPerson.SurName = Console.ReadLine();

                Console.Write("GSM No: : ");
                newPerson.GSM = Convert.ToInt64(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Bir hata oluştu. Bilgilerinizi kontrol edin.");
                successful = false;
            }
            if (successful)
            {
                Console.WriteLine("Kayıt işlemi başarılı.\n");
                personInfoList.Add(newPerson);
            }

        }

        private void printOrder()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\nSiparis Listesi");
            for (int j = 0; j < orderList.Count; j++)
            {
                Console.WriteLine(orderList[j]);
            }
            Console.WriteLine("\nSiparişiniz alındı. Hazırlanıyor...");
        }

        private void initTestPersons()
        {
            Person person = new Person();
            person.TcNo = 11111111111;
            person.Name = "ahmet";
            person.SurName = "yılmaz";
            person.GSM = 534;
            personInfoList.Add(person);

            Person person2 = new Person();
            person2.TcNo = 22222222222;
            person2.Name = "ali";
            person2.SurName = "aksoy";
            person2.GSM = 543;
            personInfoList.Add(person2);

            Person person3 = new Person();
            person3.TcNo = 12312312311;
            person3.Name = "murat";
            person3.SurName = "turk";
            person3.GSM = 555;
            personInfoList.Add(person3);
        }

        private void initProdustList()
        {
            modelList.Add("Volvo XC40");
            modelList.Add("Volvo XC60");
            modelList.Add("Volvo XC90");
            modelList.Add("Volvo S60");
            modelList.Add("Volvo S90");
            modelList.Add("Volvo V90");

            colorList.Add("Buz Beyazı");
            colorList.Add("Siyah");
            colorList.Add("Bright Gümüş");
            colorList.Add("Denim Mavi");
            colorList.Add("Platinum Gri");
            
            
            engineList.Add("Dizel");
            engineList.Add("Benzin");
            engineList.Add("Hybrid");
            engineList.Add("Electric");

            packageList.Add("Işıklar");
            packageList.Add("Klima");
            packageList.Add("Lounge");
            packageList.Add("Dijital Hizmetler");
        }

    }

}
