
namespace eAgenda.WindowsApp.Features.Tarefas
{
    partial class TabelaTarefaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridTarefas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTarefas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTarefas
            // 
            this.gridTarefas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTarefas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTarefas.Location = new System.Drawing.Point(0, 0);
            this.gridTarefas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridTarefas.Name = "gridTarefas";
            this.gridTarefas.RowHeadersWidth = 51;
            this.gridTarefas.Size = new System.Drawing.Size(603, 475);
            this.gridTarefas.TabIndex = 0;
            // 
            // TabelaTarefaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTarefas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TabelaTarefaControl";
            this.Size = new System.Drawing.Size(603, 475);
            ((System.ComponentModel.ISupportInitialize)(this.gridTarefas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTarefas;
    }
}
