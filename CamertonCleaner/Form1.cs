using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;


namespace CamertonCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //читаем сохраненные настройки
            textBoxKamertonFolder.Text = Properties.Settings.Default.KamertonFolder;
            textBoxArhivFolder.Text = Properties.Settings.Default.ArhivFolder;
            //dataGridViewSpisok.AllowUserToResizeColumns = true;
        }

        private void Chitaem_xml(object obj)
        {
            string deloNomer = "";
            DateTime dataDela=DateTime.MinValue;
            string statusDela = "";
            string sudyaPoDelu = "";
            bool uspeh = true;
            

            if (obj.GetType() != typeof(GoScanParam))
                return;
            GoScanParam ps = (GoScanParam)obj;
            int vsego = ps.filesdir.Length;
            //устанавливаем начальные значения прогресс бара
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Maximum = ps.filesdir.Length;
                    progressBar1.Value = 0;
                }));
            }
            else
            {
                progressBar1.Maximum = ps.filesdir.Length;
                progressBar1.Value = 0;
            }

            //labelNumProgress
            if (labelNumProgress.InvokeRequired)
            {
                labelNumProgress.Invoke(new MethodInvoker(delegate()
                {
                    labelNumProgress.Text = ps.filesdir.Length.ToString();
                }));
            }
            else
            {
                labelNumProgress.Text = ps.filesdir.Length.ToString();
            }

            //обрабатываем всю коллекцию файлов
            StreamReader stream;
            XmlTextReader reader;
            foreach (var item in ps.filesdir)
            {
                deloNomer = "";
                dataDela = DateTime.MinValue;
                statusDela = "";
                sudyaPoDelu = "";

                stream = new StreamReader(item);
                reader = new XmlTextReader(stream);
                try
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element: // Узел является элементом.
                                if (reader.Name == "InputDate")
                                {
                                    reader.Read();
                                    dataDela = DateTime.Parse(reader.Value);
                                }
                                if (reader.Name == "Number")
                                {
                                    reader.Read();
                                    deloNomer = reader.Value;
                                }
                                if (reader.Name == "Status")
                                {
                                    reader.Read();
                                    statusDela = reader.Value;
                                }
                                if (reader.Name == "Actor")
                                {
                                    reader.Read();
                                    if (reader.Value.Contains("Слідчий суддя"))
                                    {
                                        sudyaPoDelu = reader.Value.Replace("Слідчий суддя: ", "");
                                    }
                                    if (reader.Value.Contains("Головуючий суддя"))
                                    {
                                        sudyaPoDelu = reader.Value.Replace("Головуючий суддя: ", "");
                                    }
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //добавляем файл в список поврежденных и ставим пометку что такой найден
                    dataGridViewErrorFileAdd(Path.GetFileName(item));
                    uspeh = false;
                }
                finally
                {
                    reader.Close();
                    stream.Close();
                }

                //проверяем пометку поврежденного файла и если ее нет дабавляем данные в таблицу
                if (uspeh == true)
                {
                    dataGridViewSpisokAdd(deloNomer, dataDela.ToString(), statusDela, sudyaPoDelu, Path.GetFileName(item));
                }
                //dataGridViewSpisok.Rows[dataGridViewSpisok.Rows.Count - 1].HeaderCell.Value = dataGridViewSpisok.Rows.Count + "";
                uspeh = true;
                progressBarStepAdd();
                
            }

            //выделяем первую строку и переводим фокус на список
            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
            {
                dataGridViewSpisok.Rows[0].Cells[0].Selected = true;
                dataGridViewSpisok.Focus();
            }));

            //Обновляем текст вкладок
            if (tabPageSpisokDel.InvokeRequired)
            {
                tabPageSpisokDel.Invoke(new MethodInvoker(delegate()
                    {
                        tabPageSpisokDel.Text = "Перелiк справ - " + dataGridViewSpisok.RowCount;
                    }));
            }
            else
            {
                tabPageSpisokDel.Text = "Перелiк справ - " + dataGridViewSpisok.RowCount;
            }

            if (tabPageError.InvokeRequired)
            {
                tabPageError.Invoke(new MethodInvoker(delegate()
                {
                    tabPageError.Text = "Пошкодженi - " + dataGridViewErrorFile.RowCount;
                }));
            }
            else
            {
                tabPageError.Text = "Пошкодженi - " + dataGridViewErrorFile.RowCount;
            }

            MessageBox.Show("Справ - " + dataGridViewSpisok.RowCount + "\nПошкодженi - " + dataGridViewErrorFile.RowCount);
        }

        private void buttonFolderKamerton_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialogKamerton.ShowDialog();
            folderBrowserDialogKamerton.Description = "Выберите папку с записями камертона";
            if (res == DialogResult.OK)
            {
                //Извлечение имени папки
                textBoxKamertonFolder.Text = folderBrowserDialogKamerton.SelectedPath;
                Properties.Settings.Default.KamertonFolder = folderBrowserDialogKamerton.SelectedPath;
                //Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();
            }
        }

        private void скануватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewErrorFile.Rows.Clear();
            dataGridViewSpisok.Rows.Clear();

            GoScan();
            /*
            string[] filesdir = Directory.GetFiles(textBoxKamertonFolder.Text);
            foreach (var item in filesdir)
            {
                Chitaem_xml(item);
            }
            */
            
            
        }

        private void buttonFolderArhiv_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialogArhiv.ShowDialog();
            folderBrowserDialogArhiv.Description = "Выберите папку куда сохранять архив";
            if (res == DialogResult.OK)
            {
                //Извлечение имени папки
                textBoxArhivFolder.Text = folderBrowserDialogArhiv.SelectedPath;
                Properties.Settings.Default.ArhivFolder = folderBrowserDialogArhiv.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void архiвуватиЗакритiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoArhivClosed();
            /*
            int uspeh = 0;
            int err = 0;
            for (int i = 0; i < dataGridViewSpisok.RowCount-1; i++)
            {
                if (dataGridViewSpisok.Rows[i].Cells[3].Value.ToString() == "Closed")
                {
                    var itog = MoveZapis(dataGridViewSpisok.Rows[i].Cells[5].Value.ToString());
                    if (itog)
                    {
                        dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        uspeh++;
                    }
                    else
                    {
                        dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        err++;
                    }
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
            */
        }

        private bool MoveZapis(string file)
        {
            string sourceFile = textBoxKamertonFolder.Text + "\\" + file;
            string destinationFile = textBoxArhivFolder.Text + "\\" + file;
            
            string sourceDir = textBoxKamertonFolder.Text + "\\" + file.Replace(".cmt","");
            string destinationDir = textBoxArhivFolder.Text + "\\" + file.Replace(".cmt", "");

            try
            {
                //проверяем существование файла в папке назначения и удаляем его
                if(File.Exists(destinationFile))
                {
                    File.Delete(destinationFile);
                }
                File.Move(sourceFile, destinationFile);

                //проверяем существование папки в папке назначения и удаляем ее
                if (Directory.Exists(sourceDir))
                {
                    if (Directory.Exists(destinationDir))
                    {
                        foreach (var filelist in Directory.GetFiles(destinationDir, "*.*"))
                        {
                            File.Delete(filelist);
                        }
                        Directory.Delete(destinationDir);
                    }
                    Directory.Move(sourceDir, destinationDir);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private bool CopyZapis(string file)
        {
            string sourceFile = textBoxKamertonFolder.Text + "\\" + file;
            string destinationFile = textBoxArhivFolder.Text + "\\" + file;

            string sourceDir = textBoxKamertonFolder.Text + "\\" + file.Replace(".cmt", "");
            string destinationDir = textBoxArhivFolder.Text + "\\" + file.Replace(".cmt", "");

            try
            {
                //проверяем существование файла в папке назначения и удаляем его
                if (File.Exists(destinationFile))
                {
                    File.Delete(destinationFile);
                }
                File.Copy(sourceFile, destinationFile,true);

                //проверяем существование папки в папке назначения и удаляем ее
                if (Directory.Exists(sourceDir))
                {
                    if (Directory.Exists(destinationDir))
                    {
                        foreach (var filelist in Directory.GetFiles(destinationDir, "*.*"))
                        {
                            File.Delete(filelist);
                        }
                        Directory.Delete(destinationDir);
                    }
                    Directory.CreateDirectory(destinationDir);
                    foreach (var filelist in Directory.GetFiles(sourceDir, "*.*"))
                    {
                        File.Copy(filelist, destinationDir + "\\" + Path.GetFileName(filelist));
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private void архiвуватиВiдмiченiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoArhivSelected();
            /*
            int uspeh = 0;
            int err = 0;
            for (int i = 0; i < dataGridViewSpisok.RowCount; i++)
            {
                if (dataGridViewSpisok.Rows[i].Cells[0].Value.ToString() != "")
                {
                    var itog = MoveZapis(dataGridViewSpisok.Rows[i].Cells[5].Value.ToString());
                    if (itog)
                    {
                        dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        uspeh++;
                    }
                    else
                    {
                        dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        err++;
                    }
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
            */
        }

        private void азхiвуватиПошкодженiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoArhivErrors();
            /*
            int uspeh = 0;
            int err = 0;
            for (int i = 0; i < dataGridViewErrorFile.RowCount - 1; i++)
            {
                var itog = MoveZapis(dataGridViewErrorFile.Rows[i].Cells[0].Value.ToString());
                if (itog)
                {
                    dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                    uspeh++;
                }
                else
                {
                    dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    err++;
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
            */
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormOprogramme OProgramme=new FormOprogramme();
            OProgramme.ShowDialog();
        }

        private void dataGridViewSpisok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (dataGridViewSpisok.Rows[dataGridViewSpisok.CurrentRow.Index].Cells[0].Value.ToString() == "")
                {
                    dataGridViewSpisok.Rows[dataGridViewSpisok.CurrentRow.Index].Cells[0].Value = "X";
                    
                    if (dataGridViewSpisok.CurrentRow.Index + 1 < dataGridViewSpisok.Rows.Count)
                    {
                        dataGridViewSpisok.Rows[dataGridViewSpisok.CurrentRow.Index].Cells[0].Selected = false;
                        dataGridViewSpisok.Rows[dataGridViewSpisok.CurrentRow.Index + 1].Cells[0].Selected = true;
                    }
                }
                else
                {
                    dataGridViewSpisok.Rows[dataGridViewSpisok.CurrentRow.Index].Cells[0].Value = "";
                    
                    if (dataGridViewSpisok.CurrentRow.Index + 1 < dataGridViewSpisok.Rows.Count)
                    {
                        dataGridViewSpisok.Rows[dataGridViewSpisok.CurrentRow.Index].Cells[0].Selected = false;
                        dataGridViewSpisok.Rows[dataGridViewSpisok.CurrentRow.Index + 1].Cells[0].Selected = true;
                    }
                }
                
            }
        }

        //******************************************************************************************************************

        struct GoScanParam
        {
            internal string[] filesdir;
        }

        private void GoScan()
        {
            string[] filesdir = Directory.GetFiles(textBoxKamertonFolder.Text);
            Thread th = new Thread(Chitaem_xml);
            th.IsBackground = true;
            GoScanParam ps = new GoScanParam();
            ps.filesdir = Directory.GetFiles(textBoxKamertonFolder.Text);
            th.Start(ps);
        }

        private void GoArhivClosed()
        {
            Thread th = new Thread(MoveClosed);
            th.IsBackground = true;
            th.Start();
        }
        private void GoArhivErrors()
        {
            Thread th = new Thread(MoveErrors);
            th.IsBackground = true;
            th.Start();
        }
        private void GoArhivSelected()
        {
            Thread th = new Thread(MoveSelected);
            th.IsBackground = true;
            th.Start();
        }

        private void GoCopySelected()
        {
            Thread th = new Thread(CopySelected);
            th.IsBackground = true;
            th.Start();
        }
        private void GoCopyClosed()
        {
            Thread th = new Thread(CopyClosed);
            th.IsBackground = true;
            th.Start();
        }

        private string dataGridViewSpisokRowData(int rows,int Cells)
        {
            string itog = "";
            if (dataGridViewSpisok.InvokeRequired)
            {
                dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                {
                    itog = dataGridViewSpisok.Rows[rows].Cells[Cells].Value.ToString();
                }));
            }
            else
            {
                return dataGridViewSpisok.Rows[rows].Cells[Cells].Value.ToString();
            }

            return itog;
        }

        private bool dataGridViewSpisokRowVisible(int rows)
        {
            bool itog = true;
            if (dataGridViewSpisok.InvokeRequired)
            {
                dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                {
                    itog = dataGridViewSpisok.Rows[rows].Visible;
                }));
            }
            else
            {
                return itog = dataGridViewSpisok.Rows[rows].Visible;
            }

            return itog;
        }
        private string dataGridViewErrorFileRowData(int rows, int Cells)
        {
            string itog = "";
            if (dataGridViewErrorFile.InvokeRequired)
            {
                dataGridViewErrorFile.Invoke(new MethodInvoker(delegate()
                {
                    itog = dataGridViewErrorFile.Rows[rows].Cells[Cells].Value.ToString();
                }));
            }
            else
            {
                return dataGridViewErrorFile.Rows[rows].Cells[Cells].Value.ToString();
            }

            return itog;
        }

        private void MoveSelected()
        {
            int uspeh = 0;
            int err = 0;
            int RovCount = 0;

            //Читаем в переменную количество строк
            if (dataGridViewSpisok.InvokeRequired)
            {
                dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                {
                    RovCount = dataGridViewSpisok.RowCount;
                }));
            }
            else
            {
                RovCount = dataGridViewSpisok.RowCount;
            }
            //устанавливаем начальные значения прогресс бара
            int RovCountSelected = 0;
            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 0) != "")
                {
                    RovCountSelected++;
                }
            }
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Maximum = RovCountSelected;
                    progressBar1.Value = 0;
                }));
            }
            else
            {
                progressBar1.Maximum = RovCountSelected;
                progressBar1.Value = 0;
            }
            //labelNumProgress
            if (labelNumProgress.InvokeRequired)
            {
                labelNumProgress.Invoke(new MethodInvoker(delegate()
                {
                    labelNumProgress.Text = RovCountSelected.ToString();
                }));
            }
            else
            {
                labelNumProgress.Text = RovCountSelected.ToString();
            }

            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 0) != "")
                {
                    var itog = MoveZapis(dataGridViewSpisokRowData(i, 5));
                    if (itog)
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        }
                        progressBarStepAdd();
                        uspeh++;
                    }
                    else
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                        progressBarStepAdd();
                        err++;
                    }
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
        }
        private void CopySelected()
        {
            int uspeh = 0;
            int err = 0;
            int RovCount = 0;

            //Читаем в переменную количество строк
            if (dataGridViewSpisok.InvokeRequired)
            {
                dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                {
                    RovCount = dataGridViewSpisok.RowCount;
                }));
            }
            else
            {
                RovCount = dataGridViewSpisok.RowCount;
            }
            //устанавливаем начальные значения прогресс бара
            int RovCountSelected = 0;
            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 0) != "")
                {
                    RovCountSelected++;
                }
            }
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Maximum = RovCountSelected;
                    progressBar1.Value = 0;
                }));
            }
            else
            {
                progressBar1.Maximum = RovCountSelected;
                progressBar1.Value = 0;
            }
            //labelNumProgress
            if (labelNumProgress.InvokeRequired)
            {
                labelNumProgress.Invoke(new MethodInvoker(delegate()
                {
                    labelNumProgress.Text = RovCountSelected.ToString();
                }));
            }
            else
            {
                labelNumProgress.Text = RovCountSelected.ToString();
            }

            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 0) != "")
                {
                    var itog = CopyZapis(dataGridViewSpisokRowData(i, 5));
                    if (itog)
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        }
                        progressBarStepAdd();
                        uspeh++;
                    }
                    else
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                        progressBarStepAdd();
                        err++;
                    }
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
        }
        private void MoveErrors()
        {
            int uspeh = 0;
            int err = 0;
            int RovCount = 0;

            if (dataGridViewErrorFile.InvokeRequired)
            {
                dataGridViewErrorFile.Invoke(new MethodInvoker(delegate()
                {
                    RovCount = dataGridViewErrorFile.RowCount;
                }));
            }
            else
            {
                RovCount = dataGridViewErrorFile.RowCount;
            }

            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Maximum = RovCount;
                    progressBar1.Value = 0;
                }));
            }
            else
            {
                progressBar1.Maximum = RovCount;
                progressBar1.Value = 0;
            }
            //labelNumProgress
            if (labelNumProgress.InvokeRequired)
            {
                labelNumProgress.Invoke(new MethodInvoker(delegate()
                {
                    labelNumProgress.Text = RovCount.ToString();
                }));
            }
            else
            {
                labelNumProgress.Text = RovCount.ToString();
            }

            for (int i = 0; i < RovCount; i++)
            {
                var itog = MoveZapis(dataGridViewErrorFileRowData(i,0));
                if (itog)
                {
                    //dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                    if (dataGridViewErrorFile.InvokeRequired)
                    {
                        dataGridViewErrorFile.Invoke(new MethodInvoker(delegate()
                        {
                            dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        }));
                    }
                    else
                    {
                        dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                    }
                    progressBarStepAdd();
                    uspeh++;
                }
                else
                {
                    //dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    if (dataGridViewErrorFile.InvokeRequired)
                    {
                        dataGridViewErrorFile.Invoke(new MethodInvoker(delegate()
                        {
                            dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        }));
                    }
                    else
                    {
                        dataGridViewErrorFile.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    progressBarStepAdd();
                    err++;
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
        }
        private void MoveClosed()
        {
            int uspeh = 0;
            int err = 0;
            int RovCount = 0;

            //Читаем в переменную количество строк
            if (dataGridViewSpisok.InvokeRequired)
            {
                dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                {
                    RovCount = dataGridViewSpisok.RowCount;
                }));
            }
            else
            {
                RovCount = dataGridViewSpisok.RowCount;
            }

            //устанавливаем начальные значения прогресс бара
            int RovCountClosed = 0;
            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 3) == "Closed" && dataGridViewSpisokRowVisible(i))
                {
                    RovCountClosed++;
                }
            }
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Maximum = RovCountClosed;
                    progressBar1.Value = 0;
                }));
            }
            else
            {
                progressBar1.Maximum = RovCountClosed;
                progressBar1.Value = 0;
            }
            //labelNumProgress
            if (labelNumProgress.InvokeRequired)
            {
                labelNumProgress.Invoke(new MethodInvoker(delegate()
                {
                    labelNumProgress.Text = RovCountClosed.ToString();
                }));
            }
            else
            {
                labelNumProgress.Text = RovCountClosed.ToString();
            }

            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 3) == "Closed" && dataGridViewSpisokRowVisible(i))
                {
                    var itog = MoveZapis(dataGridViewSpisokRowData(i,5));
                    if (itog)
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        }
                        progressBarStepAdd();
                        uspeh++;
                    }
                    else
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                        progressBarStepAdd();
                        err++;
                    }
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
        }
        private void CopyClosed()
        {
            int uspeh = 0;
            int err = 0;
            int RovCount = 0;

            //Читаем в переменную количество строк
            if (dataGridViewSpisok.InvokeRequired)
            {
                dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                {
                    RovCount = dataGridViewSpisok.RowCount;
                }));
            }
            else
            {
                RovCount = dataGridViewSpisok.RowCount;
            }

            //устанавливаем начальные значения прогресс бара
            int RovCountClosed = 0;
            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 3) == "Closed" && dataGridViewSpisokRowVisible(i))
                {
                    RovCountClosed++;
                }
            }
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Maximum = RovCountClosed;
                    progressBar1.Value = 0;
                }));
            }
            else
            {
                progressBar1.Maximum = RovCountClosed;
                progressBar1.Value = 0;
            }
            //labelNumProgress
            if (labelNumProgress.InvokeRequired)
            {
                labelNumProgress.Invoke(new MethodInvoker(delegate()
                {
                    labelNumProgress.Text = RovCountClosed.ToString();
                }));
            }
            else
            {
                labelNumProgress.Text = RovCountClosed.ToString();
            }


            for (int i = 0; i < RovCount; i++)
            {
                if (dataGridViewSpisokRowData(i, 3) == "Closed" && dataGridViewSpisokRowVisible(i))
                {
                    var itog = CopyZapis(dataGridViewSpisokRowData(i, 5));
                    if (itog)
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        }
                        progressBarStepAdd();
                        uspeh++;
                    }
                    else
                    {
                        if (dataGridViewSpisok.InvokeRequired)
                        {
                            dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                            }));
                        }
                        else
                        {
                            dataGridViewSpisok.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                        progressBarStepAdd();
                        err++;
                    }
                }
            }
            MessageBox.Show("Виконано успiшно " + uspeh + "\nЗ помилками " + err);
        }
        private void dataGridViewSpisokAdd(string d1, string d2, string d3, string d4, string d5)
        {
            if (dataGridViewSpisok.InvokeRequired)
            {
                dataGridViewSpisok.Invoke(new MethodInvoker(delegate()
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.CreateCells(dataGridViewSpisok, new object[] { "", d1, d2, d3, d4, d5 });
                    dataGridViewSpisok.Rows.Add(dataGridViewRow);
                }));
            }
            else
            {
                dataGridViewSpisok.Rows.Add("", d1, d2, d3, d4, d5);
            }
        }

        private void dataGridViewErrorFileAdd(string d1)
        {
            if (dataGridViewErrorFile.InvokeRequired)
            {
                dataGridViewErrorFile.Invoke(new MethodInvoker(delegate()
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.CreateCells(dataGridViewErrorFile, new object[] { d1 });
                    dataGridViewErrorFile.Rows.Add(dataGridViewRow);
                }));
            }
            else
            {
                dataGridViewErrorFile.Rows.Add(d1);
            }
        }

        private void progressBarStepAdd()
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Value = progressBar1.Value + 1;
                }));
            }
            else
            {
                progressBar1.Value = progressBar1.Value + 1;
            }

            if (labelNumProgress.InvokeRequired)
            {
                labelNumProgress.Invoke(new MethodInvoker(delegate()
                {
                    //labelNumProgress.Text = ((Int32.Parse(labelNumProgress.Text)+1)*100 /ps.filesdir.Length) +"";
                    labelNumProgress.Text = (Int32.Parse(labelNumProgress.Text) - 1).ToString();
                }));
            }
            else
            {
                labelNumProgress.Text = (Int32.Parse(labelNumProgress.Text) - 1).ToString();
            }
        }

        //сканирование при запуске
        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBoxKamertonFolder.Text != "")
            {
                if (Directory.Exists(textBoxKamertonFolder.Text))
                {
                    dataGridViewErrorFile.Rows.Clear();
                    dataGridViewSpisok.Rows.Clear();

                    GoScan();
                }
            }
        }

        private void скопiюватиТiлькиВiдмiченiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoCopySelected();
        }

        private void всіЗакритiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoCopyClosed();
        }

        private void textBoxFiltrAll_TextChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < dataGridViewSpisok.RowCount; j++)
            {
                if (dataGridViewSpisok.Rows[j].Cells[4].Value.ToString().ToLower().Contains(textBoxSudya.Text.ToLower()) != true)
                {
                    dataGridViewSpisok.Rows[j].Visible = false;
                }
                else
                {
                    if (dataGridViewSpisok.Rows[j].Cells[3].Value.ToString().ToLower().Contains(textBoxStatus.Text.ToLower()) != true)
                    {
                        dataGridViewSpisok.Rows[j].Visible = false;
                    }
                    else
                    {
                        if (dataGridViewSpisok.Rows[j].Cells[2].Value.ToString().ToLower().Contains(textBoxData.Text.ToLower()) != true)
                        {
                            dataGridViewSpisok.Rows[j].Visible = false;
                        }
                        else
                        {
                            if (dataGridViewSpisok.Rows[j].Cells[1].Value.ToString().ToLower().Contains(textBoxDelo.Text.ToLower()) != true)
                            {
                                dataGridViewSpisok.Rows[j].Visible = false;
                            }
                            else
                            {
                                dataGridViewSpisok.Rows[j].Visible = true;
                            }
                        }
                    }
                }
            }
            dataGridViewSpisok.Update();
            int rovc = 0;
            for (int j = 0; j < dataGridViewSpisok.RowCount; j++)
            {
                if (dataGridViewSpisok.Rows[j].Visible)
                {
                    rovc++;
                }
            }
            tabPageSpisokDel.Text = "Перелiк справ - " + rovc;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSudya.Text = "";
            textBoxStatus.Text = "";
            textBoxDelo.Text = "";
            textBoxData.Text = "";

            for (int j = 0; j < dataGridViewSpisok.RowCount; j++)
            {
                dataGridViewSpisok.Rows[j].Visible = true;
            }

            dataGridViewSpisok.Update();
        }

    }
}
