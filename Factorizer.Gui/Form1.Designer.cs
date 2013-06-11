namespace Factorizer.Gui
{
	partial class Form1
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
			this.Factorize = new System.Windows.Forms.Button();
			this.Value = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.Factors = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.CalculationTime = new System.Windows.Forms.Label();
			this.Cancel = new System.Windows.Forms.Button();
			this.ClearCachedPrimes = new System.Windows.Forms.Button();
			this.NumberOfCachedPrimes = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.LargestCachedPrime = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Value)).BeginInit();
			this.SuspendLayout();
			// 
			// Factorize
			// 
			this.Factorize.Location = new System.Drawing.Point(12, 51);
			this.Factorize.Name = "Factorize";
			this.Factorize.Size = new System.Drawing.Size(75, 23);
			this.Factorize.TabIndex = 0;
			this.Factorize.Text = "Factorize!";
			this.Factorize.UseVisualStyleBackColor = true;
			this.Factorize.Click += new System.EventHandler(this.Factorize_Click);
			// 
			// Value
			// 
			this.Value.Location = new System.Drawing.Point(12, 25);
			this.Value.Maximum = new decimal(new int[] {
            -1,
            -1,
            0,
            0});
			this.Value.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.Value.Name = "Value";
			this.Value.Size = new System.Drawing.Size(156, 20);
			this.Value.TabIndex = 1;
			this.Value.Value = new decimal(new int[] {
            -49,
            262143,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Value to factorize";
			// 
			// Factors
			// 
			this.Factors.Dock = System.Windows.Forms.DockStyle.Right;
			this.Factors.Location = new System.Drawing.Point(239, 0);
			this.Factors.Multiline = true;
			this.Factors.Name = "Factors";
			this.Factors.ReadOnly = true;
			this.Factors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Factors.Size = new System.Drawing.Size(222, 287);
			this.Factors.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Factors";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Calculation time:";
			// 
			// CalculationTime
			// 
			this.CalculationTime.AutoSize = true;
			this.CalculationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CalculationTime.Location = new System.Drawing.Point(12, 100);
			this.CalculationTime.Name = "CalculationTime";
			this.CalculationTime.Size = new System.Drawing.Size(58, 13);
			this.CalculationTime.TabIndex = 6;
			this.CalculationTime.Text = "unknown";
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(93, 51);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 7;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// ClearCachedPrimes
			// 
			this.ClearCachedPrimes.Location = new System.Drawing.Point(12, 227);
			this.ClearCachedPrimes.Name = "ClearCachedPrimes";
			this.ClearCachedPrimes.Size = new System.Drawing.Size(165, 23);
			this.ClearCachedPrimes.TabIndex = 8;
			this.ClearCachedPrimes.Text = "Clear cached primes";
			this.ClearCachedPrimes.UseVisualStyleBackColor = true;
			this.ClearCachedPrimes.Click += new System.EventHandler(this.ClearCachedPrimes_Click);
			// 
			// NumberOfCachedPrimes
			// 
			this.NumberOfCachedPrimes.AutoSize = true;
			this.NumberOfCachedPrimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NumberOfCachedPrimes.Location = new System.Drawing.Point(12, 165);
			this.NumberOfCachedPrimes.Name = "NumberOfCachedPrimes";
			this.NumberOfCachedPrimes.Size = new System.Drawing.Size(58, 13);
			this.NumberOfCachedPrimes.TabIndex = 10;
			this.NumberOfCachedPrimes.Text = "unknown";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(131, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Number of cached primes:";
			// 
			// LargestCachedPrime
			// 
			this.LargestCachedPrime.AutoSize = true;
			this.LargestCachedPrime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LargestCachedPrime.Location = new System.Drawing.Point(12, 201);
			this.LargestCachedPrime.Name = "LargestCachedPrime";
			this.LargestCachedPrime.Size = new System.Drawing.Size(58, 13);
			this.LargestCachedPrime.TabIndex = 12;
			this.LargestCachedPrime.Text = "unknown";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 188);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Largest cached prime:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 287);
			this.Controls.Add(this.LargestCachedPrime);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.NumberOfCachedPrimes);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ClearCachedPrimes);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.CalculationTime);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Value);
			this.Controls.Add(this.Factorize);
			this.Controls.Add(this.Factors);
			this.Name = "Form1";
			this.Text = "Factorizer";
			((System.ComponentModel.ISupportInitialize)(this.Value)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Factorize;
		private System.Windows.Forms.NumericUpDown Value;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Factors;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label CalculationTime;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button ClearCachedPrimes;
		private System.Windows.Forms.Label NumberOfCachedPrimes;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label LargestCachedPrime;
		private System.Windows.Forms.Label label6;
	}
}

