#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeUpdater
{
    public partial class Form1 : Form
    {
        private readonly string logDirectory = "";
        private readonly string settingsFilePath = "settings.txt";
        private readonly string defaultRemotePath = "https://www.smartmancs.com.tw/Download/Frank/remoteFolder1";
        private string LastUpdatedTime
        {
            get => tbLastUpdatedTime.Text;
            set => tbLastUpdatedTime.Text = value;
        }

        public Form1()
        {
            InitializeComponent();
            btnUpdate.Click += BtnUpdate_Click;
            LastUpdatedTime = LoadLastUpdatedTime();
            LoadSavedData();
            lstStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            lstStatus.MeasureItem += lst_MeasureItem;
            lstStatus.DrawItem += lst_DrawItem;
        }


        private void lst_MeasureItem(object? sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(lstStatus.Items[e.Index].ToString(), lstStatus.Font, lstStatus.Width).Height;
        }

        private void lst_DrawItem(object? sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0 && e.Index < lstStatus.Items.Count)
            {
                var item = lstStatus.Items[e.Index];
                if (item != null)
                {
                    e.Graphics.DrawString(item.ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                }
            }
        }
        private void SaveLastUpdatedTime(string lastUpdatedTime)
        {
            File.WriteAllText(settingsFilePath, lastUpdatedTime);
        }

        private void LoadSavedData()
        {
            string filePath = "saveData.txt";
            if (File.Exists(filePath))
            {
                string savedData = File.ReadAllText(filePath);
                string[] savedValues = savedData.Split('|');

                if (savedValues.Length >= 4)
                {
                    tbRemotePath.Text = string.IsNullOrEmpty(savedValues[0]) ? defaultRemotePath : savedValues[0];
                    tbLocalPath.Text = savedValues[1];
                    lstFiles.Items.AddRange(savedValues[2].Split(','));
                    tbLastSavedTime.Text = savedValues[3];
                    tbFileCount.Text = lstFiles.Items.Count.ToString();
                }
            }
            else
            {
                tbRemotePath.Text = defaultRemotePath;
            }
        }

        private async void BtnUpdate_Click(object? sender, EventArgs e)
        {
            LastUpdatedTime = DateTime.Now.ToString();
            SaveLastUpdatedTime(LastUpdatedTime);

            btnUpdate.Enabled = false;
            progressBar.Value = 0;

            string localPath = tbLocalPath.Text.Trim();

            if (!Directory.Exists(localPath))
            {
                LogText("[Error] 設定錯誤，本機路徑不存在");
                ResetUI();
                return;
            }

            LogText("檢查更新...");
            if (lstFiles.Items.Count == 0)
            {
                LogText("檔案清單為空，無指定更新的檔案");
                ResetUI();
                return;
            }
            try
            {
                using HttpClient client = new HttpClient();
                string remotePath = tbRemotePath.Text.Trim();
                int totalFiles = lstFiles.Items.Count;
                int completedFiles = 0;

                foreach (var item in lstFiles.Items)
                {
                    string fileName = item.ToString() ?? "";
                    string fileUrl = Path.Combine(remotePath, fileName);
                    string filePath = Path.Combine(tbLocalPath.Text, fileName);

                    HttpResponseMessage response;

                    try
                    {
                        response = await client.GetAsync(fileUrl);
                    }
                    catch (HttpRequestException ex)
                    {
                        LogText($"[Error] 無法下載檔案 '{fileName}': {ex.Message}");
                        continue;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        LogText($"[Error] 無法下載檔案 '{fileName}'。 回傳錯誤代碼 {(int)response.StatusCode}");
                        continue;
                    }

                    try
                    {
                        using Stream contentStream = await response.Content.ReadAsStreamAsync();
                        using FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);

                        const int bufferSize = 8192;
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead;
                        long totalBytesRead = 0;
                        long totalBytes = response.Content.Headers.ContentLength ?? 0;
                        int previousProgressPercentage = 0;

                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, bufferSize)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;

                            int progressPercentage = (int)((totalBytesRead / (double)totalBytes) * 100);
                            if (progressPercentage - previousProgressPercentage >= 20)
                            {
                                progressBar.Invoke((MethodInvoker)(() => progressBar.Value = progressPercentage));
                                LogText($"下載 '{fileName}': {progressPercentage}%");
                                previousProgressPercentage = progressPercentage;
                            }
                        }

                        completedFiles++;
                        LogText($"檔案 '{fileName}' 下載儲存成功!");
                    }
                    catch (Exception ex)
                    {
                        LogText($"[Error] 無法儲存下載後的檔案 '{fileName}': {ex.Message}");
                    }
                }

                if (completedFiles == totalFiles)
                {
                    LogText("所有檔案下載儲存成功!");
                }
                else
                {
                    LogText("[Error] 更新失敗: 部分檔案無法下載或儲存");
                }
            }
            catch (Exception ex)
            {
                LogText("[Error] 更新失敗: " + ex.Message);
            }
            finally
            {
                LastUpdatedTime = DateTime.Now.ToString();
                ResetUI();
            }
        }

        private void ResetUI()
        {
            btnUpdate.Enabled = true;
        }

        public void LogText(string message)
        {
            string formattedMessage = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} --- {message}";
            lstStatus.Items.Add(formattedMessage);

            string logFileName = $"db_exeUpdater_{DateTime.Now:yyyyMMdd}.txt";
            string logFilePath = string.IsNullOrEmpty(logDirectory) ? logFileName : Path.Combine(logDirectory, logFileName);

            Console.WriteLine(formattedMessage);

            using var logFile = new StreamWriter(logFilePath, true);
            logFile.WriteLine(formattedMessage);
        }

        private string LoadLastUpdatedTime()
        {
            if (File.Exists(settingsFilePath))
            {
                return File.ReadAllText(settingsFilePath);
            }

            return string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFileName.Text))
            {
                return;
            }
            lstFiles.Items.Add(tbFileName.Text);
            tbFileName.Clear();
            tbFileCount.Text = lstFiles.Items.Count.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("請選擇檔案項目", "無檔案選取", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> selectedIndices = new List<int>();

            for (int i = lstFiles.SelectedIndices.Count - 1; i >= 0; i--)
            {
                selectedIndices.Add(lstFiles.SelectedIndices[i]);
            }

            foreach (int index in selectedIndices)
            {
                lstFiles.Items.RemoveAt(index);
            }

            tbFileCount.Text = lstFiles.Items.Count.ToString();
        }

        private void btnPathBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                tbLocalPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void tbFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string fileName = tbFileName.Text.Trim();

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    lstFiles.Items.Add(fileName);
                    tbFileName.Clear();
                    tbFileCount.Text = lstFiles.Items.Count.ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string remotePath = tbRemotePath.Text.Trim();
            string localPath = tbLocalPath.Text.Trim();
            List<string> files = new List<string>(lstFiles.Items.Count);

            foreach (var item in lstFiles.Items)
            {
                string fileName = item.ToString() ?? "";
                files.Add(fileName);
            }

            DateTime currentTime = DateTime.Now;

            string saveData = $"{remotePath}|{localPath}|{string.Join(",", files)}|{currentTime}";

            string filePath = "saveData.txt";
            File.WriteAllText(filePath, saveData);

            MessageBox.Show("儲存成功", "儲存", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tbLastSavedTime.Text = currentTime.ToString();
        }

        private void lstStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var selectedItem in lstStatus.SelectedItems)
                    {
                        string itemText = selectedItem.ToString() ?? "";
                        sb.AppendLine(itemText);
                    }

                    if (sb.Length > 0)
                    {
                        Clipboard.SetText(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogText($"Something when run while copying status: {ex.Message}");
            }
            
        }

        private void lstFiles_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var selectedItem in lstFiles.SelectedItems)
                    {
                        string itemText = selectedItem.ToString() ?? "";
                        sb.AppendLine(itemText);
                    }

                    if (sb.Length > 0)
                    {
                        Clipboard.SetText(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogText($"Something when run while copying file names: {ex.Message}");
            }

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            if (string.IsNullOrWhiteSpace(clipboardText))
            {
                MessageBox.Show("剪貼簿的內容為空", "剪貼簿為空", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] items = clipboardText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int itemCount = items.Length;
            lstFiles.Items.AddRange(items);

            MessageBox.Show($"{itemCount} 檔案項目已將入至清單", "新增檔案", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbFileCount.Text = lstFiles.Items.Count.ToString();
        }
    }
}
