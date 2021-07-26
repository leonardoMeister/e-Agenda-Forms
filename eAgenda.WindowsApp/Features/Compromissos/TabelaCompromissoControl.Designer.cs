
namespace eAgenda.WindowsApp.Features.Compromissos
{
    partial class TabelaCompromissoControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridCompromisso = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompromisso)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCompromisso
            // 
            this.gridCompromisso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCompromisso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCompromisso.Location = new System.Drawing.Point(0, 0);
            this.gridCompromisso.Margin = new System.Windows.Forms.Padding(4);
            this.gridCompromisso.Name = "gridCompromisso";
            this.gridCompromisso.RowHeadersWidth = 51;
            this.gridCompromisso.Size = new System.Drawing.Size(603, 475);
            this.gridCompromisso.TabIndex = 0;
            // 
            // TabelaCompromissoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCompromisso);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TabelaCompromissoControl";
            this.Size = new System.Drawing.Size(603, 475);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompromisso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCompromisso;
    }
}
