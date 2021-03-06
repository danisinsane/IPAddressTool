﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleIPaddressTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintFifthLab(); Fifth Lab is wrong.

            Console.ReadKey();
            Environment.Exit(1);
        }

        public static void PrintSecondLab()
        {
            Console.WriteLine("IP Address Lab");
            //Wrong
            Console.WriteLine("1. Network Address: {0}, First Usable Address: {1}", BinaryStringAddressToDottedDecimal(FindNetworkAddress("192.168.2.76/28")), BinaryStringAddressToDottedDecimal(FindFirstAddress("192.168.2.76/28")));
            //Wrong
            Console.WriteLine("2. Network Address: {0}, First Usable Address: {1}", BinaryStringAddressToDottedDecimal(FindNetworkAddress("192.168.2.76/9")), BinaryStringAddressToDottedDecimal(FindFirstAddress("192.168.2.76/9")));
            //Wrong
            Console.WriteLine("3. Network Address: {0}, First Usable Address: {1}", BinaryStringAddressToDottedDecimal(FindNetworkAddress("192.168.2.137/27")), BinaryStringAddressToDottedDecimal(FindFirstAddress("192.168.2.137/27")));


            Console.WriteLine("4. Total Addresses: {0}, Usable Addresses: {1}", FindTotalAddresses("101.10.2.8/15"), FindTotalUsableAddresses("101.10.2.8/15"));
            Console.WriteLine("5. Total Addresses: {0}, Usable Addresses: {1}", FindTotalAddresses("101.10.2.8/29"), FindTotalUsableAddresses("101.10.2.8/29"));

            //Wrong Broadcast address is wrong
            Console.WriteLine("6. Broadcast Address: {0}, Last Usable Address: {1}", BinaryStringAddressToDottedDecimal(FindBroadcastAddress("192.168.2.137/27")), BinaryStringAddressToDottedDecimal(FindLastAddress("192.168.2.137/27"))); 
            //wrong
            Console.WriteLine("7. Broadcast Address: {0}, Last Usable Address: {1}", BinaryStringAddressToDottedDecimal(FindBroadcastAddress("110.10.2.55/30")), BinaryStringAddressToDottedDecimal(FindLastAddress("110.10.2.55/30")));
            //wrong
            Console.WriteLine("8. Subnet Prefix Length: {0}", FindSubnetPrefix("110.10.10.64/20", 10));
            //wrong
            Console.WriteLine("9. Subnets: {0}, Total Addresses: {1}", FindSubnets("110.10.10.64/25", 28), FindTotalAddresses("110.10.10.64/25"));

            Console.WriteLine("10. Total Addresses: {0}", FindTotalAddresses("156.78.51.24/25"));
            Console.WriteLine("11. Total Addresses: {0}", FindTotalAddresses("156.78.51.24/30"));
            Console.WriteLine("12. Total Addresses: {0}", FindTotalAddresses("166.25.132.0/3"));
        }

        public static void PrintThirdLab()
        {
            Console.WriteLine("\n" + "Subnetting Lab");

            Console.WriteLine("1. \n \t a. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(2)));
            Console.WriteLine("\t b. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(13)));
            Console.WriteLine("\t c. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(5)));
            Console.WriteLine("\t d. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(11)));
            Console.WriteLine("\t e. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(9)));
            Console.WriteLine("\t f. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(10)));
            Console.WriteLine("\t g. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(4)));
            Console.WriteLine("\t h. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(14)));
            Console.WriteLine("\t i. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(6)));
            Console.WriteLine("\t j. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(8)));
            Console.WriteLine("\t k. {0}", BinaryStringAddressToDottedBinary(FindSubnetMask(12)));

            Console.WriteLine("2. ");
            Console.WriteLine("Network Address: {0}", BinaryStringAddressToDottedDecimal(FindNetworkAddress("132.8.150.67/22")));
            Console.WriteLine("Broadcast Address: {0}", BinaryStringAddressToDottedDecimal(FindBroadcastAddressAltDef("132.8.150.67/22")));
            Console.WriteLine("Number of Hosts: {0}", FindNumberOfHosts("132.8.150.67/22"));
            Console.WriteLine("Valid Host Range: {0}", FindValidHostRange("132.8.150.67/22"));
            Console.WriteLine("Network Class: {0}", FindNetworkClass("132.8.150.67/22"));

            Console.WriteLine("3. ");
            Console.WriteLine("Network Address: {0}", BinaryStringAddressToDottedDecimal(FindNetworkAddress("200.16.5.74/30")));
            Console.WriteLine("Broadcast Address: {0}", BinaryStringAddressToDottedDecimal(FindBroadcastAddressAltDef("200.16.5.74/30")));
            Console.WriteLine("Number of Hosts: {0}", FindNumberOfHosts("200.16.5.74/30"));
            Console.WriteLine("Valid Host Range: {0}", FindValidHostRange("200.16.5.74/30"));

            Console.WriteLine("4. "); //Instead of overload all functions. Just Find Number of bits in mask and then concat the address
            int fourSubnetMaskPrefix = NumberOfBitsInMask("255.255.252.0");
            string fourAddressCIDR = "166.0.13.8/" + fourSubnetMaskPrefix.ToString();
            Console.WriteLine("Network Address: {0}", BinaryStringAddressToDottedDecimal(FindNetworkAddress(fourAddressCIDR)));
            Console.WriteLine("Broadcast Address: {0}", BinaryStringAddressToDottedDecimal(FindBroadcastAddressAltDef(fourAddressCIDR)));
            Console.WriteLine("Number of Hosts: {0}", FindNumberOfHosts(fourAddressCIDR));
            Console.WriteLine("Valid Host Range: {0}", FindValidHostRange(fourAddressCIDR));

            Console.WriteLine("5. ");
            Console.WriteLine("Number of Bits in Subnet Mask: {0}", NumberOfBitsInMask("255.255.240.0"));
            Console.WriteLine("Number of Hosts: {0}", FindNumberOfHostsFromSubnetMask("255.255.240.0"));

            Console.WriteLine("6. ");
            Console.WriteLine("Number of Bits in Subnet Mask: {0}", NumberOfBitsInMask("255.255.255.192"));
            Console.WriteLine("Number of Hosts: {0}", FindNumberOfHostsFromSubnetMask("255.255.255.192"));

            Console.WriteLine("7. ");
            Console.WriteLine("Number of Bits in Subnet Mask: {0}", NumberOfBitsInMask("255.255.252.0"));
            Console.WriteLine("Number of Hosts: {0}", FindNumberOfHostsFromSubnetMask("255.255.252.0"));

            Console.WriteLine("8. ");
            Console.WriteLine("Number of Bits in Subnet Mask: {0}", NumberOfBitsInMask("255.255.255.248"));
            Console.WriteLine("Number of Hosts: {0}", FindNumberOfHostsFromSubnetMask("255.255.255.248"));

            Console.WriteLine("9. ");
            Console.WriteLine("Subnet Mask: {0}", BinaryStringAddressToDottedDecimal(FindSubnetMask(56, 1000, 'B')));
        }

        public static void PrintFourthLab()
        {
            //PrintOrganizationNetworkAddresses("138.191.0.0/16", 11);
            Console.WriteLine("Applied Science--------------------------");
            PrintOrganizationNetworkAddresses("138.191.0.0/20", 6); // Applied Science
            Console.WriteLine("Arts & Humanities------------------------");
            PrintOrganizationNetworkAddresses("138.191.16.0/20", 5); // Arts & Humanities
            Console.WriteLine("Education---------------------------");
            PrintOrganizationNetworkAddresses("138.191.32.0/20", 5); // Education
            Console.WriteLine("Business & Economics-----------------------");
            PrintOrganizationNetworkAddresses("138.191.48.0/20", 5); // Business & Economics
            Console.WriteLine("Health-----------------------------");
            PrintOrganizationNetworkAddresses("138.191.64.0/20", 7); // Health
            Console.WriteLine("Science-------------------------------");
            PrintOrganizationNetworkAddresses("138.191.80.0/20", 6); // Science
            Console.WriteLine("Social & Behavioral Science----------------");
            PrintOrganizationNetworkAddresses("138.191.96.0/20", 8); // Social & Behavioral Science
            Console.WriteLine("Information Technology------------------");
            PrintOrganizationNetworkAddresses("138.191.112.0/20", 6); // Information Technology
            Console.WriteLine("Student Affairs-------------------");
            PrintOrganizationNetworkAddresses("138.191.128.0/20", 5); // Student Affairs
            Console.WriteLine("Facilities Management--------------------");
            PrintOrganizationNetworkAddresses("138.191.144.0/20", 7); // Facilities Management
            Console.WriteLine("Administrative Services------------------");
            PrintOrganizationNetworkAddresses("138.191.160.0/20", 7); // Administrative Services
            Console.WriteLine("--------------------------------------");
        }

        /// <summary>
        /// Lab 5 was the Classroom Subnets 
        /// There has to be room for network address and broadcast address so subtract 2 from the total machines
        /// </summary>
        public static void PrintFifthLab()
        {
            Console.WriteLine("Classroom Subnets");
            int[] numberOfMachinesArr = { 60, 60, 14, 14, 14, 6, 6 };
            string[] sectorAddresses = FindSectorAddresses("138.191.0.0/25", numberOfMachinesArr);
            foreach (string sector in sectorAddresses)
            {
                Console.WriteLine(sector);
            }
        }

        public static void PrintOrganizationNetworkAddresses(string addressCIDR, int numberOfAddresses, bool orgPrefixOnlyFlag = false)
        {
            if (orgPrefixOnlyFlag == true)
            {
                string orgPrefix = FindOrganizationNetworkAddresses(addressCIDR, numberOfAddresses, true)[0];
                Console.WriteLine(orgPrefix);
                return;
            }

            string[] networkAddresses = FindOrganizationNetworkAddresses(addressCIDR, numberOfAddresses);

            for (int index = 0; index < networkAddresses.Length; index++)
            {
                Console.WriteLine(networkAddresses[index]);
            }
        }

        /// <summary>
        /// Totally wrong
        /// </summary>
        /// <param name="baseNetworkAddress"></param>
        /// <param name="numberOfMachinesArr"></param>
        /// <returns></returns>
        public static string[] FindSectorAddresses(string baseNetworkAddress, int[] numberOfMachinesArr)
        {
            string[] sectorAddresses = new string[numberOfMachinesArr.Length];
            int basePrefix = 0;
            string baseBinaryAddress = "";
            ExtractPrefixAndAddressFromCIDR(baseNetworkAddress, out basePrefix, out baseBinaryAddress);

            int previousSectorMax = 0;
            for (int index = 0; index < numberOfMachinesArr.Length; index++)
            {
                int numberOfBits = FindNumberOfBits(basePrefix, numberOfMachinesArr[index]);    
                int maxDecimalForNumberOfBits = FindMaxDecimalForNumberOfBits(numberOfBits);
                int sectorMax = maxDecimalForNumberOfBits + previousSectorMax;
                int sectorAddressDecimal = BinaryStringToInt(baseBinaryAddress) + sectorMax;
                previousSectorMax = sectorMax;
                string sectorAddressDotted = BinaryStringAddressToDottedDecimal(IntToBinaryString(sectorAddressDecimal));
                sectorAddresses[index] =  sectorAddressDotted + "/" + FindNewPrefixForNumberOfAddresses(basePrefix, numberOfMachinesArr[index]).ToString();
            }
            
            return sectorAddresses;
        }

        public static int FindMaxDecimalForNumberOfBits(int numberOfBits)
        {
            string maxBinaryString = "";
            maxBinaryString = maxBinaryString.PadLeft(numberOfBits, '1');
            return BinaryStringToInt(maxBinaryString);
        }

        public static int FindNumberOfBits(int prefix, int numberOfAddresses)
        {
            int bitLimit = 8;
            int numberOfBits = 0;
            for (int index = 0; index < bitLimit; index++)
            {
                if ((Math.Pow(2, index) - 1) / numberOfAddresses >= 1)
                {
                    numberOfBits = index;
                    break;
                }
            }
            if (prefix + numberOfBits > 31)
            {
                throw new Exception("Prefix is larger than 31. The input prefix is wrong or there are too many machines in the sub net");
            }

            return numberOfBits;
        }

        public static int FindNewPrefixForNumberOfAddresses(int prefix, int numberOfAddresses)
        {
            return prefix + FindNumberOfBits(prefix, numberOfAddresses);
        }

        public static string[] FindOrganizationNetworkAddresses(string addressCIDR, int numberOfAddresses, bool orgPrefixOnlyFlag = false)
        {
            string[] networkAddresses = new string[numberOfAddresses];

            string binaryAddress = "";
            int prefix = 0;
            ExtractPrefixAndAddressFromCIDR(addressCIDR, out prefix, out binaryAddress);
            string organizationSubnetPrefix = "/" + FindNewPrefixForNumberOfAddresses(prefix, numberOfAddresses).ToString();

            if (orgPrefixOnlyFlag == true)
            {
                networkAddresses[0] = organizationSubnetPrefix;
                return networkAddresses;
            }

            int numberOfBits = FindNumberOfBits(prefix, numberOfAddresses);
            string networkAddress = FindNetworkAddress(addressCIDR);

            for (int index = 0; index < numberOfAddresses; index++)
            {
                string subNetworkAddress = networkAddress.Remove(prefix, numberOfBits);
                string addedBits = IntToBinaryString(index);
                addedBits = addedBits.PadLeft(numberOfBits, '0');
                
                networkAddresses[index] = BinaryStringAddressToDottedDecimal(subNetworkAddress.Insert(prefix, addedBits)) + organizationSubnetPrefix;
            }

            return networkAddresses;
        }



        public static string AddressToBinaryString(string address)
        {
            string[] addressArr = Regex.Split(address, @"\.");

            //convert the addresses to binary strings
            List<int> addressListInt = new List<int>();
            for (int index = 0; index < addressArr.Length; index++)
            {
                int number;
                if (int.TryParse(addressArr[index], out number))
                {
                    addressListInt.Add(number);
                }
            }
            string[] addressDottedBinary = ConvertToBinaryStrings(addressListInt.ToArray());

            //Add zeros to each address in the dotted binary.
            for (int index = 0; index < addressDottedBinary.Length; index++)
            {
                string addressByte = addressDottedBinary[index];
                if (addressByte.Length == 0 || addressByte.Length < 8)
                {
                    addressByte = AddZerosMakeByte(addressByte);
                    addressDottedBinary[index] = addressByte;
                }
            }

            //The whole address in binary
            string binaryAddress = addressDottedBinary[0] + addressDottedBinary[1] + addressDottedBinary[2] + addressDottedBinary[3];
            return binaryAddress;
        }

        public static void ExtractPrefixAndAddressFromCIDR(string addressCIDR, out int prefix, out string binaryAddress)
        {
            //Check if the CIDR address is correct
            if (!Regex.IsMatch(addressCIDR, @"(\b\d{1,3}\.){3}\d{1,3}(\/\d{1,2}$)"))
            {
                throw new Exception("CIDR Address is wrong format");
            }

            string[] addressPrefix = Regex.Split(addressCIDR, @"\/");

            // Get the Address Prefix
            int.TryParse(addressPrefix[1], out prefix);

            binaryAddress = (AddressToBinaryString(addressPrefix[0]));
        }

        public static void ExtractPrefixFromCIDR(string addressCIDR, out int prefix)
        {
            string address = "";
            ExtractPrefixAndAddressFromCIDR(addressCIDR, out prefix, out address);
        }

        public static void ExtractAddressFromCIDR(string addressCIDR, out string address)
        {
            int prefix = 0;
            ExtractPrefixAndAddressFromCIDR(addressCIDR, out prefix, out address);
        }

        public static string FindSubnetMask(int maskLength)
        {
            string subnetMask = "";

            for (int index = 0; index < maskLength; index++)
            {
                subnetMask += "1";
            }

            for (int index = maskLength; index < 32; index++)
            {
                subnetMask += "0";
            }
            return subnetMask;
        }

        public static string FindSubNetworkAddress(string addressCIDR, int subnetMaskLength)
        {
            string subnetMask = FindSubnetMask(subnetMaskLength);
            string address = "";
            ExtractAddressFromCIDR(addressCIDR, out address);

            int subNetworkAddressInt = BinaryStringToInt(address) & BinaryStringToInt(subnetMask);
            return Convert.ToString(subNetworkAddressInt, 2);
        }

        public static string FindNetworkMask(string addressCIDR)
        {
            int prefix = 0;
            ExtractPrefixFromCIDR(addressCIDR, out prefix);
            // The network mask is 1's for each bit n times with a trail of zeros at the end
            var networkMask = FindSubnetMask(prefix);

            return networkMask;
        }

        public static string FindBroadcastAddress(string addressCIDR)
        {
            //Is This Broadcast Address? HostMask?
            int prefix = 0;
            ExtractPrefixFromCIDR(addressCIDR, out prefix);

            // Broadcast address is (32-n) all 1's
            var broadcastAddress = "";
            for (int index = 0; index < prefix; index++)
            {
                broadcastAddress += "0";
            }
            for (int index = prefix; index < 32; index++)
            {
                broadcastAddress += "1";
            }
            return broadcastAddress;
        }

        // Bug?
        public static string FindBroadcastAddressAltDef(string addressCIDR)
        {
            int prefix = 0;
            ExtractPrefixFromCIDR(addressCIDR, out prefix);

            string onesInHostAddress = "";
            for (int index = 0; index < 32 - prefix; index++)
            {
                onesInHostAddress += "1";
            }

            string networkAddress = FindNetworkAddress(addressCIDR);
            string splitedNetworkAddress = networkAddress.Substring(0, prefix);
            string broadcastAddress = splitedNetworkAddress + onesInHostAddress;

            if (broadcastAddress.Length != 32)
            {
                throw new Exception("Broadcast Address is not 32 in length: " + broadcastAddress.Length);
            }
            return broadcastAddress; //Broadcast Address Last address?
        }

        /// <summary>
        /// Finds the Valid Host Range. From subnetting lab.
        /// </summary>
        /// <param name="addressCIDR"></param>
        /// <returns>Dotted Decimal Range Addresses</returns>
        public static string FindValidHostRange(string addressCIDR)
        {
            string networkAddress = FindNetworkAddress(addressCIDR);
            int beginValidRange = BinaryStringToInt(networkAddress) + 1;
            string broadcastAddress = FindBroadcastAddressAltDef(addressCIDR);
            int endValidRange = BinaryStringToInt(broadcastAddress) - 1;
            string vaildHostRange = BinaryStringAddressToDottedDecimal(IntToBinaryString(beginValidRange)) + " to " + BinaryStringAddressToDottedDecimal(IntToBinaryString(endValidRange));
            return vaildHostRange;
        }

        public static string IntToBinaryString(int input)
        {
            return Convert.ToString(input, 2);
        }

        public static int NumberOfBitsInMask(string subnetMask)
        {
            string subnetMaskBinary = AddressToBinaryString(subnetMask);
            string subnetMaskOnes = subnetMaskBinary.Trim('0');
            return subnetMaskOnes.Length;
        }

        public static string FindSubnetMask(int sites, int maxHosts, char license)
        {
            int prefix = 0;
            switch (license)
            {
                case 'A':
                    prefix = 8;
                    break;
                case 'B':
                    prefix = 16;
                    break;
                case 'C':
                    prefix = 24;
                    break;
                default:
                    throw new Exception("Not a valid class license");
            }

            // subnet prefix = prefix + log base 2 (number of subnets (divisable by 2))
            int numberOfSubnets = sites * maxHosts;
            int subnetPrefix = prefix + (int)Math.Log(numberOfSubnets, 2);
            string subnetMaskBinary = FindSubnetMask(subnetPrefix);
            return subnetMaskBinary;
        }

        /// <summary>
        /// Finds the Network class from the given address in CIDR notation.
        /// To find the Class you look at the first 4 bits of an address
        /// not a prefix. The fist bit is 0 then class A if 10 then B, 110 is C, 1110, D 11110 is E
        /// </summary>
        /// <param name="addressCIDR"></param>
        /// <returns></returns>
        public static char FindNetworkClass(string addressCIDR)
        {
            string address = "";
            ExtractAddressFromCIDR(addressCIDR, out address);

            char networkClass = '0';

            if (address.Substring(0, 1) == "0")
            {
                networkClass = 'A';
            }
            else if (address.Substring(0, 2) == "10")
            {
                networkClass = 'B';
            }
            else if (address.Substring(0, 3) == "110")
            {
                networkClass = 'C';
            }
            else if (address.Substring(0, 4) == "1110")
            {
                networkClass = 'D';
            }
            else if (address.Substring(0, 5) == "11110")
            {
                networkClass = 'E';
            }
            else
            {
                throw new Exception("Address doesn't have a valid class");
            }
            return networkClass;
        }

        /// <summary>
        /// Finds the number of hosts of the given address in CIDR notation. Subnetting Lab
        /// </summary>
        /// <param name="addressCIDR"></param>
        /// <returns></returns>
        public static int FindNumberOfHosts(string addressCIDR)
        {
            int totalAddresses = FindTotalAddresses(addressCIDR);
            int numberOfHosts = totalAddresses - 2; // Subtract nework and broadcast addresses
            return numberOfHosts;
        }

        public static int FindNumberOfHostsFromSubnetMask(string subnetMask)
        {
            int prefix = NumberOfBitsInMask(subnetMask);
            int totalAddresses = (int)Math.Pow(2, (32 - prefix));
            int numberOfHosts = totalAddresses - 2; // Subtract nework and broadcast addresses
            return numberOfHosts;
        }

        /// <summary>
        /// Wrong,
        /// </summary>
        /// <param name="addressCIDR"></param>
        /// <returns></returns>
        public static string FindNetworkAddress(string addressCIDR)
        {
            string addressBinary = "";
            int prefix = 0;
            ExtractPrefixAndAddressFromCIDR(addressCIDR, out prefix, out addressBinary);

            // The Network Address is (any address) (bitwise AND) (network mask)
            //var networkAddressInt = BinaryStringToInt(addressBinary) & BinaryStringToInt(FindNetworkMask(addressCIDR));
            //string networkAddressBinary = Convert.ToString(networkAddressInt, 2);
            string leftAddress = addressBinary.Remove(prefix, addressBinary.Length - prefix);
            string networkAddressBinary = leftAddress.PadRight(addressBinary.Length, '0');
            return networkAddressBinary;
        }

        public static string FindFirstAddress(string addressCIDR)
        {
            string addressBinary = "";
            ExtractAddressFromCIDR(addressCIDR, out addressBinary);

            // The first address is the network address - 2
            var networkAddressInt = BinaryStringToInt(FindNetworkAddress(addressCIDR));
            var firstAddressInt = networkAddressInt - 2;
            string firstAddressBinary = Convert.ToString(firstAddressInt, 2);

            return firstAddressBinary;
        }

        public static string FindLastAddress(string addressCIDR)
        {
            string addressBinary = "";
            ExtractAddressFromCIDR(addressCIDR, out addressBinary);

            // The Last Address is (any address) (bitwise OR) [NOT(network mask)]
            int lastAddressInt = BinaryStringToInt(addressBinary) | ~BinaryStringToInt(FindNetworkMask(addressCIDR));
            string lastAddressBinary = Convert.ToString(lastAddressInt, 2);

            return lastAddressBinary;
        }

        public static int FindTotalAddresses(string addressCIDR)
        {
            int prefix = 0;
            ExtractPrefixFromCIDR(addressCIDR, out prefix);

            // The total addresses is 2 ^ (32-n)
            int totalAddresses = (int)Math.Pow(2, (32 - prefix));

            return totalAddresses;
        }

        public static int FindTotalUsableAddresses(string addressCIDR)
        {
            int prefix = 0;
            ExtractPrefixFromCIDR(addressCIDR, out prefix);

            int totalAddresses = FindTotalAddresses(addressCIDR);

            // The number of usable addresses is total addresses - 2
            //int usableAddresses = (32 - prefix) + 1 - 2;
            int usableAddresses = totalAddresses - 2;

            return usableAddresses;
        }

        public static int FindSubnetPrefix(string addressCIDR, int subnets)
        {
            int prefix = 0;
            ExtractPrefixFromCIDR(addressCIDR, out prefix);

            //prefix length for number of subnets is ?
            // subnet prefix = prefix + log base 2 (number of subnets (divisable by 2))
            if (subnets % 2 != 0)
            {
                throw new Exception("subnets is not divisable by 2");
            }

            int subnetPrefixBits = 0;
            if (subnets > 0)
            {
                subnetPrefixBits = (int)(prefix + Math.Log(subnets, 2));
            }
            else if (subnets != 0)
            {
                throw new Exception("subnets is not greater than 0 or not zero");
            }

            return subnetPrefixBits;
        }

        public static int FindSubnets(string addressCIDR, int subnetPrefixLength)
        {
            int prefix = 0;
            ExtractPrefixFromCIDR(addressCIDR, out prefix);

            //Maximum number of subnets with given subnet prefix length? Total addresses within the subnets (machines?)
            // http://www.sosmath.com/algebra/logs/log4/log47/log47.html
            // subnetPrefix = prefix + log base 2 (number of subnets)
            // subnetPrefix - prefix = log base 2 (subnets)
            // 2 ^ (subnetPrefix - prefix) = subnets
            int maximumSubnets = (int)Math.Pow(2, (subnetPrefixLength - prefix));

            return maximumSubnets;
        }

        public static string BinaryStringAddressToDottedDecimal(string binaryString)
        {
            if (binaryString.Length > 32 || binaryString.Length < 0)
            {
                throw new Exception("Binary string is greater than 32 or less than 0");
            }

            if (binaryString.Length != 32)
            {
                for (int index = binaryString.Length; index < 32; index++)
                {
                    binaryString = binaryString.Insert(0, "0");
                }
            }

            string result = "";
            result += BinaryStringToInt(binaryString.Substring(0, 8));
            result += ".";
            result += BinaryStringToInt(binaryString.Substring(8, 8));
            result += ".";
            result += BinaryStringToInt(binaryString.Substring(16, 8));
            result += ".";
            result += BinaryStringToInt(binaryString.Substring(24, 8));
            return result;
        }

        public static string BinaryStringAddressToDottedBinary(string binaryString)
        {
            binaryString = binaryString.Insert(8, ".");
            binaryString = binaryString.Insert(17, ".");
            binaryString = binaryString.Insert(26, ".");

            return binaryString; // really dottedBinary.
        }

        public static string BinaryStringToHex(string binaryString)
        {
            string result = "";
            if (!(binaryString.Length % 4 == 0))
            {
                for (int index = binaryString.Length; !(index % 4 == 0); index++)
                {
                    binaryString = binaryString.Insert(0, "0");
                }
            }


            for (int index = 0; index < binaryString.Length; index += 4)
            {
                string substring = binaryString.Substring(index, 4);
                char add = '0';
                switch (substring)
                {
                    case "0000":
                        add = '0';
                        break;
                    case "0001":
                        add = '1';
                        break;
                    case "0010":
                        add = '2';
                        break;
                    case "0011":
                        add = '3';
                        break;
                    case "0100":
                        add = '4';
                        break;
                    case "0101":
                        add = '5';
                        break;
                    case "0110":
                        add = '6';
                        break;
                    case "0111":
                        add = '7';
                        break;
                    case "1000":
                        add = '8';
                        break;
                    case "1001":
                        add = '9';
                        break;
                    case "1010":
                        add = 'A';
                        break;
                    case "1011":
                        add = 'B';
                        break;
                    case "1100":
                        add = 'C';
                        break;
                    case "1101":
                        add = 'D';
                        break;
                    case "1110":
                        add = 'E';
                        break;
                    case "1111":
                        add = 'F';
                        break;
                    default:
                        throw new Exception("BinaryStringToHex has a bug");
                }

                result += add;
            }
            result = result.Insert(0, "0x");
            return result;
        }

        /// <summary>
        /// Converts an array of integers to binary strings
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <returns>Array of strings that are in binary.</returns>
        public static string[] ConvertToBinaryStrings(int[] array)
        {
            int arrayLength = array.Length;
            string[] result = new string[arrayLength];
            for (int index = 0; index < arrayLength; ++index)
            {
                result[index] = Convert.ToString(array[index], 2);
            }
            return result;
        }

        /// <summary>
        /// Converts a binary represented as a string to a Decimal represented as an int
        /// </summary>
        /// <param name="binaryString">A binary number as a string</param>
        /// <returns>A decimal number as an int converted from the binary</returns>
        public static int BinaryStringToInt(string binaryString)
        {
            int result = 0;
            int positionFromRight = binaryString.Length - 1;
            for (int index = 0; index < binaryString.Length; index++)
            {
                char binaryStringIndexValue = binaryString[index];
                if (binaryStringIndexValue == '1')
                {
                    int intAdd = 0;
                    int.TryParse(Math.Pow(2, positionFromRight).ToString(), out intAdd);
                    result += intAdd;
                }
                positionFromRight--;
            }
            return result;
        }

        /// <summary>
        /// Adds zeros to a binary number in a string.
        /// </summary>
        /// <param name="binaryNumber">A binary number in string format</param>
        /// <returns>A byte binary number with leading zeros</returns>
        public static string AddZerosMakeByte(string binaryNumber)
        {
            //https://msdn.microsoft.com/en-us/library/system.collections.bitarray.aspx
            //int i = int.Parse("FFFFFF", System.Globalization.NumberStyles.HexNumber);
            //string s = i.ToString("x");
            //int i = 0xFFFFFF;

            //Check if it fits within 0xFF, 255
            if (binaryNumber.Length == 0 || binaryNumber.Length > 8 || !Regex.IsMatch(binaryNumber, @"\b[0-1]{1,8}")) //Wrong regex for binary number
            {
                throw new Exception("invalid binaryNumber");
            }
            else
            {
                for (int index = binaryNumber.Length; index < 8; index++)
                {
                    binaryNumber = binaryNumber.Insert(0, "0");
                }
            }

            return binaryNumber;
        }
        public static void AppendZerosToBeginningOfEachWord(string[] array, int finalWordLength)
        {
            int arrayLength = array.Length;
            for (int index = 0; index < arrayLength; index++)
            {
                string word = array[index];
                int wordLength = word.Length;
                if (wordLength > finalWordLength)
                {
                    throw new Exception("The finalWordLength must be greater than the wordLength of each word in the array.");
                }
                while (wordLength != finalWordLength)
                {
                    word = word.Insert(0, "0");
                    wordLength++;
                }
                array[index] = word;
            }
        }
    }
}