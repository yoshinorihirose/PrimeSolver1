namespace PrimeSolver1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.upperLimitTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tasksTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stepsTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(42, 361);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(180, 49);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(632, 107);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(62, 18);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "停止中";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(635, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(552, 55);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(635, 149);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(552, 316);
            this.logTextBox.TabIndex = 3;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(228, 361);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(180, 49);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "一時停止";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(414, 361);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(180, 49);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "キャンセル";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 72);
            this.label1.TabIndex = 6;
            this.label1.Text = "このプログラムでは与えられた上限の数までの素数の数をカウントします。\r\n計算はマルチスレッドで行うのでCPU負荷が100%になります。\r\n非常に大きな数(10の1" +
    "3乗以上)を上限とすると計算時間が非常に長く\r\nなります。";
            // 
            // upperLimitTextBox
            // 
            this.upperLimitTextBox.Location = new System.Drawing.Point(122, 111);
            this.upperLimitTextBox.Name = "upperLimitTextBox";
            this.upperLimitTextBox.Size = new System.Drawing.Size(228, 25);
            this.upperLimitTextBox.TabIndex = 7;
            this.upperLimitTextBox.Text = "1000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "上限:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "タスク数:";
            // 
            // tasksTextBox
            // 
            this.tasksTextBox.Location = new System.Drawing.Point(122, 147);
            this.tasksTextBox.Name = "tasksTextBox";
            this.tasksTextBox.Size = new System.Drawing.Size(83, 25);
            this.tasksTextBox.TabIndex = 10;
            this.tasksTextBox.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "ステップ数:";
            // 
            // stepsTextBox
            // 
            this.stepsTextBox.Location = new System.Drawing.Point(122, 183);
            this.stepsTextBox.Name = "stepsTextBox";
            this.stepsTextBox.Size = new System.Drawing.Size(83, 25);
            this.stepsTextBox.TabIndex = 12;
            this.stepsTextBox.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(534, 108);
            this.label5.TabIndex = 13;
            this.label5.Text = "タスク数は１ステップ毎にスレッドプールに投入するタスクの数です。\r\nタスクとスレッドは異なるので、タスク数でスレッド数の調整はできません。\r\nステップ数は、計算の" +
    "分割数です。\r\nこのプログラムは１ステップ毎にマルチスレッドの計算結果を集計し、\r\n進捗を更新します。また、一時停止・キャンセルの操作も１ステップの計算が\r\n終" +
    "わってから反映されます。";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(42, 416);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(180, 49);
            this.loadButton.TabIndex = 14;
            this.loadButton.Text = "ロード";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(228, 416);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(180, 49);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "セーブ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 495);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stepsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tasksTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.upperLimitTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "PrimeSolver1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox upperLimitTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tasksTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stepsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
    }
}

