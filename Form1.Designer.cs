namespace MMA_Tracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			LabelLogWorkout = new Guna.UI2.WinForms.Guna2HtmlLabel();
			LabelDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
			LabelType = new Guna.UI2.WinForms.Guna2HtmlLabel();
			LabelIntensity = new Guna.UI2.WinForms.Guna2HtmlLabel();
			ButtonLogWorkout = new Guna.UI2.WinForms.Guna2Button();
			comboBoxDuration = new ComboBox();
			comboBoxType = new ComboBox();
			comboBoxIntensity = new ComboBox();
			LabelProgress = new Guna.UI2.WinForms.Guna2HtmlLabel();
			labelTrainingHistory = new Guna.UI2.WinForms.Guna2HtmlLabel();
			DataGriedViewHistory = new Guna.UI2.WinForms.Guna2DataGridView();
			CharProgress = new OxyPlot.WindowsForms.PlotView();
			comboBoxChart = new ComboBox();
			ChartType = new OxyPlot.WindowsForms.PlotView();
			ChartIntensity = new OxyPlot.WindowsForms.PlotView();
			ID = new DataGridViewTextBoxColumn();
			Date = new DataGridViewTextBoxColumn();
			Duration = new DataGridViewTextBoxColumn();
			Type = new DataGridViewTextBoxColumn();
			Intensity = new DataGridViewTextBoxColumn();
			Delete = new DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)DataGriedViewHistory).BeginInit();
			SuspendLayout();
			// 
			// LabelLogWorkout
			// 
			LabelLogWorkout.BackColor = Color.Transparent;
			LabelLogWorkout.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LabelLogWorkout.Location = new Point(12, 12);
			LabelLogWorkout.Name = "LabelLogWorkout";
			LabelLogWorkout.Size = new Size(123, 27);
			LabelLogWorkout.TabIndex = 1;
			LabelLogWorkout.Text = "Log Workout";
			LabelLogWorkout.UseSystemCursors = true;
			// 
			// LabelDuration
			// 
			LabelDuration.BackColor = Color.Transparent;
			LabelDuration.Location = new Point(12, 45);
			LabelDuration.Name = "LabelDuration";
			LabelDuration.Size = new Size(81, 17);
			LabelDuration.TabIndex = 2;
			LabelDuration.Text = "Duration (min)";
			// 
			// LabelType
			// 
			LabelType.BackColor = Color.Transparent;
			LabelType.Location = new Point(12, 74);
			LabelType.Name = "LabelType";
			LabelType.Size = new Size(29, 17);
			LabelType.TabIndex = 3;
			LabelType.Text = "Type";
			// 
			// LabelIntensity
			// 
			LabelIntensity.BackColor = Color.Transparent;
			LabelIntensity.Location = new Point(12, 103);
			LabelIntensity.Name = "LabelIntensity";
			LabelIntensity.Size = new Size(48, 17);
			LabelIntensity.TabIndex = 4;
			LabelIntensity.Text = "Intensity";
			// 
			// ButtonLogWorkout
			// 
			ButtonLogWorkout.CustomizableEdges = customizableEdges1;
			ButtonLogWorkout.DisabledState.BorderColor = Color.DarkGray;
			ButtonLogWorkout.DisabledState.CustomBorderColor = Color.DarkGray;
			ButtonLogWorkout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			ButtonLogWorkout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			ButtonLogWorkout.FillColor = Color.FromArgb(0, 120, 217);
			ButtonLogWorkout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ButtonLogWorkout.ForeColor = Color.White;
			ButtonLogWorkout.Location = new Point(12, 132);
			ButtonLogWorkout.Name = "ButtonLogWorkout";
			ButtonLogWorkout.ShadowDecoration.CustomizableEdges = customizableEdges2;
			ButtonLogWorkout.Size = new Size(208, 30);
			ButtonLogWorkout.TabIndex = 5;
			ButtonLogWorkout.Text = "Log Workout";
			ButtonLogWorkout.Click += ButtonLogWorkout_Click;
			// 
			// comboBoxDuration
			// 
			comboBoxDuration.FormattingEnabled = true;
			comboBoxDuration.Location = new Point(99, 45);
			comboBoxDuration.Name = "comboBoxDuration";
			comboBoxDuration.Size = new Size(121, 23);
			comboBoxDuration.TabIndex = 7;
			// 
			// comboBoxType
			// 
			comboBoxType.FormattingEnabled = true;
			comboBoxType.Location = new Point(99, 74);
			comboBoxType.Name = "comboBoxType";
			comboBoxType.Size = new Size(121, 23);
			comboBoxType.TabIndex = 8;
			// 
			// comboBoxIntensity
			// 
			comboBoxIntensity.FormattingEnabled = true;
			comboBoxIntensity.Location = new Point(99, 103);
			comboBoxIntensity.Name = "comboBoxIntensity";
			comboBoxIntensity.Size = new Size(121, 23);
			comboBoxIntensity.TabIndex = 9;
			// 
			// LabelProgress
			// 
			LabelProgress.BackColor = Color.Transparent;
			LabelProgress.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LabelProgress.Location = new Point(12, 168);
			LabelProgress.Name = "LabelProgress";
			LabelProgress.Size = new Size(81, 27);
			LabelProgress.TabIndex = 10;
			LabelProgress.Text = "Progress";
			LabelProgress.UseSystemCursors = true;
			// 
			// labelTrainingHistory
			// 
			labelTrainingHistory.BackColor = Color.Transparent;
			labelTrainingHistory.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelTrainingHistory.Location = new Point(226, 12);
			labelTrainingHistory.Name = "labelTrainingHistory";
			labelTrainingHistory.Size = new Size(148, 27);
			labelTrainingHistory.TabIndex = 11;
			labelTrainingHistory.Text = "Training History";
			labelTrainingHistory.UseSystemCursors = true;
			// 
			// DataGriedViewHistory
			// 
			dataGridViewCellStyle1.BackColor = Color.White;
			DataGriedViewHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGriedViewHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.White;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGriedViewHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGriedViewHistory.ColumnHeadersHeight = 19;
			DataGriedViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			DataGriedViewHistory.Columns.AddRange(new DataGridViewColumn[] { ID, Date, Duration, Type, Intensity, Delete });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = Color.White;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
			dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGriedViewHistory.DefaultCellStyle = dataGridViewCellStyle3;
			DataGriedViewHistory.GridColor = Color.FromArgb(224, 224, 224);
			DataGriedViewHistory.Location = new Point(226, 45);
			DataGriedViewHistory.Name = "DataGriedViewHistory";
			DataGriedViewHistory.RowHeadersVisible = false;
			DataGriedViewHistory.Size = new Size(396, 117);
			DataGriedViewHistory.TabIndex = 12;
			DataGriedViewHistory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
			DataGriedViewHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
			DataGriedViewHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
			DataGriedViewHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
			DataGriedViewHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
			DataGriedViewHistory.ThemeStyle.BackColor = Color.White;
			DataGriedViewHistory.ThemeStyle.GridColor = Color.FromArgb(224, 224, 224);
			DataGriedViewHistory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
			DataGriedViewHistory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
			DataGriedViewHistory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
			DataGriedViewHistory.ThemeStyle.HeaderStyle.ForeColor = Color.White;
			DataGriedViewHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			DataGriedViewHistory.ThemeStyle.HeaderStyle.Height = 19;
			DataGriedViewHistory.ThemeStyle.ReadOnly = false;
			DataGriedViewHistory.ThemeStyle.RowsStyle.BackColor = Color.White;
			DataGriedViewHistory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			DataGriedViewHistory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
			DataGriedViewHistory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
			DataGriedViewHistory.ThemeStyle.RowsStyle.Height = 25;
			DataGriedViewHistory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
			DataGriedViewHistory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
			DataGriedViewHistory.CellContentClick += DataGriedViewHistory_CellContentClick;
			// 
			// CharProgress
			// 
			CharProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			CharProgress.BackColor = Color.White;
			CharProgress.Location = new Point(12, 201);
			CharProgress.Name = "CharProgress";
			CharProgress.PanCursor = Cursors.Hand;
			CharProgress.Size = new Size(610, 248);
			CharProgress.TabIndex = 13;
			CharProgress.Text = "plotView1";
			CharProgress.ZoomHorizontalCursor = Cursors.SizeWE;
			CharProgress.ZoomRectangleCursor = Cursors.SizeNWSE;
			CharProgress.ZoomVerticalCursor = Cursors.SizeNS;
			// 
			// comboBoxChart
			// 
			comboBoxChart.FormattingEnabled = true;
			comboBoxChart.Location = new Point(99, 172);
			comboBoxChart.Name = "comboBoxChart";
			comboBoxChart.Size = new Size(121, 23);
			comboBoxChart.TabIndex = 14;
			comboBoxChart.SelectedIndexChanged += comboBoxChart_SelectedIndexChanged;
			// 
			// ChartType
			// 
			ChartType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ChartType.BackColor = Color.White;
			ChartType.Location = new Point(12, 201);
			ChartType.Name = "ChartType";
			ChartType.PanCursor = Cursors.Hand;
			ChartType.Size = new Size(610, 248);
			ChartType.TabIndex = 15;
			ChartType.Text = "plotView1";
			ChartType.ZoomHorizontalCursor = Cursors.SizeWE;
			ChartType.ZoomRectangleCursor = Cursors.SizeNWSE;
			ChartType.ZoomVerticalCursor = Cursors.SizeNS;
			// 
			// ChartIntensity
			// 
			ChartIntensity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ChartIntensity.BackColor = Color.White;
			ChartIntensity.Location = new Point(12, 201);
			ChartIntensity.Name = "ChartIntensity";
			ChartIntensity.PanCursor = Cursors.Hand;
			ChartIntensity.Size = new Size(610, 248);
			ChartIntensity.TabIndex = 16;
			ChartIntensity.Text = "plotView1";
			ChartIntensity.ZoomHorizontalCursor = Cursors.SizeWE;
			ChartIntensity.ZoomRectangleCursor = Cursors.SizeNWSE;
			ChartIntensity.ZoomVerticalCursor = Cursors.SizeNS;
			// 
			// ID
			// 
			ID.FillWeight = 101.522842F;
			ID.HeaderText = "ID";
			ID.Name = "ID";
			// 
			// Date
			// 
			Date.FillWeight = 99.61929F;
			Date.HeaderText = "Date";
			Date.Name = "Date";
			// 
			// Duration
			// 
			Duration.FillWeight = 99.61929F;
			Duration.HeaderText = "Duration";
			Duration.Name = "Duration";
			// 
			// Type
			// 
			Type.FillWeight = 99.61929F;
			Type.HeaderText = "Type";
			Type.Name = "Type";
			// 
			// Intensity
			// 
			Intensity.FillWeight = 99.61929F;
			Intensity.HeaderText = "Intensity";
			Intensity.Name = "Intensity";
			// 
			// Delete
			// 
			Delete.HeaderText = "Delete";
			Delete.Name = "Delete";
			Delete.Text = "Delete";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(634, 461);
			Controls.Add(ChartIntensity);
			Controls.Add(ChartType);
			Controls.Add(comboBoxChart);
			Controls.Add(CharProgress);
			Controls.Add(DataGriedViewHistory);
			Controls.Add(labelTrainingHistory);
			Controls.Add(LabelProgress);
			Controls.Add(comboBoxIntensity);
			Controls.Add(comboBoxType);
			Controls.Add(comboBoxDuration);
			Controls.Add(ButtonLogWorkout);
			Controls.Add(LabelIntensity);
			Controls.Add(LabelType);
			Controls.Add(LabelDuration);
			Controls.Add(LabelLogWorkout);
			Name = "Form1";
			Text = "MMA_Tracker";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)DataGriedViewHistory).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Guna.UI2.WinForms.Guna2HtmlLabel LabelLogWorkout;
		private Guna.UI2.WinForms.Guna2HtmlLabel LabelDuration;
		private Guna.UI2.WinForms.Guna2HtmlLabel LabelType;
		private Guna.UI2.WinForms.Guna2HtmlLabel LabelIntensity;
		private Guna.UI2.WinForms.Guna2Button ButtonLogWorkout;
		private ComboBox comboBoxDuration;
		private ComboBox comboBoxType;
		private ComboBox comboBoxIntensity;
		private Guna.UI2.WinForms.Guna2HtmlLabel LabelProgress;
		private Guna.UI2.WinForms.Guna2HtmlLabel labelTrainingHistory;
		private Guna.UI2.WinForms.Guna2DataGridView DataGriedViewHistory;
		private OxyPlot.WindowsForms.PlotView CharProgress;
		private ComboBox comboBoxChart;
		private OxyPlot.WindowsForms.PlotView ChartType;
		private OxyPlot.WindowsForms.PlotView ChartIntensity;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn Date;
		private DataGridViewTextBoxColumn Duration;
		private DataGridViewTextBoxColumn Type;
		private DataGridViewTextBoxColumn Intensity;
		private DataGridViewButtonColumn Delete;
	}
}
