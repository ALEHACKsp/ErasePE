using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
//Krawk
namespace ErasePEHeader
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern unsafe bool VirtualProtect(IntPtr lpaddr, int dwsz, uint newptr, out uint oldptr);
        [DllImport("kernel32.dll")]
        static extern unsafe IntPtr GetModuleHandle(string lmdname);
        [DllImport("S0M.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern unsafe IntPtr S0M(IntPtr addr, IntPtr sz); //i used extern dll to avoid mistakes && S0M = SecureZeroMemory
        static unsafe void Initialize()
        {
            uint old = 0;
            IntPtr pBaseAddr = GetModuleHandle(null);
            VirtualProtect(pBaseAddr, 4096, 0x04, out old);
            S0M(pBaseAddr, (IntPtr)4096); 
        }
        static void Main(string[] args)
        {
            Initialize();
            Console.Write("ErasePE");
            Console.ReadLine();
        }
    }
}
