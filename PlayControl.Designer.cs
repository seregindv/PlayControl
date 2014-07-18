using System.Windows.Forms;

namespace PlayControl
{
    partial class PlayControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayControl));
            this.focusedLabel = new System.Windows.Forms.Label();
            this.instructions = new System.Windows.Forms.Label();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioAnswer = new System.Windows.Forms.CheckBox();
            this.radioMove = new System.Windows.Forms.CheckBox();
            this.radioPlay = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // focusedLabel
            // 
            this.focusedLabel.AutoSize = true;
            this.focusedLabel.Location = new System.Drawing.Point(12, 9);
            this.focusedLabel.Name = "focusedLabel";
            this.focusedLabel.Size = new System.Drawing.Size(0, 13);
            this.focusedLabel.TabIndex = 0;
            // 
            // instructions
            // 
            this.instructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instructions.Location = new System.Drawing.Point(133, 9);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(158, 100);
            this.instructions.TabIndex = 1;
            this.instructions.Text = "Place mouse cursor over player\'s play/pause button.";
            // 
            // moveTimer
            // 
            this.moveTimer.Interval = 10000;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.radioAnswer);
            this.groupBox1.Controls.Add(this.radioMove);
            this.groupBox1.Controls.Add(this.radioPlay);
            this.groupBox1.Location = new System.Drawing.Point(10, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // radioAnswer
            // 
            this.radioAnswer.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioAnswer.Location = new System.Drawing.Point(7, 73);
            this.radioAnswer.Name = "radioAnswer";
            this.radioAnswer.Size = new System.Drawing.Size(104, 24);
            this.radioAnswer.TabIndex = 2;
            this.radioAnswer.Text = "Skype answer";
            this.radioAnswer.UseVisualStyleBackColor = true;
            this.radioAnswer.CheckedChanged += new System.EventHandler(this.radioAnswer_CheckedChanged);
            // 
            // radioMove
            // 
            this.radioMove.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioMove.Location = new System.Drawing.Point(7, 43);
            this.radioMove.Name = "radioMove";
            this.radioMove.Size = new System.Drawing.Size(104, 24);
            this.radioMove.TabIndex = 1;
            this.radioMove.Text = "Mouse move";
            this.radioMove.UseVisualStyleBackColor = true;
            this.radioMove.CheckedChanged += new System.EventHandler(this.radioMove_CheckedChanged);
            // 
            // radioPlay
            // 
            this.radioPlay.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPlay.Checked = true;
            this.radioPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioPlay.Location = new System.Drawing.Point(7, 13);
            this.radioPlay.Name = "radioPlay";
            this.radioPlay.Size = new System.Drawing.Size(104, 24);
            this.radioPlay.TabIndex = 0;
            this.radioPlay.Text = "Play control";
            this.radioPlay.UseVisualStyleBackColor = true;
            this.radioPlay.CheckedChanged += new System.EventHandler(this.radioPlay_CheckedChanged);
            // 
            // PlayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 119);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.focusedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayControl";
            this.Text = "Play Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.PlayControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label focusedLabel;
        private System.Windows.Forms.Label instructions;
        private System.Windows.Forms.Timer moveTimer;
        private GroupBox groupBox1;
        private CheckBox radioAnswer;
        private CheckBox radioMove;
        private CheckBox radioPlay;
    }
}

