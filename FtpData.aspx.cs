using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTP;
using WindowsFormsApplication2;
using System.Configuration;
using Ionic.Zip;

public partial class Import_FtpData : System.Web.UI.Page
{
    //public BackgroundWorker backgroundWorker1;
    //public BackgroundWorker backgroundWorker2;
    private Button button1;
    private CheckBox chkFTP;
    private CheckBox chkUpload;
    //private IContainer components;
    //private DateTimePicker dtPicker;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label lblStatus;
    private bool mAuto;
    private int mCurrentRetries;
    private bool mFound;
    private int mRetries;
    //private OpenFileDialog openFileDialog1;
    //private ProgressBar progressBar1;
    private TextBox textBox1;
    private TextBox textBox2;
    private Timer timer1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        //bool found = false;
        //string sZipFileName = "";
        //string sTxtFileName = "";
        //FTPclient Ftp = new FTPclient(ConfigurationManager.AppSettings["FtpHost"].ToString(), ConfigurationManager.AppSettings["FtpUser"].ToString(), ConfigurationManager.AppSettings["FtpPassword"].ToString());
        //foreach (FTPfileInfo file in Ftp.ListDirectoryDetail(ConfigurationManager.AppSettings["FtpFolder"].ToString(), ConfigurationManager.AppSettings["FTPTimeStampFormat"].ToString()))
        //{
        //    if (file.FileDateTime.ToString("dd/MM/yyyy") == DateControl1.Fecha.ToString("dd/MM/yyyy"))
        //    {
        //        Ftp.Download(file, ConfigurationManager.AppSettings["ZipsFolder"].ToString() + file.Filename, true);
        //        found = true;
        //        sZipFileName = file.Filename;
        //        sTxtFileName = sZipFileName.Replace(".ZIP", ".TXT");
        //        break;
        //    }
        //}

        //if (found)
        //{
        //    found = false;
        //    using (ZipFile zip = ZipFile.Read(ConfigurationManager.AppSettings["ZipsFolder"].ToString() + sZipFileName))
        //    {
        //        foreach (ZipEntry ee in zip)
        //        {
        //            if (ee.FileName.ToUpper() == sTxtFileName.ToUpper())
        //            {
        //                ee.Extract(ConfigurationManager.AppSettings["UnzipFolder"].ToString(), true);
        //                found = true;
        //                this.mFound = true;
        //                this.timer1.Enabled = false;
        //            }
        //        }
        //    }
        //    if (found)
        //    {
        //        new ImportInfo(ConfigurationManager.AppSettings["UnzipFolder"] + sTxtFileName, DateControl1.Fecha);
        //    }
        //    else if (this.mAuto)
        //    {
        //        if ((this.mCurrentRetries < this.mRetries) && (this.mRetries > 0))
        //        {
        //            this.timer1.Enabled = true;
        //        }
        //        else
        //        {
        //            //Application.Exit();
        //        }
        //    }
        //    else
        //    {
        //        //MessageBox.Show("Data file not found inside the archive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //        this.button1.Enabled = true;
        //        this.chkUpload.Enabled = true;
        //        this.chkFTP.Enabled = true;
        //        this.timer1.Enabled = false;
        //    }
        //}
        //else if (this.mAuto)
        //{
        //    if ((this.mCurrentRetries < this.mRetries) && (this.mRetries > 0))
        //    {
        //        this.timer1.Enabled = true;
        //    }
        //    else
        //    {
        //        //Application.Exit();
        //    }
        //}
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //this.backgroundWorker2.RunWorkerAsync(new UploadInfo(ConfigurationManager.AppSettings["FTPUploadHost, ConfigurationManager.AppSettings["FTPUploadUser, ConfigurationManager.AppSettings["FTPUploadPassword, ConfigurationManager.AppSettings["FTPUploadErrorsFolder, ConfigurationManager.AppSettings["FTPUploadGoodFolder, ConfigurationManager.AppSettings["ErrorOutputPath, ConfigurationManager.AppSettings["OutputPath));
        UploadInfo ui = new UploadInfo(ConfigurationManager.AppSettings["FTPUploadHost"].ToString(), ConfigurationManager.AppSettings["FTPUploadUser"].ToString(), ConfigurationManager.AppSettings["FTPUploadPassword"].ToString(), ConfigurationManager.AppSettings["FTPUploadErrorsFolder"].ToString(), ConfigurationManager.AppSettings["FTPUploadGoodFolder"].ToString(), ConfigurationManager.AppSettings["ErrorOutputPath"].ToString(), ConfigurationManager.AppSettings["OutputPath"].ToString());
    }
    protected void btnUploadNOD_Click(object sender, EventArgs e)
    {

    }
    protected void btnUploadNTS_Click(object sender, EventArgs e)
    {

    }
}
