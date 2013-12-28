using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Drawing;

namespace ETicket.Client
{
    /// <summary>
    /// 通过RDLC向默认打印机输出打印报表
    /// </summary>
    public class RDLCPrinter : IDisposable
    {
        /// <summary>
        /// 当前打印页号
        /// </summary>
        static int m_currentPageIndex;

        /// <summary>
        /// RDCL转换stream一页对应一个stream
        /// </summary>
        static List<Stream> m_streams;

        /// <summary>
        /// 把report输出成stream
        /// </summary>
        /// <param name="report">传入需要Export的report</param>
        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
                "  <PageWidth>12.05cm</PageWidth>" +
                "  <PageHeight>29.7cm</PageHeight>" +
                "  <MarginTop>0in</MarginTop>" +
                "  <MarginLeft>0in</MarginLeft>" +
                "  <MarginRight>0in</MarginRight>" +
                "  <MarginBottom>0in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        /// <summary>
        /// 创建具有指定的名称和格式的流。
        /// </summary>
        private Stream CreateStream(string name, string fileNameExtension,
      Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension,
              FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        /// <summary>
        /// 打印输出
        /// </summary>
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage =
              new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        /// <summary>
        /// 打印预处理
        /// </summary>
        private void Print()
        {
            PrintDocument printDoc = new PrintDocument();
            string printerName = printDoc.PrinterSettings.PrinterName;
            if (m_streams == null || m_streams.Count == 0)
                return;
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".", printerName);
                throw new Exception(msg);
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            StandardPrintController spc = new StandardPrintController();
            printDoc.PrintController = spc;
            printDoc.Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        /// <summary>
        /// 对外接口,启动打印
        /// </summary>
        /// <param name="dtSource">打印报表对应的数据源</param>
        /// <param name="sReport">打印报表名称</param>
        public static void Run(LocalReport report)
        {
            //LocalReport report = new LocalReport();
            //report.ReportPath = @"..\..\" + sReport;
            //ReportDataSource dataset = new ReportDataSource("DataSet1", dtSource);
            //report.DataSources.Add(dataset);
            m_currentPageIndex = 0;
            RDLCPrinter printer = new RDLCPrinter();
            printer.Export(report);
            printer.Print();
            printer.Dispose();
        }

        /// <summary>
        /// 获取打印机状态
        /// </summary>
        /// <param name="printerName">打印机名称</param>
        /// <param name="status">输出打印机状态</param>
        private static void GetPrinterStatus2(string printerName, ref uint status)
        {
            try
            {

                string lcPrinterName = printerName;
                IntPtr liHandle = IntPtr.Zero;
                if (!Win32.OpenPrinter(lcPrinterName, out liHandle, IntPtr.Zero))
                {
                    Console.WriteLine("print  is close");
                    return;
                }
                UInt32 level = 2;
                UInt32 sizeNeeded = 0;
                IntPtr buffer = IntPtr.Zero;
                Win32.GetPrinter(liHandle, level, buffer, 0, out sizeNeeded);
                buffer = Marshal.AllocHGlobal((int)sizeNeeded);
                if (!Win32.GetPrinter(liHandle, level, buffer, sizeNeeded, out sizeNeeded))
                {
                    Console.WriteLine(Environment.NewLine + "Fail GetPrinter:" + Marshal.GetLastWin32Error());
                    return;
                }

                Win32.PRINTER_INFO_2 info = (Win32.PRINTER_INFO_2)Marshal.PtrToStructure(buffer, typeof(Win32.PRINTER_INFO_2));
                status = info.Status;
                Marshal.FreeHGlobal(buffer);
                Win32.ClosePrinter(liHandle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 对外接口,调去打印机信息
        /// </summary>
        /// <param name="printerName">打印机名称</param>
        /// <returns>返回打印机当前状态</returns>
        public static string GetPrinterStatus(string printerName)
        {
            uint intValue = 0;
            PrintDocument pd = new PrintDocument();
            printerName = printerName == "" ? pd.PrinterSettings.PrinterName : printerName;
            GetPrinterStatus2(printerName, ref intValue);
            string strRet = string.Empty;
            switch (intValue)
            {
                case 0:
                    strRet = "准备就绪（Ready）";
                    break;
                case 4194432:
                    strRet = "被打开（Lid Open）";
                    break;
                case 144:
                    strRet = "打印纸用完（Out of Paper）";
                    break;
                case 4194448:
                    strRet = "被打开并且打印纸用完（Out of Paper && Lid Open）";
                    break;
                case 1024:
                    strRet = "打印中（Printing）";
                    break;
                case 32768:
                    strRet = "初始化（Initializing）";
                    break;
                case 160:
                    strRet = "手工送纸(Manual Feed in Progress)";
                    break;
                case 4096:
                    strRet = "脱机(Offline)";
                    break;
                default:
                    strRet = "未知状态（unknown state）";
                    break;
            }
            return strRet;
        }
    }
    public class Win32
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool OpenPrinter(string printer, out IntPtr handle, IntPtr printerDefaults);
        [DllImport("winspool.drv")]
        public static extern bool ClosePrinter(IntPtr handle);
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetPrinter(IntPtr handle, UInt32 level, IntPtr buffer, UInt32 size, out UInt32 sizeNeeded);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PRINTER_INFO_2
        {
            public string pServerName;
            public string pPrinterName;
            public string pShareName;
            public string pPortName;
            public string pDriverName;
            public string pComment;
            public string pLocation;
            public IntPtr pDevMode;
            public string pSepFile;
            public string pPrintProcessor;
            public string pDatatype;
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public UInt32 Attributes;
            public UInt32 Priority;
            public UInt32 DefaultPriority;
            public UInt32 StartTime;
            public UInt32 UntilTime;
            public UInt32 Status;
            public UInt32 cJobs;
            public UInt32 AveragePPM;
        }
    }
    class AFCSPrinter
    {
        /*页面打印委托*/
        public delegate void DoPrintDelegate(Graphics g, ref bool HasMorePage);

        PrintDocument iSPriner = null;
        bool m_bUseDefaultPaperSetting = false;

        DoPrintDelegate DoPrint = null;



        public AFCSPrinter()
        {
            iSPriner = new PrintDocument();
            iSPriner.PrintPage += new PrintPageEventHandler
                (this.OnPrintPage);

        }

        public void Dispose()
        {
            if (iSPriner != null) iSPriner.Dispose();
            iSPriner = null;

        }

        /*设置打印机名*/
        public string PrinterName
        {
            get { return iSPriner.PrinterSettings.PrinterName; }
            set { iSPriner.PrinterSettings.PrinterName = value; }
        }

        /*设置打印文档名*/
        public string DocumentName
        {
            get { return iSPriner.DocumentName; }
            set { iSPriner.DocumentName = value; }
        }

        /*设置是否使用缺省纸张*/
        public bool UseDefaultPaper
        {
            get { return m_bUseDefaultPaperSetting; }
            set
            {
                m_bUseDefaultPaperSetting = value;
                if (!m_bUseDefaultPaperSetting)
                {
                    //如果不适用缺省纸张则创建一个自定义纸张，注意，必须使用这个版本的构造函数才是自定义的纸张
                    PaperSize ps = new PaperSize("Custom Size 1", 827, 1169);
                    //将缺省的纸张设置为新建的自定义纸张
                    iSPriner.DefaultPageSettings.PaperSize = ps;
                }
            }
        }

        /*纸张宽度 单位定义为毫米mm*/
        public float PaperWidth
        {
            get { return iSPriner.DefaultPageSettings.PaperSize.Width / 100f * 25.4f; }
            set
            {
                //注意，只有自定义纸张才能修改该属性，否则将导致异常
                if (iSPriner.DefaultPageSettings.PaperSize.Kind == PaperKind.Custom)
                    iSPriner.DefaultPageSettings.PaperSize.Width = (int)(value / 25.4 * 100);
            }
        }

        /*纸张高度 单位定义为毫米mm*/
        public float PaperHeight
        {
            get { return (int)iSPriner.PrinterSettings.DefaultPageSettings.PaperSize.Height / 100f * 25.4f; }
            set
            {
                //注意，只有自定义纸张才能修改该属性，否则将导致异常
                if (iSPriner.DefaultPageSettings.PaperSize.Kind == PaperKind.Custom)
                    iSPriner.DefaultPageSettings.PaperSize.Height = (int)(value / 25.4 * 100);
            }
        }


        /*页面打印*/
        private void OnPrintPage(object sender, PrintPageEventArgs ev)
        {

            //调用委托绘制打印内容
            if (DoPrint != null)
            {
                bool bHadMore = false;
                DoPrint(ev.Graphics, ref bHadMore);
                ev.HasMorePages = bHadMore;

            }

        }


        /* 开始打印*/
        public void Print(DoPrintDelegate doPrint)
        {

            DoPrint = doPrint;
            this.iSPriner.Print();
        }
    }
}