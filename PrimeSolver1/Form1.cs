using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSolver1
{
    public partial class Form1 : Form
    {
        private DateTime start;
        private DateTime end;
        private bool isPaused = false;
        private bool isCancelling = false;
        private Int64 upperLimit;
        private Int64 tasks;
        private Int64 steps;
        private ParallelPrimeCounter counter = new ParallelPrimeCounter();

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!Int64.TryParse(upperLimitTextBox.Text, out upperLimit) || upperLimit >= (1L << 62) || upperLimit <= 0)
            {
                MessageBox.Show("上限値に正しい値を入力してください。", "PrimeSolver1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Int64.TryParse(tasksTextBox.Text, out tasks) || tasks > 1000000 || tasks <= 0)
            {
                MessageBox.Show("タスク数に正しい値を入力してください。", "PrimeSolver1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Int64.TryParse(stepsTextBox.Text, out steps) || steps > 1000000 || steps <= 0)
            {
                MessageBox.Show("ステップ数に正しい値を入力してください。", "PrimeSolver1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // CurrentStepが開始値または終了値でない場合はロードがなされたものとみなす。
            if (counter.CurrentStep == 0 || counter.CurrentStep == counter.Steps)
            {
                counter.Init(upperLimit, tasks, steps);
            }
            upperLimitTextBox.Enabled = false;
            tasksTextBox.Enabled = false;
            stepsTextBox.Enabled = false;
            startButton.Enabled = false;
            pauseButton.Enabled = true;
            stopButton.Enabled = true;
            loadButton.Enabled = false;
            saveButton.Enabled = false;
            progressBar1.Value = 0;
            progressLabel.Text = "実行中 (" + counter.Progress + "%)";
            start = DateTime.Now;
            logTextBox.Text = "開始: " + start.ToString();
            backgroundWorker.RunWorkerAsync();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseButton.Text = "再開";
                saveButton.Enabled = true;
            }
            else
            {
                pauseButton.Text = "一時停止";
                saveButton.Enabled = false;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            isCancelling = true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            TextReader reader;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                reader = File.OpenText(dialog.FileName);
                if (!counter.Load(reader)) { throw new Exception(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ファイルのロードに失敗しました。", "PrimeSolver1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            upperLimitTextBox.Text = counter.Size.ToString();
            tasksTextBox.Text = counter.Tasks.ToString();
            stepsTextBox.Text = counter.Steps.ToString();
            upperLimitTextBox.Enabled = false;
            tasksTextBox.Enabled = false;
            stepsTextBox.Enabled = false;
            progressBar1.Value = counter.Progress;
            progressLabel.Text = "停止中 (" + counter.Progress + "%)";
            logTextBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TextWriter writer;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "dat files (*.dat)|*.dat|All files(*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                writer = File.CreateText(dialog.FileName);
                if (writer != null)
                {
                    counter.Save(writer);
                    writer.Close();
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isCompleted = false;
            do
            {
                while (!isCancelling && isPaused) Thread.Sleep(100);
                if (isCancelling) return;
                isCompleted = !counter.MoveNext();
                backgroundWorker.ReportProgress(counter.Progress);
            } while (!isCompleted);
            Debug.WriteLine(counter.Count.ToString());
            e.Result = counter.Count.ToString();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressLabel.Text = "実行中 (" + e.ProgressPercentage + "%)";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            upperLimitTextBox.Enabled = true;
            tasksTextBox.Enabled = true;
            stepsTextBox.Enabled = true;
            startButton.Enabled = true;
            pauseButton.Enabled = false;
            loadButton.Enabled = true;
            saveButton.Enabled = false;
            isPaused = false;
            pauseButton.Text = "一時停止";
            stopButton.Enabled = false;
            progressLabel.Text = "停止中";
            if (!isCancelling)
            {
                end = DateTime.Now;
                logTextBox.Text += Environment.NewLine + "終了: " + end.ToString();
                logTextBox.Text += Environment.NewLine + "実行時間: " + (end - start).ToString();
                logTextBox.Text += Environment.NewLine + (string)e.Result;
            }
            else
            {
                logTextBox.Text += Environment.NewLine + "ユーザーによって計算がキャンセルされました。";
                counter = new ParallelPrimeCounter(); // currentStepを開始値に戻す
                progressBar1.Value = 0;
            }
            isCancelling = false;
        }
    }
}
