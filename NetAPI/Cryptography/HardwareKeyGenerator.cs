using System;
using System.Security.Cryptography;

namespace VieJSLearning.Cryptography
{
    public static class HardwareKeyGenerator
    {
        static HardwareKeyGenerator()
        {
            fingerPrint = String.Empty;
        }

        private static string fingerPrint;

        public static string GetValue()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                var hardwareString = "CPU >> " + CpuId() + "\nBIOS >> " + BiosId() + "\nBASE >> " + BaseId() +
                                     "\nDISK >> " + DiskId() + "\nVIDEO >> " + VideoId();
                using (var md5Hash = MD5.Create())
                {
                    fingerPrint = md5Hash.GetMd5Hash(hardwareString);
                }
            }
            return fingerPrint;
        }

        //Return a hardware identifier
        private static string Identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc =
                new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        private static string CpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = Identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = Identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = Identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = Identifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += Identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }
        //BIOS Identifier
        private static string BiosId()
        {
            return Identifier("Win32_BIOS", "Manufacturer")
                   + Identifier("Win32_BIOS", "SMBIOSBIOSVersion")
                   + Identifier("Win32_BIOS", "IdentificationCode")
                   + Identifier("Win32_BIOS", "SerialNumber")
                   + Identifier("Win32_BIOS", "ReleaseDate")
                   + Identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private static string DiskId()
        {
            return Identifier("Win32_DiskDrive", "Model")
                   + Identifier("Win32_DiskDrive", "Manufacturer")
                   + Identifier("Win32_DiskDrive", "Signature")
                   + Identifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private static string BaseId()
        {
            return Identifier("Win32_BaseBoard", "Model")
                   + Identifier("Win32_BaseBoard", "Manufacturer")
                   + Identifier("Win32_BaseBoard", "Name")
                   + Identifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        private static string VideoId()
        {
            return Identifier("Win32_VideoController", "DriverVersion")
                   + Identifier("Win32_VideoController", "Name");
        }
    }
}